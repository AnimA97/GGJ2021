﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggersHandler : MonoBehaviour
{
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wrong Item")
        {
            if (GameSystem.instance != null) GameSystem.instance.ShowPoliceShoutingMessageModal();
        }
    }

}
