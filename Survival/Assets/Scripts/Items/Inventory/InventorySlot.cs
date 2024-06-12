using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public Image image;
    public Color selectedColor, deSelectedColor;

    public bool isEquipSlot;

    void Awake()
    {
        if (!isEquipSlot)
        {
            Select();
        }
        else
        {
            DeSelect();
        }
    }
    public void Select()
    {
        image.color = selectedColor;
    }
    public void DeSelect()
    {
        image.color = deSelectedColor;
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            inventoryItem.parentAfterDrag = transform;

            if (isEquipSlot)
            {

            }
        }
    }
}
