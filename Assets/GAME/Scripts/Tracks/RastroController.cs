using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RastroController : MonoBehaviour
{
    //Configuraciones
    public float duracion;
    public Color colorInicial;
    public Color colorFinal;

    private float duracionColorDaño = 0.1f;
    public Color colorDaño = Color.red;


    //Componentes
    private SpriteRenderer _renderer;

    //Auxiliares
    private float _startingTime;
    private float _inicioDaño = 0;

    void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
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
        float tiempoDañoTranscurrido = tiempoActual - _inicioDaño;
        if (tiempoDañoTranscurrido > duracionColorDaño && tiempoDañoTranscurrido != tiempoActual)
        {
            float _timeSinceStarted = tiempoActual - _startingTime;
            float _percentageCompleated = _timeSinceStarted / duracion;

            _renderer.color = Color.Lerp(colorInicial, colorFinal, _percentageCompleated);
        }
        else
        {
            _renderer.color = colorDaño;
        }
    }

    public void dañarRastro(float duracionAfectada)
    {
        float tiempoActual = Time.time;
        float tiempoDesdeInicio = tiempoActual - _startingTime;
        float nuevoTiempoHastaDestruccion = duracion - tiempoDesdeInicio - duracionAfectada;
        
        if(nuevoTiempoHastaDestruccion > 0)
        {
            Destroy(this.gameObject, nuevoTiempoHastaDestruccion);
            duracion = duracion - duracionAfectada;
        }

    }
}
