using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TextCompletionEffectDialogs : MonoBehaviour
{
    private TMP_Text textMeshPro;

    public string inputText; // Input text

    public GameObject continueIcon;

    private Coroutine animateTextCoroutine; // Coroutine to animate the text

    public string[] dialogues;

    private int currentDialogue = 0;

    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponent<TMP_Text>();

        if (inputText == null)
        {
            inputText = textMeshPro.text; // Set the input text to the text of the textMeshPro component (if it is not set in the inspector)
        } else if (dialogues.Length > 0)
        {
            inputText = dialogues[0];
        }

        animateTextCoroutine = StartCoroutine(AnimateText());
    }

    public bool nextDialog()
    {
        if (currentDialogue < dialogues.Length)
        {
            inputText = dialogues[currentDialogue];
            animateTextCoroutine = StartCoroutine(AnimateText());
            return true;
        }
        return false;
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
            yield return new WaitForSeconds(0.05f);
        }

        textMeshPro.text = inputText; // Remove the "_" at the end
        continueIcon.SetActive(true);
        currentDialogue++;
    }


    // Update is called once per frame
    void Update()
    {
    }
}