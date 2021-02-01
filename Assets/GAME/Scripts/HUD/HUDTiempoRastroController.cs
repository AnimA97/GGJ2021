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

    private bool _siendoDanado = false;

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

    
    public void actualizarTiempoRastro(float porcentajeTiempoRestante, bool siendoDanado)
    {
        if (sliderTiempoRastro != null)
        {
            /*Vector2 nuevaEscalaBarra = new Vector2(_escalaInicialBarraTiempoRastro.x * (1 - porcentajeTiempoRestante), _escalaInicialBarraTiempoRastro.y);
            Debug.Log(nuevaEscalaBarra);
            _transformBarraTiempoRastro.localScale = nuevaEscalaBarra;*/

            sliderTiempoRastro.value = 1 - porcentajeTiempoRestante;

            if(siendoDanado && _siendoDanado == false)
                StartCoroutine("ParpadeoBarra");

            _siendoDanado = siendoDanado;
        }
    }

    private IEnumerator ParpadeoBarra()
    {
        fillImage.color = colorDano;

        yield return new WaitForSeconds(duracionColorDano);

        fillImage.color = _colorOriginal;
        
        yield return new WaitForSeconds(1 - duracionColorDano);

        if (!_siendoDanado)
            yield break;

        StartCoroutine("ParpadeoBarra");
    }
}
