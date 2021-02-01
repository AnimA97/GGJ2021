using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    PLAYING, PAUSE
}

[System.Serializable]
public class SniffableItem
{
    public string name;
    public Sprite image;
    public AudioClip clip;
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

    public SpriteRenderer[] goodItems;
    public SpriteRenderer[] badItems;
    public SniffableItem[] allItems;
    public SniffableItem tempItem;
    public Transform[] allPositions;

    public GameState state;

    private int clues;

    private void Start()
    {
        RandomizeItems();
        StartCoroutine(ShowPoliceStartMessage());
    }

    private void RandomizeItems()
    {
        Shuffle();

        goodItems[0].GetComponent<ObjetoOlible>().SetClip(allItems[0].clip);
        goodItems[0].sprite = allItems[0].image;
        goodItems[1].GetComponent<ObjetoOlible>().SetClip(allItems[1].clip);
        goodItems[1].sprite = allItems[1].image;
        goodItems[2].GetComponent<ObjetoOlible>().SetClip(allItems[2].clip);
        goodItems[2].sprite = allItems[2].image;
        goodItems[3].GetComponent<ObjetoOlible>().SetClip(allItems[3].clip);
        goodItems[3].sprite = allItems[3].image;

        badItems[0].GetComponent<ObjetoOlible>().SetClip(allItems[4].clip);
        badItems[0].sprite = allItems[4].image;
        badItems[1].GetComponent<ObjetoOlible>().SetClip(allItems[5].clip);
        badItems[1].sprite = allItems[5].image;
        badItems[2].GetComponent<ObjetoOlible>().SetClip(allItems[6].clip);
        badItems[2].sprite = allItems[6].image;
    }

    private void Shuffle()
    {
        for (int i = 0; i < allItems.Length; i++)
        {
            int rnd = Random.Range(0, allItems.Length);
            tempItem = allItems[rnd];
            allItems[rnd] = allItems[i];
            allItems[i] = tempItem;
        }
    }

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
        dialogModal.ShowMessageAndRemoveLife(RandomMessages.OneForPolice());
    }

    public IEnumerator ShowPoliceStartMessage()
    {
        yield return new WaitForSeconds(1);
        state = GameState.PAUSE;
        dialogModal.ShowMessage("Vamos amigo! Ve y busca las pistas. Busca " + string.Join(", ", ItemsToSearch()) + ". ¡Apurate!");
    }

    private string[] ItemsToSearch()
    {
        return new string[] { allItems[0].name, allItems[1].name, allItems[2].name, allItems[3].name };
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
