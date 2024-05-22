using System.Collections;
using TMPro;
using UnityEngine;

public class TextCompletionEffectDialogs : MonoBehaviour
{
    private TMP_Text textMeshPro;

    public string inputText; // Input text

    public GameObject continueIcon;

    private Coroutine animateTextCoroutine; // Coroutine to animate the text

    public string[] dialogues;

    private int currentDialogue = 0;

    private LanguageManager languageManager;

    private bool dialogDone = false;

    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponent<TMP_Text>();

        if (inputText == "" || inputText == null)
        {
            inputText = textMeshPro.text; // Set the input text to the text of the textMeshPro component (if it is not set in the inspector)
        }
        
        if (dialogues.Length > 0)
        {
            inputText = dialogues[0];
        }
        else
        {
            languageManager = GetComponent<LanguageManager>();
            dialogues = languageManager.getDialogs(inputText);
            inputText = dialogues[0];
        }

        animateTextCoroutine = StartCoroutine(AnimateText());
    }

    public void startNewDialog(string dialogKey)
    {
        languageManager = GetComponent<LanguageManager>();
        dialogues = languageManager.getDialogs(dialogKey);
        inputText = dialogues[0];
        currentDialogue = 0;
        animateTextCoroutine = StartCoroutine(AnimateText());
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

    void OnDisable()
    {
        StopCoroutine(animateTextCoroutine); // Stop the coroutine when the object is disabled
    }

    void OnEnable()
    {
        animateTextCoroutine = StartCoroutine(AnimateText()); // Start the coroutine when the object is enabled
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
                    //TODO: fade out the dialog box

                    gameObject.SetActive(false);
                }
            }

        }
    }
}