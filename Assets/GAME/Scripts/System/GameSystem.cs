using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    PLAYING, PAUSE
}

public class GameSystem : MonoBehaviour
{

    public static GameSystem instance;

    public GameObject player;
    public DialogModalController dialogModal;
    public HUDController hudController;

    public GameState state;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            dialogModal.HideMessage();
            DontDestroyOnLoad(this.gameObject);
        } else
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogModal.enabled && Input.anyKey)
        {
            dialogModal.HideMessage();
        }
        if (Input.GetKeyDown(KeyCode.P)) RemoveLife();
    }

    public void RemoveLife()
    {
        if (hudController != null) hudController.RemoveLife();
    }

    public void RestoreLives()
    {
        if (hudController != null) hudController.RestoreLives();
    }

    public void ShowPoliceShoutingMessageModal()
    {
        state = GameState.PAUSE;
        dialogModal.ShowMessage(RandomMessages.OneForPolice());
        RemoveLife();
    }

    internal bool isPaused()
    {
        return state.Equals(GameState.PAUSE);
    }
}
