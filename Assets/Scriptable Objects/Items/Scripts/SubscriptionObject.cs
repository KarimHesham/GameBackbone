using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Subscription Object", menuName = "Inventory System/Items/Subscription")]
public class SubscriptionObject : ItemObject
{
    public void Awake()
    {
        type = ItemType.Subscription;
    }
}
