using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable", menuName = "Scriptable Objects/New Consumable")]

public class ConsumableScriptableObject : ItemScriptableObject
{
    [Header("Consumable Information")]
    public int feedHunger;
}
