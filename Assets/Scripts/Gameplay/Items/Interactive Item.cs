using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveItem : MonoBehaviour
{

    public bool isInteractable = true;
    public bool isOnSurface = false;

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
        dialog
    }

    public ItemType itemType;

    [DrawIf("itemType", ItemType.documentTextOnly)]
    public string documentText;

    [DrawIf("itemType", ItemType.documentImageOnly)]
    public Sprite image;

    [DrawIf("itemType", ItemType.documentTextAndImage)]
    public string text;
    [DrawIf("itemType", ItemType.documentTextAndImage)]
    public Sprite image2;

    [DrawIf("itemType", ItemType.note)]
    public string noteText;

    [DrawIf("itemType", ItemType.dialog)]
    public string dialogKey;

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
                    Debug.Log("documentTextOnly");
                    break;
                case ItemType.documentImageOnly:
                    Debug.Log("documentImageOnly");
                    break;
                case ItemType.documentTextAndImage:
                    Debug.Log("documentTextAndImage");
                    break;
                case ItemType.note:
                    dialogController.showNote(noteText);
                    break;
                case ItemType.dialog:
                    dialogController.showDialog(dialogKey, dialogImages);
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
