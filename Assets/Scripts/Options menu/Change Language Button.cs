using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeLanguageButton : MonoBehaviour
{
    private Button button;
    public GameObject popup;
    public string selectedLanguage;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(changeLanguage);

        if (selectedLanguage == null)
        {
            selectedLanguage = "en";
        }

    }

    public void changeLanguage()
    {
        AudioSystemManager.instance.PlayEffect("sfxAction");
        LanguageManager languageManager = GetComponent<LanguageManager>();
        // change the language
        languageManager.changeLanguage(selectedLanguage);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
