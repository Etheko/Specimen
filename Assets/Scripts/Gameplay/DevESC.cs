using System.Collections;
using UnityEngine;

public class DevESC : MonoBehaviour
{

    Wizard wizard = new Wizard();

    public GameObject gameMenuObject;

    public GameObject gameMenuWindow;

    public GameObject optionsMenuWindow;

    public GameObject player;

    public GameObject DialogsUIOverlay;

    public void disablePlayerMovement()
    {
        player.GetComponent<PlayerController>().movementEnabled = false;
    }

    public void enablePlayerMovement()
    {
        if (!dialogsOpen())
            player.GetComponent<PlayerController>().movementEnabled = true;
    }

    public bool dialogsOpen()
    {
        bool dialogFrame = DialogsUIOverlay.transform.Find("Dialog Frame").gameObject.activeSelf;
        bool documentFrame = DialogsUIOverlay.transform.Find("Document Frame").gameObject.activeSelf;
        return dialogFrame || documentFrame;
    }

    // Update is called once per frame
    void Update()
    {
        // ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameMenuObject.activeSelf)
            {
                AudioSystemManager.instance.disableFilter();
                optionsMenuWindow.SetActive(false);
                gameMenuWindow.SetActive(true);
                gameMenuObject.SetActive(false);
                Time.timeScale = 1;

                enablePlayerMovement();

            }
            else
            {
                AudioSystemManager.instance.enableFilter();
                Time.timeScale = 0;
                disablePlayerMovement();
                gameMenuObject.SetActive(true);
                gameMenuWindow.SetActive(true);
                optionsMenuWindow.SetActive(false);
            }
        }


        // if ENTER is pressed, create a text file
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(CreateTextFileCoroutine());
        }
    }

    IEnumerator ShowDialogCoroutine()
    {
        wizard.ShowDialog(":)", "You know what this means... :3");
        yield return null;
    }

    IEnumerator CreateTextFileCoroutine()
    {
        wizard.CreateTextFile("Just a file.txt", "???????????????????????????????");
        wizard.ShowDialog("???", "Check your desktop!");
        yield return null;
    }

}
