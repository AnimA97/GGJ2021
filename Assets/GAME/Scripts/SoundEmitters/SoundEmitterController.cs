using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEmitterController : MonoBehaviour
{

    public AudioSource _audio;
    public AudioClip[] audios;
    public float timerToShout = 12f;

    private float timeToShout = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeToShout += Time.deltaTime;
        if (timeToShout > timerToShout)
        {
            timeToShout = 0f;
            _audio.PlayOneShot(audios[Random.Range(0, audios.Length)]);
            Debug.Log("Sonido!");
        }
    }
}
