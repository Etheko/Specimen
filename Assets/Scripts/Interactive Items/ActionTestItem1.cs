using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTestItem1 : ScriptableObject, InteractiveItemBase
{

    public bool UseItem()
    {
        Debug.Log("You used Action Test Item 1!");
        return true;
    }
}
