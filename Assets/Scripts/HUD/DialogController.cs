using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogController : MonoBehaviour
{

    public GameObject dialogFrame;

    public GameObject dialogText;

    public GameObject noteFrame;

    public GameObject noteText;

    public GameObject noteBackground;

    public GameObject documentTextOnlyFrame;

    public GameObject documentImageOnlyFrame;

    public GameObject documentTextAndImageFrame;

    private LanguageManager languageManager;

    // Start is called before the first frame update
    void Start()
    {
        languageManager = GetComponent<LanguageManager>();

    }


    public void showDialog(string key, List<string> images, bool isCollectable, string itemID)
    {
        dialogFrame.SetActive(true);
        dialogText.GetComponent<InGameDialogs>().startNewDialog(key, languageManager, images, isCollectable, itemID);
    }

    public void showObtainedItemDialog(string itemID, string imageID)
    {
        dialogFrame.SetActive(true);
        dialogText.GetComponent<InGameDialogs>().startNewItemObtainedDialog(languageManager, itemID, imageID);
    }

    public void showDocumentTextOnly(string text, bool hasDialogAfter, List<string> imageList, string dialogKey, bool isCollectable, string itemID)
    {
        documentTextOnlyFrame.SetActive(true);
        documentTextOnlyFrame.GetComponent<InGameDocumentTextOnly>().setText(text, languageManager, hasDialogAfter, imageList, dialogKey, isCollectable, itemID);
    }

    public void showDocumentImageOnly(string imageFileName, bool hasDialogAfter, List<string> imageList, string dialogKey, bool isCollectable, string itemID)
    {
        documentImageOnlyFrame.SetActive(true);
        documentImageOnlyFrame.GetComponent<InGameDocumentImageOnly>().setImage(imageFileName, hasDialogAfter, imageList, dialogKey, isCollectable, itemID);
    }

    public void showDocumentTextAndImage(string textKey, string imageFileName, bool hasDialogAfter, List<string> imageList, string dialogKey, bool isCollectable, string itemID)
    {
        documentTextAndImageFrame.SetActive(true);
        documentTextAndImageFrame.GetComponent<InGameDocumentTextAndImage>().setTextAndImage(textKey, imageFileName, languageManager, hasDialogAfter, imageList, dialogKey, isCollectable, itemID);
    }

    public void showNote(string text, bool hasDialogAfter, List<string> imageList, string dialogKey, bool isCollectable, string itemID)
    {
        noteFrame.SetActive(true);
        noteFrame.GetComponent<InGameNote>().setText(text, languageManager, hasDialogAfter, imageList, dialogKey, isCollectable, itemID); 
    }

    public void nothing(string itemID, bool isCollectable)
    {

    }



    // Update is called once per frame
    void Update()
    {

    }
}
