using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable", menuName = "Scriptable Objects/New Consumable")]

public class ConsumableScriptableObject : ItemScriptableObject
{
    [Header("Consumable Information")]
    public int feedHunger;

    public override void OnPrimaryAction()
    {
        throw new System.NotImplementedException();
    }
    public override void OnSecondaryAction()
    {
        throw new System.NotImplementedException();
    }

    public override float ReturnPrimaryValue()
    {
        throw new System.NotImplementedException();
    }

    public override float ReturnSecondaryValue()
    {
        throw new System.NotImplementedException();
    }
}