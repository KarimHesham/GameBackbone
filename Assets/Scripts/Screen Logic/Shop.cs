using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Button OneTimePurchaseButton;
    public Button MultipleTimePurchaseButton;
    public Button UnlimitedPurchaseButton;
    public Button SubscriptionButton;
    // Method to handle back button click logic
    public void BackButton()
    {
        UIManager.instance.Main();
    }

    public void OneTimePurchase()
    {
        var item = OneTimePurchaseButton.GetComponent<Item>();

        User.instance.AddOneTimePurchase(item);
    }

    public void MultipleTimePurchase()
    {
        var item = MultipleTimePurchaseButton.GetComponent<Item>();

        User.instance.AddMultiplePurchase(item);
    }

    public void UnlimitedPurchase()
    {
        var item = UnlimitedPurchaseButton.GetComponent<Item>();

        User.instance.AddUnlimitedPurchase(item);
    }

    public void Subscription()
    {
        var item = SubscriptionButton.GetComponent<Item>();

        User.instance.AddSubscription(item);
    }
}
