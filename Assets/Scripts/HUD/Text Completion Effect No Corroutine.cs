using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextCompletionEffectNoCorroutine : MonoBehaviour
{
    private TMP_Text textMeshPro;
    public string inputText; // Input text

    private string textToWrite; // Text to write
    private float delay = 0.1f; // El retraso entre cada carácter
    private float nextCharacterTime = 0; // El tiempo en el que se debe mostrar el próximo carácter
    private int characterIndex = 0; // El índice del próximo carácter a mostrar


    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponent<TMP_Text>();

        if (GetComponent<TranslatableText>() != null)
        {
            if (inputText == "")
                textToWrite = GetComponent<TranslatableText>().getTextToWrite(textMeshPro.text); // Set the input text to the text of the TranslatableText component
            else
                textToWrite = GetComponent<TranslatableText>().getTextToWrite(inputText); // Set the input text to the text of the TranslatableText component

        }
        else
        {


            if (inputText == "")
                textToWrite = textMeshPro.text; // Set the input text to the text of the textMeshPro component (if it is not set in the inspector)
            else
                textToWrite = inputText;
        }

    }

    void OnDisable()
    {
        textMeshPro.text = "";
    }

    public void initialize()
    {
        if (textMeshPro == null)
            textMeshPro = GetComponent<TextMeshProUGUI>();

        if (GetComponent<TranslatableText>() != null)
        {
            if (inputText == "")
                textToWrite = GetComponent<TranslatableText>().getTextToWrite(textMeshPro.text); // Set the input text to the text of the TranslatableText component
            else
                textToWrite = GetComponent<TranslatableText>().getTextToWrite(inputText); // Set the input text to the text of the TranslatableText component

        }
        else
        {


            if (inputText == "")
                textToWrite = textMeshPro.text; // Set the input text to the text of the textMeshPro component (if it is not set in the inspector)
            else
                textToWrite = inputText;
        }

        characterIndex = 0;
    }

    private void OnEnable()
    {
        initialize();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.realtimeSinceStartup > nextCharacterTime)
        {
            if (inputText == null)
            {
                initialize();
            }
            if (characterIndex < textToWrite.Length)
            {
                textMeshPro.text = textToWrite.Substring(0, characterIndex) + "_";
                characterIndex++;
                nextCharacterTime = Time.realtimeSinceStartup + delay;
            }
            else
            {
                textMeshPro.text = textToWrite;
            }
        }
    }
}
