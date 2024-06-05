using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScriptableObject : ScriptableObject
{
    [Header("General Information")]
    public int weaponID;                // Weapon ID for loot system???
    public string weaponName;           // Specify weapon name

    [Header("Specific information")]
    public int weaponDamage;            //Attack damage to entities
    public float weaponAttackSpeed;     //Attack speed in seconds

    public void WeaponAction()
    {
        Debug.Log("Weapon has been used");
    }

}
