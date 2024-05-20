using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeLanguageButton : MonoBehaviour
{
    private Button button;
    public GameObject popup;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(changeLanguage);

    }

    IEnumerator showPopup(string message)
    {
        //show a popup with the message
        popup.SetActive(true);
        popup.GetComponentInChildren<TextMeshProUGUI>().text = message;
        yield return new WaitForSeconds(2);
        popup.SetActive(false);
    }

    public void changeLanguage()
    {
        LanguageManager languageManager = GetComponent<LanguageManager>();
        // change the language
        if (languageManager.getLanguage() == "en")
        {
            languageManager.changeLanguage("es");
            StartCoroutine(showPopup("Reinicia el juego para aplicar los cambios"));
        }
        else
        {
            languageManager.changeLanguage("en");
            StartCoroutine(showPopup("Restart the game to apply the changes"));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
