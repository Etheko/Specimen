using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TranslatableText : MonoBehaviour
{

    public TMP_Text textMeshPro;

    private string textToWrite;

    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponent<TMP_Text>();

        // get the script "LanguageManager" from the actual object
        LanguageManager languageManagerScript = GetComponent<LanguageManager>();

        string key = textMeshPro.text;

        textToWrite = languageManagerScript.getText(key);
        textMeshPro.text = textToWrite;
    }

    public string getTextToWrite()
    {
        return textToWrite;
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
