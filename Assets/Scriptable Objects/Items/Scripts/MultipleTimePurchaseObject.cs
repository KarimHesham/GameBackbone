using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Multiple Time Purchase Object", menuName = "Inventory System/Items/Multiple Time Purchase")]
public class MultipleTimePurchaseObject : ItemObject
{
    public void Awake()
    {
        type = ItemType.Multiple;
    }
}
