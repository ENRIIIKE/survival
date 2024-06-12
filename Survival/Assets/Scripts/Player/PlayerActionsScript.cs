using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerActionsScript : MonoBehaviour
{
    [Header("Script references")]
    public PlayerInputActions playerInput;
    public ItemScriptableObject activeItem;

    [Header("Transform references")]
    public Transform activeItemTransform;

    private bool _holdPrimary;
    private float _primaryCooldown, _activePrimaryCooldown;

    private bool _holdSecondary;
    private float _secondaryCooldown, _activeSecondaryCooldown;

    private void Awake()
    {
        playerInput = new PlayerInputActions();
    }

    private void OnEnable()
    {
        playerInput.PlayerMap.ItemUse.Enable();
        playerInput.PlayerMap.ReloadWeapon.Enable();
    }
    private void OnDisable()
    {
        playerInput.PlayerMap.ItemUse.Disable();
        playerInput.PlayerMap.ReloadWeapon.Disable();

    }

    public void RefreshActionValues()
    {
        _primaryCooldown = activeItem.ReturnPrimaryValue();
        _secondaryCooldown = activeItem.ReturnSecondaryValue();
    }

    //This script is fucked up.. I need something more universal..................................................

    private void Update()
    {
        _holdPrimary = playerInput.PlayerMap.ItemUse.IsPressed();

        if (_holdPrimary)
        {
            if (Time.time > _activePrimaryCooldown)
            {
                activeItem.OnPrimaryAction();
                _activePrimaryCooldown = Time.time + _primaryCooldown;
            }
        }

        // Rotate weapon towards mouse
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = new Vector2(activeItemTransform.position.x - mousePosition.x, activeItemTransform.position.y - mousePosition.y);

        activeItemTransform.transform.right = -direction;
    }
}