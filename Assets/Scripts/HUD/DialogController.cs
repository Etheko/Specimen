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

    private LanguageManager languageManager;

    // Start is called before the first frame update
    void Start()
    {
        languageManager = GetComponent<LanguageManager>();

    }

    public void showDialog(string key, List<string> images)
    {
        dialogFrame.SetActive(true);
        dialogText.GetComponent<InGameDialogs>().startNewDialog(key, languageManager, images);
    }

    public void showDocumentTextOnly()
    {

    }

    public void showDocumentImageOnly()
    {

    }

    public void showDocumentTextAndImage()
    {

    }

    public void showDocumentImageFull()
    {

    }

    public void showNote(string text)
    {
        noteFrame.SetActive(true);
        noteFrame.GetComponent<InGameNote>().setText(text, languageManager); 
    }



    // Update is called once per frame
    void Update()
    {

    }
}
