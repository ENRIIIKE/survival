using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;
    
    public bool AddItem(ItemScriptableObject item)
    {
        for (int i = 0; 1 < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponent<InventoryItem>();
            if (itemInSlot != null && itemInSlot.itemSo == item && 
                itemInSlot.itemCount < item.maximumInOneStack && itemInSlot.itemSo.itemIsStackable)
            {
                itemInSlot.itemCount++;
                itemInSlot.RefreshCount();
                return true;
            }
        }
        
        for (int i = 0; 1 < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponent<InventoryItem>();
            if (itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                return true;
            }
        }

        return false;
    }

    void SpawnNewItem(ItemScriptableObject item, InventorySlot slot)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }
}
