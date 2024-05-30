using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameDocumentImageOnly : MonoBehaviour
{

    public GameObject image;
    public GameObject dialogsUIOverlay;

    private bool hasDialogAfter;
    private List<string> imageList;
    private string dialogKey;
    private bool isCollectable;
    private string itemID;


    // Start is called before the first frame update
    void Start()
    {

    }

    public void setImage(string spriteFileName, bool hasDialogAfter, List<string> imageList, string dialogKey, bool isCollectable, string itemID)
    {
        this.isCollectable = isCollectable;
        if (isCollectable)
        {
            this.itemID = itemID;
        }
        this.hasDialogAfter = hasDialogAfter;
        this.imageList = imageList;
        this.dialogKey = dialogKey;
        GameObject player = GameObject.Find("Player");
        player.GetComponent<PlayerController>().movementEnabled = false;
        image.GetComponent<RawImage>().texture = Resources.Load("Document Images/" + spriteFileName) as Texture;
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
