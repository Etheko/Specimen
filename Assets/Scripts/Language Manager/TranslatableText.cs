using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TranslatableText : MonoBehaviour
{

    public TextMeshProUGUI textMeshPro;

    private string textToWrite;

    // Start is called before the first frame update
    void Start()
    {
        getTextToWrite();
    }

    public void initialize()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();

        LanguageManager languageManagerScript = GetComponent<LanguageManager>();

        string key = textMeshPro.text;

        textToWrite = languageManagerScript.getText(key);
        textMeshPro.text = textToWrite;
    }

    public bool isInitialized()
    {
        return textToWrite != null;
    }

    public string getTextToWrite()
    {
        if (textToWrite == null)
        {
            initialize();
        }
        return textToWrite;
    }


    // Update is called once per frame
    void Update()
    {

    }
}
