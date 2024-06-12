using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Fire Arm", menuName = "Scriptable Objects/New Fire Arm")]
public class FireArmScriptableObject : ItemScriptableObject
{
    [Header("Fire Arm Information")]
    public bool singleFire;         // Is this fire arm single fire weapon?
    public bool burstFire;          // Is this fire arm burst fire weapon?
    public bool automaticFire;      // Is this fire arm automatic fire weapon?

    public int weaponDamage;        // Attack damage to entities
    public float weaponAttackSpeed; // Attack speed in seconds

    [Header("Magazine Information")]
    public int magCapacity;         // Maximum ammo in magazine
    public int magCurrently;        // Currently amount of ammo in magazine
    public float reloadTime;        // Reload time in seconds
    public GameObject bulletPrefab;

    [Header("Holding in Hands")]
    public Sprite holdingSprite;

    [Header("Hands position")]
    public Vector2 leftHandPivot;
    public Vector2 rightHandPivot;

    public override void OnPrimaryAction()
    {
        Debug.Log("Fire");
    }

    public override void OnSecondaryAction()
    {
        throw new System.NotImplementedException();
    }


    public override float ReturnPrimaryValue()
    {
        return weaponAttackSpeed;
    }

    public override float ReturnSecondaryValue()
    {
        return reloadTime;
    }

}
