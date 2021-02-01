using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNarizController : MonoBehaviour
{
    //Configuraciones
    public RastroController _rastro;

    public float periodoSegundosDano;

    //Componentes


    //Auxiliares
    private PlayerAnimationsController _animations;
    private Animator _animator;
    private bool _cercaDeObjetoOlible = false;
    private AudioSource _audio;


    void Awake()
    {
        //_animations = GetComponent<PlayerAnimationsController>();
        _animator = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
    }


    private NubeOlorController _olor;
    private float _olorDano = 0;
    private void OnTriggerEnter2D(Collider2D otroCollider)
    {
        //Debug.Log("layer: " + otroCollider.gameObject.layer);
        switch (otroCollider.gameObject.layer)
        {
            case 9: //NubeOlor
                if(_rastro != null)
                {
                    _olorDano = _olorDano + otroCollider.gameObject.GetComponent<NubeOlorController>().getDano();
                    StartCoroutine("DanoPorSegundo");
                }
                break;
            case 10: //OlorSimple
                ObjetoOlible objetoOloroso = otroCollider.gameObject.GetComponent<ObjetoOlible>();
                if (objetoOloroso.esIrresistible() && !objetoOloroso.fueYaOlido())
                {
                    _audio.PlayOneShot(GetComponent<PlayerAnimationsController>().snifClip);
                    oler(objetoOloroso);
                }
                else
                {
                    _cercaDeObjetoOlible = true;
                }
                break;
        }
    }
    private void OnTriggerStay2D(Collider2D otroCollider)
    {
        switch (otroCollider.gameObject.layer)
        {
            case 10: //OlorSimple
                if (Input.GetButtonDown("Fire1"))
                {
                    ObjetoOlible objetoOloroso = otroCollider.gameObject.GetComponent<ObjetoOlible>();
                    oler(objetoOloroso);
                }
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D otroCollider)
    {
        switch (otroCollider.gameObject.layer)
        {
            case 9: //NubeOlor
                _olorDano = _olorDano - otroCollider.gameObject.GetComponent<NubeOlorController>().getDano();
                break;
            case 10:
                if (_rastro)
                {
                    _rastro.danoTerminado();
                }
                _cercaDeObjetoOlible = false;
                break;
        }
    }

    private IEnumerator DanoPorSegundo()
    {
        if(_olorDano <= 0) //Si no se esta mas en nubes de olor
            yield break;

        if (_rastro != null)
        {
            Debug.Log("Danando");
            _rastro.danarRastro(_olorDano);
        }
        else
            yield break;
            

        yield return new WaitForSeconds(periodoSegundosDano);
        StartCoroutine("DanoPorSegundo");
    }

    private void oler(ObjetoOlible objetoOloroso)
    {
        _animator.SetBool("Sniff", true);
        if (objetoOloroso.esDanino())
        {
            GameSystem.instance.ShowPoliceShoutingMessageModal();
        } else
        {

            GameSystem.instance.FoundClue();
        }
        objetoOloroso.oler();
    }

    public bool cercaDeObjetoOlible()
    {
        return _cercaDeObjetoOlible;
    }
}
