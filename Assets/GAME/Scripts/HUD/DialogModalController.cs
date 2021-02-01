using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogModalController : MonoBehaviour
{

    public DialogueHandler dialogeHandler;
    public Animator _animator;
    private bool removeLife;

    private void Update()
    {
        if (_animator != null && dialogeHandler.messageFinished) _animator.speed = 0f;
    }

    public void ShowMessage(string message)
    {
        removeLife = false;
        gameObject.SetActive(true);
        if (dialogeHandler == null) return;
        dialogeHandler.AnimateDialogueBox(message, false);
        if (_animator != null) _animator.speed = 1f;
    }

    public void HideMessage()
    {
        if (dialogeHandler == null || dialogeHandler.messageFinished)
        {
            gameObject.SetActive(false);
            if (GameSystem.instance != null)
            {
                GameSystem.instance.state = GameState.PLAYING;
                if (removeLife)
                {
                    removeLife = false;
                    GameSystem.instance.RemoveLife();
                }
            }
        }
    }

    internal void ShowMessageAndRemoveLife(string message)
    {
        removeLife = true;
        gameObject.SetActive(true);
        if (dialogeHandler == null) return;
        dialogeHandler.AnimateDialogueBox(message, true);
        if (_animator != null) _animator.speed = 1f;
    }
}
