using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    public static User instance;
    public InventoryObject inventory;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void AddOneTimePurchase(Item item)
    {
        if(item)
        {
            inventory.AddItem(item.item, 1);
        }
    }

    public void AddMultiplePurchase(Item item)
    {
        if(item)
        {
            inventory.AddItem(item.item, 1);
        }
    }

    public void AddUnlimitedPurchase(Item item)
    {
        if(item)
        {
            inventory.AddItem(item.item, 1);
        }
    }

    public void AddSubscription(Item item)
    {
        if(item)
        {
            inventory.AddItem(item.item, 1);
        }
    }
}
