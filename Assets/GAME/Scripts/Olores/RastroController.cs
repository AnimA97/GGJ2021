using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RastroController : MonoBehaviour
{
    //Configuraciones
    public float duracion;


    //Componentes
    private SpriteRenderer _renderer;
    private ParticleSystem[] _particleSystems;
    private HUDTiempoRastroController _controladorHUDTiempoRastro;

    //Auxiliares
    private float _startingTime;
    private bool _siendoDanado;
    private float _porcentajeDeTiempoRestante;

    void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _particleSystems = GetComponentsInChildren<ParticleSystem>();
        _controladorHUDTiempoRastro = GetComponent<HUDTiempoRastroController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _startingTime = Time.time;
        Destroy(this.gameObject, duracion);
    }

    // Update is called once per frame
    void Update()
    {
        float tiempoActual = Time.time;
        float _timeSinceStarted = tiempoActual - _startingTime;
        float porcentajeDeTiempoRestante = _timeSinceStarted / duracion;

        foreach (ParticleSystem _particleSystem in _particleSystems)
        {
            var particleSystemEmissionField = _particleSystem.emission;

            //Bajo la niebla
            float mappeoDeIntensidad = 1 - Mathf.Pow(porcentajeDeTiempoRestante, 2f);
            particleSystemEmissionField.rateOverTime = 30 * mappeoDeIntensidad;

            //Actualizo HUD
            _controladorHUDTiempoRastro.actualizarTiempoRastro(porcentajeDeTiempoRestante);
        }

        
    }

    public void danarRastro(float dano)
    {
        Debug.Log("Daño");
        float tiempoActual = Time.time;
        float tiempoDesdeInicio = tiempoActual - _startingTime;
        float nuevoTiempoHastaDestruccion = duracion - tiempoDesdeInicio - dano;        
        
        if(nuevoTiempoHastaDestruccion > 0)
        {
            Destroy(this.gameObject, nuevoTiempoHastaDestruccion);
            duracion = duracion - dano;
            //StartCoroutine("RecibirDanoPorSegundo");
        }
        

    }

    /*public float obtenerPorcentajeTiempoRestante()
    {
        return _porcentajeDeTiempoRestante;
    }*/

    /*private IEnumerator RecibirDanoPorSegundo()
    {
        _siendoDanado = true;
        _barraDeTiempo.color = colorDano;

        yield return new WaitForSeconds(duracionColorDano);

        _siendoDanado = false;

    }*/

}
