using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogController : MonoBehaviour
{

    public GameObject dialogFrame;

    public GameObject dialogText;

    private LanguageManager languageManager;

    // Start is called before the first frame update
    void Start()
    {
        languageManager = GetComponent<LanguageManager>();

    }

    public void showDialog(string key)
    {
        dialogFrame.SetActive(true);
        dialogText.GetComponent<InGameDialogs>().startNewDialog(key, languageManager);
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

    public void showNote()
    {

    }



    // Update is called once per frame
    void Update()
    {

    }
}
