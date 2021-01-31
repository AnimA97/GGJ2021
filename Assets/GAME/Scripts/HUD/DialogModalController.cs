using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogModalController : MonoBehaviour
{

    public DialogueHandler dialogeHandler;

    public void ShowMessage()
    {
        gameObject.SetActive(true);
        if (dialogeHandler == null) return;
        dialogeHandler.AnimateDialogueBox("¡Perro malo!\n¡Busca, busca!");
    }

    public void HideMessage()
    {
        if (dialogeHandler == null || dialogeHandler.messageFinished)
        {
            gameObject.SetActive(false);
            if (GameSystem.instance != null) GameSystem.instance.state = GameState.PLAYING;
        }
    }

}
