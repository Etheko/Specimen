using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLanguageButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        //toggles between "es" and "en" languages when clicked
        if (Input.GetMouseButtonDown(0))
        {
            
            LanguageManager languageManager = GetComponent<LanguageManager>();
            // change the language
            if (languageManager.getLanguage() == "en")
            {
                languageManager.changeLanguage("es");
            }
            else
            {
                languageManager.changeLanguage("en");
            }
        }


    }
}
