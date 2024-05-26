using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LanguageManager : MonoBehaviour
{
    private string language;

    private Dictionary<string, string> texts;

    private TextAsset stringsJSONFile;

    private TextAsset configJSONFile;

    private LanguageSettingsModel languageSettings;

    // Start is called before the first frame update
    void Start()
    {
        configJSONFile = Resources.Load<TextAsset>("Text/langSettings");
        stringsJSONFile = Resources.Load<TextAsset>("Text/words");
        loadTexts();
    }

    public void loadTexts()
    {

        languageSettings = JsonUtility.FromJson<LanguageSettingsModel>(configJSONFile.text);

        if (!PlayerPrefs.HasKey("selectedLanguage"))
        {
            PlayerPrefs.SetString("selectedLanguage", languageSettings.defaultLanguage);
        }
        language = PlayerPrefs.GetString("selectedLanguage");

        // load all the texts from the JSON file, depending on the language
        var languageDictionary = JsonUtility.FromJson<LanguageDictionary>(stringsJSONFile.text);
        texts = new Dictionary<string, string>();
        foreach (var item in languageDictionary.textStrings)
        {
            if (language == "en")
            {
                texts.Add(item.key, item.en);
            }
            else if (language == "es")
            {
                texts.Add(item.key, item.es);
            }
        }
    }

    public void changeLanguage(string newLanguage)
    {
        language = newLanguage;
        PlayerPrefs.SetString("selectedLanguage", language);
        loadTexts();
    }

    public string getLanguage()
    {
        return language;
    }

    public string getText(string key)
    {
        if(texts == null)
        {
            loadTexts();
        }

        if (texts.ContainsKey(key))
        {
            return texts[key];
        }
        else
        {
            return null;
        }
    }

    public string[] getDialogs(string key)
    {
        if (key == null || key == "")
        {
            return new string[0];
        }

        if (texts == null)
        {
            loadTexts();
        }

        // run through all of the keys in the dictionary and grab the ones that start by the key
        List<string> dialogues = new List<string>();
        foreach (var item in texts)
        {
            string itemKey = item.Key;

            if (itemKey.StartsWith(key))
            {
                dialogues.Add(item.Value);
            }
        }

        return dialogues.ToArray();
    }
}
