using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveItem : MonoBehaviour
{

    public bool isInteractable = true;
    public bool isOnSurface = false;

    public GameObject player;

    public GameObject hitbox;

    private Collider2D collider;

    //type of item
    public enum ItemType
    {
        documentTextOnly,
        documentImageOnly,
        documentTextAndImage,
        documentImageFull
    }

    public ItemType itemType;

    // Start is called before the first frame update
    void Start()
    {
        collider = hitbox.GetComponent<Collider2D>();

    }

    public void checkCollision()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInteractable && collider.IsTouching(player.GetComponent<Collider2D>()))
        {
            if (itemType == ItemType.documentTextOnly)
            {
                Debug.Log("documentTextOnly");
            }
            else if (itemType == ItemType.documentImageOnly)
            {
                Debug.Log("documentImageOnly");
            }
            else if (itemType == ItemType.documentTextAndImage)
            {
                Debug.Log("documentTextAndImage");
            }
            else if (itemType == ItemType.documentImageFull)
            {
                Debug.Log("documentImageFull");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        checkCollision();
    }
}
