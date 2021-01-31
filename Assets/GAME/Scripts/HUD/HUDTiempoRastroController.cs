using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDTiempoRastroController : MonoBehaviour
{
    //public GameObject barraTiempoRastro;
    public Slider sliderTiempoRastro;
    public Image fillImage;

    public float duracionColorDano;
    public Color colorDano;

    //Auxiliares
    /*private Transform _transformBarraTiempoRastro;
    private SpriteRenderer _spriteRendererBarraRastro;*/
    /*private Vector2 _escalaInicialBarraTiempoRastro;*/
    private Color _colorOriginal;

    // Start is called before the first frame update
    void Start()
    {
        _colorOriginal = fillImage.color;
        /*_transformBarraTiempoRastro = barraTiempoRastro.GetComponent<Transform>();
        _spriteRendererBarraRastro = barraTiempoRastro.GetComponent<SpriteRenderer>();*/

        //_escalaInicialBarraTiempoRastro = _transformBarraTiempoRastro.localScale;
        //_colorOriginal = _spriteRendererBarraRastro.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void actualizarTiempoRastro(float porcentajeTiempoRestante)
    {
        if (sliderTiempoRastro != null)
        {
            /*Vector2 nuevaEscalaBarra = new Vector2(_escalaInicialBarraTiempoRastro.x * (1 - porcentajeTiempoRestante), _escalaInicialBarraTiempoRastro.y);
            Debug.Log(nuevaEscalaBarra);
            _transformBarraTiempoRastro.localScale = nuevaEscalaBarra;*/

            sliderTiempoRastro.value = 1 - porcentajeTiempoRestante;

            //if(!actualizacionPorDano)
                StartCoroutine("ParpadeoBarra");
        }
    }

    private IEnumerator ParpadeoBarra()
    {
        fillImage.color = colorDano;

        yield return new WaitForSeconds(duracionColorDano);

        fillImage.color = _colorOriginal;
    }
}
