using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDHealthController : MonoBehaviour
{

    private Image[] hearts;
    private int currentHeart;

    // Start is called before the first frame update
    void Start()
    {
        hearts = GetComponentsInChildren<Image>();
        currentHeart = hearts.Length - 1;
    }

    public void RestoreLives()
    {
        foreach (Image heart in hearts)
            hearts[currentHeart].GetComponent<Animator>().SetBool("Death", false);
    }

    public void RemoveLife()
    {
        if (currentHeart < 0) return;
        hearts[currentHeart].GetComponent<Animator>().SetBool("Death", true);
        currentHeart--;
    }

    public int GetHeartCount()
    {
        return currentHeart;
    }
}
