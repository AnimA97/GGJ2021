using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoOlible : MonoBehaviour
{

    //Configuraciones
    public bool irresistible;
    public bool danino;
    
    //Componentes
    

    //Auxiliares
    private bool yaOlido = false;
    private AudioSource _audio;

    // Start is called before the first frame update
    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool esIrresistible()
    {
        return this.irresistible;
    }
    public bool esDanino()
    {
        return this.danino;
    }

    public bool fueYaOlido()
    {
        return yaOlido;
    }
    public void oler()
    {
        if (_audio.clip != null) _audio.Play();
        yaOlido = true;
    }
    public void SetClip(AudioClip clip)
    {
        if (_audio == null || clip == null) return;
        _audio.clip = clip;
    }
}
