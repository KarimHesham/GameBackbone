using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "One Time Purchase Object", menuName = "Inventory System/Items/One Time Purchase")]
public class OneTimePurchaseObject : ItemObject
{
    public void Awake()
    {
        type = ItemType.OneTime;
    }
}
