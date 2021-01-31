using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueHandler : MonoBehaviour
{

    //Give access to the text component.
    private Text dialogueText;

    //The Speed the text is animated on screen. Waits 0.05 seconds before animating the next character.
    //Useful for letting the player accelerate the speed animation.
    public float defaultSpeedText = 0.05f;
    private float speedText = 0.05f;

    //Only used in the example below, otherwise you can remove this.
    private string stringToAnimate = "";

    void Start()
    {
        dialogueText = GetComponent<Text>();
        AnimateDialogueBox(stringToAnimate);
    }

    [HideInInspector]
    public bool messageFinished = false;

    void Update()
    {
        if (Input.anyKey)
        {
            speedText = defaultSpeedText / 2;
        }
        else
        {
            speedText = defaultSpeedText;
        }
    }

    //Call this public function when you want to animate text. This should be used in your other scripts.
    public void AnimateDialogueBox(string text)
    {
        speedText = defaultSpeedText;
        messageFinished = false;
        StartCoroutine(AnimateTextCoroutine(text));
    }

    private IEnumerator AnimateTextCoroutine(string text)
    {

        //Reset Dialogue Box.
        if (dialogueText == null) dialogueText = GetComponent<Text>();
        dialogueText.text = "";
        int i = 0;

        //Loop over the string.
        while (i < text.Length)
        {

            //Add a character to the dialogue text field.
            dialogueText.text += text[i];

            i++;    //increment

            //Wait before animating next character in scenarioText.
            yield return new WaitForSeconds(speedText);
        }

        if (dialogueText.text.Length > 1) messageFinished = true;
    }
}
