using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public ItemScriptableObject itemSo;
    public int itemCount = 1;
    
    [Header("UI")]
    public Image image;
    public TMP_Text countText;

    [HideInInspector] public Transform canvasTransform;
    [HideInInspector] public Transform parentAfterDrag;

    private void Awake()
    {
        canvasTransform = GameObject.Find("Canvas").transform;
    }
    public void InitialiseItem(ItemScriptableObject newItem)
    {
        itemSo = newItem;
        image.sprite = newItem.itemImage;
        RefreshCount();
    }

    public void RefreshCount()
    {
        countText.text = itemCount.ToString();
        bool textActive = itemCount > 1;
        countText.gameObject.SetActive(textActive);
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;

        parentAfterDrag = transform.parent;
        transform.SetParent(canvasTransform);
    }
    public void OnDrag(PointerEventData eventData) {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;

        transform.SetParent(parentAfterDrag);
    }
}