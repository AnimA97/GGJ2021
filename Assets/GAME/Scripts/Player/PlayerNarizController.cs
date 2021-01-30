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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {

    }

    private NubeOlorController _olor;
    private float _olorDano = 0;
    private void OnTriggerEnter2D(Collider2D otroCollider)
    {
        switch (otroCollider.gameObject.layer)
        {
            case 9: //NubeOlor
                if(_rastro != null)
                {
                    _olorDano = _olorDano + otroCollider.gameObject.GetComponent<NubeOlorController>().getDano();
                    StartCoroutine("DanoPorSegundo");
                }
                break;
            case 10: //OlorCercano
                ObjetoOlible objetoOloroso = otroCollider.gameObject.GetComponent<ObjetoOlible>();
                
                if (objetoOloroso.esIrresistible() && objetoOloroso.fueYaOlido() == false)
                {
                    oler(objetoOloroso);
                }
                break;
        }
    }
    private void OnTriggerStay2D(Collider2D otroCollider)
    {
        switch (otroCollider.gameObject.layer)
        {
            case 10: //OlorCercano
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
        }
    }

    private IEnumerator DanoPorSegundo()
    {
        if(_olorDano <= 0) //Si no se esta mas en nubes de olor
            yield break;

        if (_rastro != null)
        {
            _rastro.danarRastro(_olorDano);
        }
        else
            yield break;
            

        yield return new WaitForSeconds(periodoSegundosDano);
        StartCoroutine("DanoPorSegundo");
    }

    private void oler(ObjetoOlible objetoOloroso)
    {
        if (objetoOloroso.esDanino())
        {
            //Logica de daño
        } else
        {
            //Logica de despliege de rastro
        }
    }
}
