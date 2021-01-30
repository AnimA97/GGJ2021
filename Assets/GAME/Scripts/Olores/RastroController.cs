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

    //Auxiliares
    private float _startingTime;
    private bool _siendoDanado;

    void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _startingTime = Time.time;
        Debug.Log(_startingTime);
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

            _renderer.color = Color.Lerp(colorInicial, colorFinal, _percentageCompleated);
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
        else
        {
            Destroy(this.gameObject);
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
