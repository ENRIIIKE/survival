using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryManager : MonoBehaviour
{
    private PlayerInputActions _playerInput;
    
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;
    public GameObject inventoryUI;

    private void Awake()
    {
        _playerInput = new PlayerInputActions();
    }
    private void OnEnable()
    {
        _playerInput.UIMap.OpenInventory.performed += OnInventoryAction;
        _playerInput.UIMap.OpenInventory.Enable();
    }
    private void OnDisable()
    {
        _playerInput.UIMap.OpenInventory.performed -= OnInventoryAction;
        _playerInput.UIMap.OpenInventory.Disable();
    }
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

    void OnInventoryAction(InputAction.CallbackContext context)
    {
        Debug.Log("Inventory");
        bool isActive = inventoryUI.activeSelf;
        inventoryUI.SetActive(!isActive);
    }
}
