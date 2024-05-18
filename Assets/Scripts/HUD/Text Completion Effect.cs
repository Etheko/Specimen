using System.Collections;
using TMPro;
using UnityEngine;

public class TextCompletionEffect : MonoBehaviour
{
    private TMP_Text textMeshPro;
    private string inputText; // Input text

    private Coroutine animateTextCoroutine; // Coroutine to animate the text

    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<TranslatableText>() != null)
        {
            inputText = GetComponent<TranslatableText>().getTextToWrite(); // Set the input text to the text of the TranslatableText component
            animateTextCoroutine = StartCoroutine(AnimateText());

        }
        else
        {

            textMeshPro = GetComponent<TMP_Text>();
            inputText = textMeshPro.text; // Set the input text to the text of the textMeshPro component (if it is not set in the inspector)
            animateTextCoroutine = StartCoroutine(AnimateText());

        }

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
            yield return new WaitForSeconds(0.1f);
        }

        textMeshPro.text = inputText; // Remove the "_" at the end
    }


    // Update is called once per frame
    void Update()
    {
    }
}