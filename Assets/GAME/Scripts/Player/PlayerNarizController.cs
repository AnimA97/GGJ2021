using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNarizController : MonoBehaviour
{
    //Configuraciones
    public RastroController _rastro;
    
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

    private OlorController _olor;
    private float _olorDano = 0;
    private void OnTriggerEnter2D(Collider2D otroCollider)
    {
        switch (otroCollider.gameObject.name)
        {
            case "Olor":
                if(_rastro != null)
                {
                    _olorDano = _olorDano + otroCollider.gameObject.GetComponent<OlorController>().getDano();
                    StartCoroutine("DanoPorSegundo");
                }
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D otroCollider)
    {
        switch (otroCollider.gameObject.name)
        {
            case "Olor":    
                _olorDano = _olorDano - otroCollider.gameObject.GetComponent<OlorController>().getDano();
                break;
        }
    }

    private IEnumerator DanoPorSegundo()
    {
        Debug.Log("Hago cosas");
        if(_olorDano <= 0) //Si no se esta mas en nubes de olor
            yield break;

        if (_rastro != null)
            _rastro.danarRastro(_olorDano);
        else
            yield break;
            

        yield return new WaitForSeconds(1f);
        StartCoroutine("DanoPorSegundo");
    }
}
