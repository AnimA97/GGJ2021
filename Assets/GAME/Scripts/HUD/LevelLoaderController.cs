using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderController : MonoBehaviour
{

    private Animator fadeAnimator;

    // Start is called before the first frame update
    void Start()
    {
        fadeAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void GoToNewPage(string pageName)
    {
        StartCoroutine(NewPage(pageName));
    }

    private IEnumerator NewPage(string newPage)
    {
        fadeAnimator.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(newPage);
    }
}
