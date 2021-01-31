using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RastroController : MonoBehaviour
{
    //Configuraciones
    public float duracion;
    public Color colorInicial;
    public Color colorFinal;

    public float duracionColorDano = 0.1f;
    public Color colorDaño = Color.red;


    //Componentes
    private SpriteRenderer _renderer;
    private ParticleSystem[] _particleSystems;

    //Auxiliares
    private float _startingTime;
    private bool _siendoDanado;

    void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _particleSystems = GetComponentsInChildren<ParticleSystem>();
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
        if(_siendoDanado != true)
        {
            float tiempoActual = Time.time;
            float _timeSinceStarted = tiempoActual - _startingTime;
            float _percentageCompleated = _timeSinceStarted / duracion;

            foreach (ParticleSystem _particleSystem in _particleSystems)
            {
                var particleSystemEmissionField = _particleSystem.emission;

                float ecuacionDeMapeoDelTiempo = 1 - Mathf.Pow(_percentageCompleated, 2f);
                particleSystemEmissionField.rateOverTime = 30 * ecuacionDeMapeoDelTiempo;
            }

            //_renderer.color = Color.Lerp(colorInicial, colorFinal, _percentageCompleated);
        }
        
    }

    public void danarRastro(float dano)
    {
        float tiempoActual = Time.time;
        float tiempoDesdeInicio = tiempoActual - _startingTime;
        float nuevoTiempoHastaDestruccion = duracion - tiempoDesdeInicio - dano;        
        
        if(nuevoTiempoHastaDestruccion > 0)
        {
            Destroy(this.gameObject, nuevoTiempoHastaDestruccion);
            duracion = duracion - dano;
            StartCoroutine("RecibirDanoPorSegundo");
        }
        

    }

    private IEnumerator RecibirDanoPorSegundo()
    {
        _siendoDanado = true;
        _renderer.color = colorDaño;

        yield return new WaitForSeconds(duracionColorDano);

        _siendoDanado = false;

    }

}
