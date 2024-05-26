using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InGameDialogs : MonoBehaviour
{
    private TMP_Text textMeshPro;

    public string inputText; // Input text

    public GameObject continueIcon;

    private Coroutine animateTextCoroutine; // Coroutine to animate the text

    public string[] dialogues;

    private int currentDialogue = 0;

    private bool dialogDone = false;

    public bool inmovilizePlayer = false;

    private LanguageManager languageManager;

    private void StartDialog()
    {
        inputText = dialogues[0];
        animateTextCoroutine = StartCoroutine(AnimateText());
    }



    public void startNewDialog(string dialogKey, LanguageManager langManager)
    {
        GameObject player = GameObject.Find("Player");
        player.GetComponent<PlayerController>().movementEnabled = !inmovilizePlayer;
        languageManager = langManager;
        textMeshPro = GetComponent<TMP_Text>();
        currentDialogue = 0;
        dialogDone = false;
        dialogues = languageManager.getDialogs(dialogKey);
        StartDialog();
    }

    public bool nextDialog()
    {
        if (currentDialogue < dialogues.Length)
        {
            continueIcon.SetActive(false);
            inputText = dialogues[currentDialogue];
            animateTextCoroutine = StartCoroutine(AnimateText());
            return true; // Return true if there are more dialogues
        }
        return false; // Return false if there are no more dialogues
    }

    public bool isDialogDone()
    {
        return dialogDone;
    }

    public bool isDialogDoneRealTime()
    {
        return currentDialogue >= dialogues.Length;
    }

    public void skipAnimation()
    {
        StopCoroutine(animateTextCoroutine);
        textMeshPro.text = inputText;
        continueIcon.SetActive(true);
        currentDialogue++;

    }

    public bool isDialogLineDone()
    {
        return textMeshPro.text == inputText;
    }

    // Coroutine to change the text every 5 seconds
    public IEnumerator AnimateText()
    {

        // Type the characters of the current text with a "_" at the end
        for (int i = 0; i < inputText.Length; i++)
        {
            textMeshPro.text = inputText.Substring(0, i) + "_";
            yield return new WaitForSeconds(0.02f);
        }

        textMeshPro.text = inputText; // Remove the "_" at the end
        continueIcon.SetActive(true);
        currentDialogue++;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (!isDialogLineDone())
            {
                skipAnimation();
            }
            else
            {

                // Load the next dialog
                if (!nextDialog())
                {
                    dialogDone = true;
                    GameObject player = GameObject.Find("Player");
                    player.GetComponent<PlayerController>().movementEnabled = true;

                    gameObject.transform.parent.gameObject.SetActive(false);

                }
            }

        }
    }
}
