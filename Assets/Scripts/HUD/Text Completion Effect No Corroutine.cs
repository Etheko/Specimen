using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextCompletionEffectNoCorroutine : MonoBehaviour
{
    private TMP_Text textMeshPro;
    public string inputText; // Input text

    private float delay = 0.1f; // El retraso entre cada carácter
    private float nextCharacterTime = 0; // El tiempo en el que se debe mostrar el próximo carácter
    private int characterIndex = 0; // El índice del próximo carácter a mostrar


    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<TranslatableText>() != null)
        {
            if (inputText == "")
                inputText = GetComponent<TranslatableText>().getTextToWrite(); // Set the input text to the text of the TranslatableText component
            else
                inputText = GetComponent<TranslatableText>().getTextToWrite(inputText); // Set the input text to the text of the TranslatableText component

        }
        else
        {

            textMeshPro = GetComponent<TMP_Text>();

            if (inputText == "")
                inputText = textMeshPro.text; // Set the input text to the text of the textMeshPro component (if it is not set in the inspector)

        }

    }

    void OnDisable()
    {
        textMeshPro.text = "";
    }

    private void OnEnable()
    {
        if (textMeshPro == null)
            textMeshPro = GetComponent<TextMeshProUGUI>();

        if (inputText == null)
        {
            inputText = textMeshPro.text;

        }

        if (GetComponent<TranslatableText>() != null)
            inputText = GetComponent<TranslatableText>().getTextToWrite();

        characterIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.realtimeSinceStartup > nextCharacterTime)
        {
            if (characterIndex < inputText.Length)
            {
                textMeshPro.text = inputText.Substring(0, characterIndex) + "_";
                characterIndex++;
                nextCharacterTime = Time.realtimeSinceStartup + delay;
            }
            else
            {
                textMeshPro.text = inputText;
            }
        }
    }
}
