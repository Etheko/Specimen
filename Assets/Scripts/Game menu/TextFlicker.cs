using System.Collections;
using TMPro;
using UnityEngine;

public class TextFlicker : MonoBehaviour
{
    private TMP_Text textMeshPro;
    private string[] texts;
    private string[] textsEN =
    {
        "Specimen",
        "by Etheko.",
        "Specimen",
        "Will you?",
        "Could you?",
        "Specimen",
        "Am I alone?",
        "Specimen",
        "Hello?",
        "...",
        "Specimen",
        "Who's there?",
        "I need help",
        "Specimen",
        "I'm scared",
        "WHO ARE YOU?",
        "Specimen",
        "...",
        "Specimen",
        "Specimen",
        "S▒ec▄▀en",
        "▀▓e¿■╦██",
        "████████",
        "[ERROR]",
        "[Entry-0]: IT IS TOO LATE! IT IS TOO LATE! IT IS TOO LATE! IT IS TOO LATE! IT IS TOO LATE! IT IS TOO LATE! IT IS TOO"
    };
    private string[] textsES =
    {
        "Specimen",
        "por Etheko.",
        "Specimen",
        "¿Lo harás?",
        "¿Podrás?",
        "Specimen",
        "¿Estoy solo?",
        "Specimen",
        "¿Hola?",
        "...",
        "Specimen",
        "¿Quién está ahí?",
        "Necesito ayuda",
        "Specimen",
        "Tengo miedo",
        "¿QUIÉN ERES?",
        "Specimen",
        "...",
        "Specimen",
        "Specimen",
        "S▒ec▄▀en",
        "▀▓e¿■╦██",
        "████████",
        "[ERROR]",
        "[Entrada-0]: ¡DEMASIADO TARDE! ¡DEMASIADO TARDE! ¡DEMASIADO TARDE! ¡DEMASIADO TARDE! ¡DEMASIADO TARDE! ¡DEMASIADO TAR"
    };

    private Coroutine changeTextCoroutine; // Coroutine to change the text

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("selectedLanguage"))
        {
            PlayerPrefs.SetString("selectedLanguage", "en");
        }

        if (PlayerPrefs.GetString("selectedLanguage") == "en")
        {
            texts = textsEN;
        }
        else if (PlayerPrefs.GetString("selectedLanguage") == "es")
        {
            texts = textsES;
        }

        textMeshPro = GetComponent<TMP_Text>();
        changeTextCoroutine = StartCoroutine(ChangeText());
    }

    void OnDisable()
    {
        StopCoroutine(changeTextCoroutine); // Stop the coroutine when the object is disabled
    }

    void OnEnable()
    {
        changeTextCoroutine = StartCoroutine(ChangeText()); // Start the coroutine when the object is enabled
    }

    // Coroutine to change the text every 5 seconds
    public IEnumerator ChangeText()
    {
        var stringsLength = texts.Length;
        var currentString = 0;
        while (true)
        {
            foreach (string text in texts)
            {
                // Delete each character of the previous text
                for (int i = textMeshPro.text.Length - 1; i >= 0; i--)
                {
                    textMeshPro.text = textMeshPro.text.Remove(i);
                    yield return new WaitForSeconds(0.1f);
                }

                // Type the characters of the following text
                for (int i = 0; i < text.Length; i++)
                {
                    textMeshPro.text = text.Substring(0, i) + "_";
                    yield return new WaitForSeconds(0.1f);
                }

                currentString++;

                textMeshPro.text = text; // Remove the "_" at the end

                if (currentString == stringsLength)
                {
                    Wizard wizard = new Wizard();

                    string title;
                    string message;

                    if (PlayerPrefs.GetString("selectedLanguage") == "en")
                    {
                        title = "!!!!!!!!!!!!!!!!!!";
                        message = "IT IS TOO LATE! IT IS TOO LATE! IT IS TOO LATE! IT IS TOO LATE! IT IS TOO LATE! IT IS TOO LATE! IT IS TOO LATE! IT IS TOO LATE! IT IS TOO LATE! IT IS TOO LATE!";
                    }
                    else
                    {
                        title = "!!!!!!!!!!!!!!!!!!";
                        message = "¡DEMASIADO TARDE! ¡DEMASIADO TARDE! ¡DEMASIADO TARDE! ¡DEMASIADO TARDE! ¡DEMASIADO TARDE! ¡DEMASIADO TARDE! ¡DEMASIADO TARDE! ¡DEMASIADO TARDE! ¡DEMASIADO TARDE! ¡DEMASIADO TARDE! ";
                    }

                    wizard.ShowDialog(title, message);

                    if (!PlayerPrefs.HasKey("cake"))
                    {
                        PlayerPrefs.SetInt("cake", 1);
                    }
                    Application.Quit();
                }

                yield return new WaitForSeconds(5); // Wait for 5 seconds

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}