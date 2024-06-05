using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Fire Arm", menuName = "Scriptable Objects")]
public class FireArmScriptableObject : WeaponScriptableObject
{
    [Header("Fire Arm Information")]
    public bool singleFire;         // Is this fire arm single fire weapon?
    public bool burstFire;          // Is this fire arm burst fire weapon?
    public bool automaticFire;      // Is this fire arm automatic fire weapon?

    [Header("Magazine Information")]
    public int magCapacity;         // Maximum ammo in magazine
    public int magCurrently;        // Currently amount of ammo in magazine
    public float reloadTime;        // Reload time in seconds
    public GameObject bulletPrefab;

    public void FireWeapon()
    {
        Debug.Log("Firing weapon");
    }

    public void ReloadWeapon()
    {
        Debug.Log("Reload weapon");
    }
}
