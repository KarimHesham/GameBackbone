using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Unlimited Purchase Object", menuName = "Inventory System/Items/Unlimited Purchase")]
public class UnlimitedPurchaseObject :ItemObject
{
    public void Awake()
    {
        type = ItemType.Unlimited;
    }
}
