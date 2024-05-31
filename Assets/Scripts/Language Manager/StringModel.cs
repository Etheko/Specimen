using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StringModel
{
    public string key;
    public string en;
    public string es;
}

[System.Serializable]
public class LanguageDictionary
{
    public List<StringModel> textStrings;
}

[System.Serializable]
public class LanguageListItemModel
{
    public string code;
    public string name;
}

[System.Serializable]
public class LanguageSettingsModel
{
    public string defaultLanguage;
    public List<LanguageListItemModel> languages;
}

[System.Serializable]
public class Item
{
    public string id;
    public string imageID;
    public string descriptionID;
    public string action; //IInteractiveItemBase interface
}

[System.Serializable]
public class ItemListModel
{
   public List<Item> items;
}

[System.Serializable]
public class InventoryItem
{
    public string id;
}

[System.Serializable]
public class PlayerInventory
{
    public List<InventoryItem> playerItems;
}
