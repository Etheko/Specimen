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
        documentImageFull,
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

    [DrawIf("itemType", ItemType.documentImageFull)]
    public Sprite imageFull;

    [DrawIf("itemType", ItemType.note)]
    public string noteText;

    [DrawIf("itemType", ItemType.dialog)]
    public string dialogKey;

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
                case ItemType.documentImageFull:
                    Debug.Log("documentImageFull");
                    break;
                case ItemType.note:
                    Debug.Log("note");
                    break;
                case ItemType.dialog:
                    dialogController.showDialog(dialogKey);
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
