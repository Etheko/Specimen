using System.Collections.Generic;
using System.IO;
using UnityEngine;

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
        // load the language from the JSON file
        var languageConfig = JsonUtility.FromJson<LanguageSettingsModel>(configJSONFile.text);
        language = languageConfig.selectedLanguage;

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
        JsonUtility.FromJsonOverwrite(configJSONFile.text, new LanguageSettingsModel { selectedLanguage = newLanguage });
        loadTexts();
    }

    public string getLanguage()
    {
        return language;
    }

    public string getText(string key)
    {
        if (texts.ContainsKey(key))
        {
            return texts[key];
        }
        else
        {
            return null;
        }
    }
}
