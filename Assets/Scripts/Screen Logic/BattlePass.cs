using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePass : MonoBehaviour
{
    // Method to handle back button click logic
    public void BackButton()
    {
        UIManager.instance.Main();
    }
}
