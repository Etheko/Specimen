using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameDocumentTextAndImage : MonoBehaviour
{

    public GameObject text;
    public GameObject image;

    public GameObject dialogsUIOverlay;

    private bool hasDialogAfter;
    private List<string> imageList;
    private string dialogKey;

    private LanguageManager languageManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void setTextAndImage(string textKey, string imageKey, LanguageManager langManager, bool hasDialogAfter, List<string> imageList, string dialogKey)
    {
        this.hasDialogAfter = hasDialogAfter;
        this.imageList = imageList;
        this.dialogKey = dialogKey;
        languageManager = langManager;
        GameObject player = GameObject.Find("Player");
        player.GetComponent<PlayerController>().movementEnabled = false;
        string textToWrite = languageManager.getText(textKey);
        this.text.GetComponent<TMPro.TMP_Text>().text = textToWrite;
        image.GetComponent<RawImage>().texture = Resources.Load("Document Images/" + imageKey) as Texture;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.E))
        {
            GameObject player = GameObject.Find("Player");
            player.GetComponent<PlayerController>().movementEnabled = true;
            gameObject.SetActive(false);
            if (hasDialogAfter)
            {
                dialogsUIOverlay.GetComponent<DialogController>().showDialog(dialogKey, imageList);
            }
        }
    }
}
