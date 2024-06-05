using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemScriptableObject : ScriptableObject
{
    [Header("General Information")]
    public int itemID;                  // Item ID for loot system???
    public string itemName;             // Specify item name
    public string itemDescription;      // Item description, including item usage


    public abstract void UseItem();
}
