using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScriptableObject : ItemScriptableObject
{
    [Header("Weapon information")]
    public int weaponDamage;            // Attack damage to entities
    public float weaponAttackSpeed;     // Attack speed in seconds
}
