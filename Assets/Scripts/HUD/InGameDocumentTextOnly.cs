using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameDocumentTextOnly : MonoBehaviour
{

    public GameObject text;
    public GameObject documentBackground;

    public GameObject dialogsUIOverlay;

    private bool hasDialogAfter;
    private List<string> imageList;
    private string dialogKey;
    private bool isCollectable;
    private string itemID;

    private LanguageManager languageManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void setText(string key, LanguageManager langManager, bool hasDialogAfter, List<string> imageList, string dialogKey, bool isCollectable, string itemID)
    {
        this.isCollectable = isCollectable;
        if (isCollectable)
        {
            this.itemID = itemID;
        }
        this.hasDialogAfter = hasDialogAfter;
        this.imageList = imageList;
        this.dialogKey = dialogKey;
        languageManager = langManager;
        GameObject player = GameObject.Find("Player");
        player.GetComponent<PlayerController>().movementEnabled = false;
        string textToWrite = languageManager.getText(key);
        this.text.GetComponent<TMPro.TMP_Text>().text = textToWrite;
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
                dialogsUIOverlay.GetComponent<DialogController>().showDialog(dialogKey, imageList, isCollectable, itemID);
            }
            else
            {
                if (isCollectable)
                {
                    InventoryManager.instance.addItem(itemID, true);
                }
            }
        }



    }
}
