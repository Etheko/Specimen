using System.Collections;
using UnityEngine;

public class DevESC : MonoBehaviour
{

    Wizard wizard = new Wizard();

    public GameObject gameMenuObject;

    public GameObject gameMenuWindow;

    public GameObject optionsMenuWindow;

    public GameObject controlsWindow;

    public GameObject audioSettingsWindow;

    public GameObject player;

    public GameObject DialogsUIOverlay;

    private bool isInventoryFrameActive;

    private bool isConfirmationDialogActive;

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
        bool documentTextOnlyFrame = DialogsUIOverlay.transform.Find("Document Text Only Frame").gameObject.activeSelf;
        bool documentTextAndImageFrame = DialogsUIOverlay.transform.Find("Document Text And Image Frame").gameObject.activeSelf;
        bool documentImageOnlyFrame = DialogsUIOverlay.transform.Find("Document Image Only Frame").gameObject.activeSelf;
        bool dialogFrame = DialogsUIOverlay.transform.Find("Dialog Frame").gameObject.activeSelf;
        bool noteFrame = DialogsUIOverlay.transform.Find("Note Frame").gameObject.activeSelf;
        bool confirmationFrame = DialogsUIOverlay.transform.Find("Confirmation Frame").gameObject.activeSelf;
        isInventoryFrameActive = DialogsUIOverlay.transform.Find("Inventory Frame").gameObject.activeSelf;
        return dialogFrame || noteFrame || documentTextOnlyFrame || documentImageOnlyFrame || documentTextAndImageFrame || isInventoryFrameActive || confirmationFrame;
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
                controlsWindow.SetActive(false);
                audioSettingsWindow.SetActive(false);
                gameMenuWindow.SetActive(true);
                gameMenuObject.SetActive(false);
                Time.timeScale = 1;

                enablePlayerMovement();

            }
            else
            {
                isInventoryFrameActive = DialogsUIOverlay.transform.Find("Inventory Frame").gameObject.activeSelf;
                isConfirmationDialogActive = DialogsUIOverlay.transform.Find("Confirmation Frame").gameObject.activeSelf;

                if (!dialogsOpen())
                {
                    if (!isInventoryFrameActive)
                    {
                        AudioSystemManager.instance.enableFilter();
                        Time.timeScale = 0;
                        disablePlayerMovement();
                        gameMenuObject.SetActive(true);
                        gameMenuWindow.SetActive(true);
                        optionsMenuWindow.SetActive(false);
                    }
                    else
                    {
                        InventoryManager.instance.hideInventory();
                    }
                }
                else
                {
                    if (isConfirmationDialogActive)
                    {
                        DialogsUIOverlay.transform.Find("Confirmation Frame").gameObject.SetActive(false);

                        // if there are no more dialogs open, enable player movement
                        if (!dialogsOpen())
                        {
                            enablePlayerMovement();
                        }
                    }
                    else if (isInventoryFrameActive)
                    {
                        InventoryManager.instance.hideInventory();
                    }
                    
                }

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
