using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireArmScript : MonoBehaviour
{
    public FireArmScriptableObject weaponSO;
    private PlayerInputActions _playerInput;
    private InputAction _action;

    private float _fireCooldown;
    private bool _coroutinePerforming;
    private void Awake()
    {
        _playerInput = new PlayerInputActions();
    }

    private void OnEnable()
    {
        _action = _playerInput.ItemMap.ItemUse;
        _action.Enable();

        _playerInput.ItemMap.ItemUse.performed += OnUse;
        _playerInput.ItemMap.ReloadWeapon.performed += OnReload;
    }
    private void OnDisable()
    {
        _action.Disable();

        _playerInput.ItemMap.ItemUse.performed -= OnUse;
        _playerInput.ItemMap.ReloadWeapon.performed -= OnReload;
    }

    private void OnUse(InputAction.CallbackContext context)
    {
        if (Time.time > _fireCooldown)
        {
            _fireCooldown = weaponSO.weaponAttackSpeed + Time.time;
            FireWeapon();
        }
    }
    private void OnReload(InputAction.CallbackContext context)
    {
        ReloadWeapon();
    }

    private void FireWeapon()
    {
        Debug.Log("Weapon fired");
    }

    private void ReloadWeapon()
    {
        StartCoroutine(ReloadTimer());
    }

    private IEnumerator ReloadTimer()
    {
        if (_coroutinePerforming)
        {
            yield break;
        }
        _coroutinePerforming = true;

        yield return new WaitForSecondsRealtime(weaponSO.reloadTime);
        Debug.Log("Weapon has been reloaded");

        _coroutinePerforming = false;
    }
}
