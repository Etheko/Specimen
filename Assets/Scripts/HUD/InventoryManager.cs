using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    const int INVENTORY_SIZE = 8;

    private LanguageManager languageManager;
    private GameObject inventory;

    private GameObject dialogsUIOverlay;
    private GameObject inventoryFrame;
    public static InventoryManager instance;
    private GameObject inventoryGrid;
    private GameObject inventorySelector;
    private GameObject itemDetails;
    private GameObject inventoryControls;

    private TextAsset itemsJSONFile;
    private Dictionary<string, Item> itemsDictionary = new Dictionary<string, Item>();


    private List<string> items;

    private PlayerInventory playerInventory;

    private int selectedItem = 0;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            inventory = instance.gameObject;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        assignObjects();
        loadData();
        itemsJSONFile = Resources.Load<TextAsset>("Text/items");
        loadItemList();
    }

    public void resetInventory()
    {
        playerInventory.playerItems.Clear();
        saveInventoryState();
    }

    private void assignObjects()
    {
        languageManager = GetComponent<LanguageManager>();
        languageManager.loadTexts();
        dialogsUIOverlay = GameObject.Find("Dialogs UI Overlay");
        if (dialogsUIOverlay != null)
        {
            inventoryFrame = dialogsUIOverlay.transform.Find("Inventory Frame").gameObject;
            inventoryGrid = inventoryFrame.transform.Find("Inventory Grid").gameObject;
            inventorySelector = inventoryFrame.transform.Find("Inventory Selector").gameObject;
            itemDetails = inventoryFrame.transform.Find("Item Details").gameObject;
            inventoryControls = inventoryFrame.transform.Find("Inventory Controls").gameObject;
        }
    }

    public void loadItemList() // Loads all the items on the game
    {
        var itemsList = JsonUtility.FromJson<ItemListModel>(itemsJSONFile.text);
        foreach (var item in itemsList.items)
        {
            this.itemsDictionary.Add(item.id, item);
        }
    }

    public void saveInventoryState()
    {
        //save the player's inventory to a JSON file
        string json = JsonUtility.ToJson(playerInventory);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/inventoryData.json", json);
    }

    private void loadItems() // Loads the player's inventory items from the JSON file
    {
        //run through all child objects of inventoryGrid and set their RawImage texture to the corresponding item image
        for (int i = 0; i < inventoryGrid.transform.childCount; i++)
        {
            if (i < playerInventory.playerItems.Count)
            {
                // alpha to 1
                inventoryGrid.transform.GetChild(i).GetComponent<RawImage>().color = new Color(1, 1, 1, 1);
                inventoryGrid.transform.GetChild(i).GetComponent<RawImage>().texture = Resources.Load<Texture>("Item Sprites/" + itemsDictionary[playerInventory.playerItems[i].id].imageID);
            }
            else
            {
                inventoryGrid.transform.GetChild(i).GetComponent<RawImage>().texture = null;
                // alpha to 0
                inventoryGrid.transform.GetChild(i).GetComponent<RawImage>().color = new Color(1, 1, 1, 0);
            }
        }
    }

    private void displayItemDetails()
    {
        itemDetails.transform.Find("Item Name").GetComponent<TMP_Text>().text = languageManager.getText(itemsDictionary[playerInventory.playerItems[selectedItem].id].id);
        itemDetails.transform.Find("Item Description").GetComponent<TMP_Text>().text = languageManager.getText(itemsDictionary[playerInventory.playerItems[selectedItem].id].descriptionID);
    }

    public void selectItem(int itemIndex)
    {
        selectedItem = itemIndex;
        GameObject selector = inventorySelector.transform.GetChild(selectedItem).gameObject;
        selector.SetActive(true);
        // if there is an item in the selected slot, display its details, otherwise clear the details
        if (selectedItem < playerInventory.playerItems.Count)
        {
            displayItemDetails();
        }
        else
        {
            itemDetails.transform.Find("Item Name").GetComponent<TMP_Text>().text = languageManager.getText("inventoryNothingText");
            itemDetails.transform.Find("Item Description").GetComponent<TMP_Text>().text = languageManager.getText("inventoryNothingDescription");
        }
    }

    public bool hasItem(string itemID)
    {
        return playerInventory.playerItems.Exists(x => x.id == itemID);
    }

    public void addItem(string itemID, bool hasDialog)
    {
        if (!hasItem(itemID))
        {

            if (playerInventory.playerItems.Count < INVENTORY_SIZE)
            {
                dialogsUIOverlay.GetComponent<DialogController>().showObtainedItemDialog(itemID, itemsDictionary[itemID].imageID);
                playerInventory.playerItems.Add(new InventoryItem { id = itemID });
                loadItems();
            }
            else
            {
                List<string> imageList = new List<string>();
                imageList.Add("NeruNeutral");
                dialogsUIOverlay.GetComponent<DialogController>().showDialog("inventoryFullText", imageList, false, "");
            }
        }
        else
        {
            List<string> imageList = new List<string>();
            imageList.Add("NeruNeutral");
            dialogsUIOverlay.GetComponent<DialogController>().showDialog("alreadyHaveItemText", imageList, false, "");
        }
    }


    public void removeItem()
    {
        if (playerInventory.playerItems.Count > 0)
        {
            playerInventory.playerItems.RemoveAt(selectedItem);
            loadItems();
        }
    }

    public void closeInventory()
    {
        inventoryFrame.SetActive(false);
    }

    public void selectRight()
    {
        if (selectedItem < INVENTORY_SIZE - 1)
        {
            inventorySelector.transform.GetChild(selectedItem).gameObject.SetActive(false);
            selectedItem++;
            selectItem(selectedItem);
        }
    }

    public void selectLeft()
    {
        if (selectedItem > 0)
        {
            inventorySelector.transform.GetChild(selectedItem).gameObject.SetActive(false);
            selectedItem--;
            selectItem(selectedItem);
        }
    }

    public string useItem() // Returns the ID of the selected item so it can be used in the game
    {
        return itemsDictionary[playerInventory.playerItems[selectedItem].id].id;
    }

    public void showInventory()
    {
        if (GameObject.Find("In Game UI").transform.Find("Main UI Overlay").gameObject.activeSelf)
        {
            return;
        }
        inventoryFrame.SetActive(true);
        loadItems();
        selectItem(0);
        for (int i = 0; i < INVENTORY_SIZE; i++)
        {
            inventorySelector.transform.GetChild(i).gameObject.SetActive(false);
        }
        inventorySelector.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void loadData()
    {
        if (!File.Exists(Application.persistentDataPath + "/inventoryData.json"))
        {
            playerInventory = new PlayerInventory();
            playerInventory.playerItems = new List<InventoryItem>();
            saveInventoryState();
        }
        playerInventory = JsonUtility.FromJson<PlayerInventory>(File.ReadAllText(Application.persistentDataPath + "/inventoryData.json"));
    }

    public void hideInventory()
    {
        inventoryFrame.SetActive(false);
        GameObject player = GameObject.Find("Player");
        player.GetComponent<PlayerController>().movementEnabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && dialogsUIOverlay != null)
        {
            if (inventoryFrame.activeSelf)
            {
                selectLeft();
            }
        }
        else if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && dialogsUIOverlay != null)
        {
            if (inventoryFrame.activeSelf)
            {
                selectRight();
            }
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            assignObjects();
            if (dialogsUIOverlay == null)
            {
                return;
            }
            if (inventoryFrame.activeSelf)
            {
                hideInventory();
            }
            else
            {
                GameObject player = GameObject.Find("Player");
                player.GetComponent<PlayerController>().movementEnabled = false;
                showInventory();
            }
        }

    }
}
