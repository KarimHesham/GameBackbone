using System.Collections;
using UnityEngine;

public class Splash : MonoBehaviour
{
    #region Initialization

    // Variable for defining splash screen time & switching to next scene after
    public float delay = 2;

    #endregion


    #region Functionality

    #region Methods

    // Start is called before the first frame update
    void Start()
    {
        // Call initialize localization method to load appropriate localization text file
        InitLocalization();
        // Call switch screen method to switch to next scene after delay time
        SwitchScreenAfterDelay(delay);
    }

    // Method for calling LoadNextScene coroutine
    void SwitchScreenAfterDelay(float delay)
    {
        StartCoroutine(LoadNextScene(delay));
    }

    // Method for initializing localization text file
    public void InitLocalization()
    {
        Utility.instance.LocalizeApp();
    }

    #endregion

    
    #region Coroutines

    // Coroutine for managing splash screen time and switching to the next scene
    private IEnumerator LoadNextScene(float delay)
    {   
        // Wait for specified delay time
        yield return new WaitForSeconds(delay);
        // Check if localization is initialized
        if(!Utility.instance.isLocalized)
        {
            // Wait until localization is initialized
            yield return new WaitUntil(predicate: () => Utility.instance.isLocalized);
        }
        // Call UIManager to load Loading Scene
        UIManager.instance.Loading();
    }

    #endregion

    #endregion
}
