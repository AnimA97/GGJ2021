﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoOlible : MonoBehaviour
{

    //Configuraciones
    public bool irresistible;
    public bool danino;

    // Start is called before the first frame update
    void Start()
    {
        
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
}