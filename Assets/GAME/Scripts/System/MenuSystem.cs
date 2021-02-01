using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSystem : MonoBehaviour
{

    public LevelLoaderController levelLoader;

    public void StartGame()
    {
        levelLoader.GoToNewPage("Level");
    }

}
