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

    private int selectedSlot = -1;
    private void Start()
    {
        ChangeSelectedSlot(0);
    }
    void ChangeSelectedSlot(int newValue)
    {
        if (selectedSlot >= 0)
        {
            inventorySlots[selectedSlot].DeSelect();
        }
        inventorySlots[newValue].Select();
        selectedSlot = newValue;
    }

    private void Awake()
    {
        _playerInput = new PlayerInputActions();
    }

    private void OnEnable()
    {
        _playerInput.UIMap.OpenInventory.performed += OnInventoryAction;
        _playerInput.UIMap.OpenInventory.Enable();

        _playerInput.PlayerMap.EquipFirst.performed += UpdateFirstSlot;
        _playerInput.PlayerMap.EquipFirst.Enable();

        _playerInput.PlayerMap.EquipSecond.performed += UpdateSecondSlot;
        _playerInput.PlayerMap.EquipSecond.Enable();

        _playerInput.PlayerMap.EquipThird.performed += UpdateThirdSlot;
        _playerInput.PlayerMap.EquipThird.Enable();
    }
    private void OnDisable()
    {
        _playerInput.UIMap.OpenInventory.performed -= OnInventoryAction;
        _playerInput.UIMap.OpenInventory.Disable();

        _playerInput.PlayerMap.EquipFirst.performed -= UpdateFirstSlot;
        _playerInput.PlayerMap.EquipFirst.Disable();

        _playerInput.PlayerMap.EquipSecond.performed -= UpdateSecondSlot;
        _playerInput.PlayerMap.EquipSecond.Disable();

        _playerInput.PlayerMap.EquipThird.performed -= UpdateThirdSlot;
        _playerInput.PlayerMap.EquipThird.Disable();
    }
    #region SelectedSlot
    private void UpdateFirstSlot(InputAction.CallbackContext context)
    {
        ChangeSelectedSlot(0);
    }
    private void UpdateSecondSlot(InputAction.CallbackContext context)
    {
        ChangeSelectedSlot(1);
    }
    private void UpdateThirdSlot(InputAction.CallbackContext context)
    {
        ChangeSelectedSlot(2);
    }
    #endregion
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
