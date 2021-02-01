using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public WinModalController winModal;
    public WinModalController loseModal;
    public LevelLoaderController levelLoader;

    public GameState state;

    private int clues;

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
        if (Input.GetKeyDown(KeyCode.O)) Win();
    }

    public void RemoveLife()
    {
        if (hudController != null)
        {
            hudController.RemoveLife();
            if (hudController.GetHeartCount() < 0)
            {
                if (loseModal)
                {
                    loseModal.gameObject.SetActive(true);
                }
                state = GameState.PAUSE;
            }
        }
    }

    public void RestoreLives()
    {
        if (hudController != null) hudController.RestoreLives();
    }

    public void RestartGame()
    {
        levelLoader.GoToNewPage("Level");
        Destroy(this.gameObject);
    }

    public void ShowPoliceShoutingMessageModal()
    {
        state = GameState.PAUSE;
        dialogModal.ShowMessage(RandomMessages.OneForPolice());
        RemoveLife();
    }

    public void ShowPoliceOutOfLimitsMessageModal()
    {
        state = GameState.PAUSE;
        dialogModal.ShowMessage(RandomMessages.OutOfLimitsMessage());
    }

    public void ShowPoliceIntoLimitsMessageModal()
    {
        state = GameState.PAUSE;
        dialogModal.ShowMessage(RandomMessages.IntoLimitsMessage());
    }

    public bool isPaused()
    {
        return state.Equals(GameState.PAUSE);
    }

    public void Win()
    {
        winModal.gameObject.SetActive(true);
        state = GameState.PAUSE;
    }

    public void FoundClue()
    {
        clues++;
        if (clues >= 4)
        {
            Win();
        }
    }
}
