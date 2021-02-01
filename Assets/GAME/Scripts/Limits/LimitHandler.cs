using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitHandler : MonoBehaviour
{

    private bool shouted = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!shouted && collision.tag == "Player")
        {
            GameSystem.instance.ShowPoliceOutOfLimitsMessageModal();
            shouted = true;
        }
    }

}
