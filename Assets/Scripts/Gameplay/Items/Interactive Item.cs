using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveItem : MonoBehaviour
{

    public bool isInteractable = true;
    public bool isOnSurface = false;

    public bool isCollectable = false;

    [DrawIf("isCollectable", true)]
    public string itemID;

    public GameObject DialogsUIOverlay;

    public GameObject player;

    public GameObject hitbox;

    private Collider2D collider;

    //type of item
    public enum ItemType
    {
        documentTextOnly,
        documentImageOnly,
        documentTextAndImage,
        note,
        dialog,
        action
    }

    public ItemType itemType;

    [DrawIf("itemType", ItemType.documentTextOnly)]
    public string documentText;

    [DrawIf("itemType", ItemType.documentImageOnly)]
    public string imageFileName;

    [DrawIf("itemType", ItemType.documentTextAndImage)]
    public string text;
    [DrawIf("itemType", ItemType.documentTextAndImage)]
    public string imageName;

    [DrawIf("itemType", ItemType.note)]
    public string noteText;

    [DrawIf("itemType", ItemType.dialog)]
    public string dialogKey;

    [Tooltip("If true, the dialog will show after the document is closed. (Doesn't apply to dialog type)")]
    public bool hasDialogueAfter = false;

    [DrawIf("hasDialogueAfter", true)]
    [Tooltip("Key of the dialog to show after the document is closed.")]
    public string extraDialogKey;

    [DrawIf("itemType", ItemType.action)]
    [Tooltip("Name of the script that will be used for this item's action when used.")]
    public string itemScriptName;

    [Header("Dialog Images")]
    [Tooltip("Images to show in the dialog. Their file names go here, and must be in the order in which they will appear.")]
    public List<string> dialogImages;

    // Start is called before the first frame update
    void Start()
    {
        collider = hitbox.GetComponent<Collider2D>();

    }

    public void checkCollision()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInteractable && collider.IsTouching(player.GetComponent<Collider2D>()) && player.GetComponent<PlayerController>().movementEnabled)
        {
            DialogController dialogController = DialogsUIOverlay.GetComponent<DialogController>();
            AudioSystemManager.instance.PlayEffect("sfxNewQuest");

            switch (itemType)
            {
                case ItemType.documentTextOnly:
                    dialogController.showDocumentTextOnly(documentText, hasDialogueAfter, dialogImages, extraDialogKey, isCollectable, itemID);
                    break;
                case ItemType.documentImageOnly:
                    dialogController.showDocumentImageOnly(imageFileName, hasDialogueAfter, dialogImages, extraDialogKey, isCollectable, itemID);
                    break;
                case ItemType.documentTextAndImage:
                    dialogController.showDocumentTextAndImage(text, imageName, hasDialogueAfter, dialogImages, extraDialogKey, isCollectable, itemID);
                    break;
                case ItemType.note:
                    dialogController.showNote(noteText, hasDialogueAfter, dialogImages, extraDialogKey, isCollectable, itemID);
                    break;
                case ItemType.dialog:
                    dialogController.showDialog(dialogKey, dialogImages, isCollectable, itemID);
                    break;
                case ItemType.action:
                    System.Type type = System.Type.GetType(itemScriptName);
                    if (type != null)
                    {
                        IInteractiveItemBase action = (IInteractiveItemBase)ScriptableObject.CreateInstance(type.ToString());
                        action.UseItem();
                    }
                    else
                    {
                        Debug.LogError("Script not found: " + itemScriptName);
                    }
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        checkCollision();
    }
}
