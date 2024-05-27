using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InGameNote : MonoBehaviour
{

    public GameObject text;
    public GameObject noteBackground;

    private LanguageManager languageManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void setText(string key, LanguageManager langManager)
    {
        languageManager = langManager;
        GameObject player = GameObject.Find("Player");
        player.GetComponent<PlayerController>().movementEnabled = false;
        string textToWrite = languageManager.getText(key);
        this.text.GetComponent<TMP_Text>().text = textToWrite;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.E))
        {
            GameObject player = GameObject.Find("Player");
            player.GetComponent<PlayerController>().movementEnabled = true;
            gameObject.SetActive(false);
        }
    }
}
