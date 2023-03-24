using System.Collections;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class Utility : MonoBehaviour
{
    #region Declaration

    // Defining Utility instance to be called by other scripts
    public static Utility instance;

    // Define flag to check if localization is initialized
    public bool isLocalized;

    #endregion


    #region Initialization

    // Initialize Utility class instance
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

    #endregion


    #region Functionality

    #region Methods

    // Method for calling InitializeLocalization coroutine
    public void LocalizeApp()
    {
        StartCoroutine(InitializeLocalization());
    }
    // Method for calling CheckInternetConnection coroutine
    public void CheckNetworkConnection()
    {
        StartCoroutine(CheckInternetConnection());
    }

    // Method for calling CheckVersion coroutine
    public void CheckVersion()
    {
        StartCoroutine(CheckVersions());
    }

    // Method for calling CheckAppVersion coroutine
    public void AppVersionCheck()
    {
        StartCoroutine(CheckAppVersion());
    }

    // Method for calling CheckAssetsVersion coroutine
    public void AssetsVersionCheck()
    {
        StartCoroutine(CheckAssetsVersion());
    }

    #endregion


    #region Coroutines

    // Coroutine to initialize Localization inside app
    private IEnumerator InitializeLocalization()
    {
        string activeLanguage = DataManager.instance.GetLanguage();

        var operation = LocalizationSettings.InitializationOperation;

        if (!operation.IsDone)
            yield return new WaitUntil(predicate: () => operation.IsDone);

        switch (activeLanguage)
        {
            case "en":
                LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
                isLocalized = true;
                break;
            case "ar":
                LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[1];           
                isLocalized = true;
                break;
            case "es":
                LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[2];                
                isLocalized = true;
                break;
            default:
                LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
                isLocalized = true;
                break;
        }
        if (!isLocalized)
        {
            yield return new WaitUntil(predicate: () => isLocalized);
        }
    }

    // Coroutine to initiate CheckInternetConnection logic
    private IEnumerator CheckInternetConnection()
    {
        // Call APIManager to initiate CheckNetworkConnection request
        APIManager.instance.CheckInternetConnection();
        // While CheckInternet request is not complete
        while(!APIManager.RequestManager.CheckInternet)
        {
            // Wait until CheckInternet request is omplete
            yield return new WaitUntil(predicate: () => APIManager.RequestManager.CheckInternet);
        }
        // Check internetAvailable flag inside APIManager
        if(APIManager.GameInfo.isInternetAvailable)     // If internet is available
        {
            // Check network type
            switch (Application.internetReachability)
            {
                case NetworkReachability.NotReachable:
                    APIManager.GameInfo.NetworkConnectionType = "No Internet";
                    break;

                case NetworkReachability.ReachableViaCarrierDataNetwork:
                    APIManager.GameInfo.NetworkConnectionType = "Carrier";
                    break;

                case NetworkReachability.ReachableViaLocalAreaNetwork:
                    APIManager.GameInfo.NetworkConnectionType = "LAN";
                    break;
            }

            Debug.Log("Netowrk Type: " + APIManager.GameInfo.NetworkConnectionType);
        }
    }

    // Coroutine to initiate CheckAppVersion logic
    private IEnumerator CheckVersions()
    {
        // Call APIManager to initiate a request to get app version from server
        APIManager.instance.CheckVersion();

        // If GetAppVersion request is not complete
        while (!APIManager.RequestManager.CheckVersion)
        {
            // Wait until GetAppVersion request is complete
            yield return new WaitUntil(predicate: () => APIManager.RequestManager.CheckVersion);
        }

        // If Check version response is successful
        if (APIManager.ResponseManager.CheckVersion)
        {
            // Check user app version vs latest version
            AppVersionCheck();
        }
    }

    // Coroutine to intiate check app version logic
    private IEnumerator CheckAppVersion()
    {
        // If check version response is not successful
        while (!APIManager.ResponseManager.CheckVersion)
        {
            // Wait until check version response is successful
            yield return new WaitUntil(predicate: () => APIManager.ResponseManager.CheckVersion);
        }

         // If user has latest app version
         if (DataManager.instance.GetAppVersion() == APIManager.GameInfo.AppVersion)
         {
            // Validate that user app version matches latest version
            APIManager.DataValidator.IsAppUpToDate = true;
         }
     
        // Run assets version check
        AssetsVersionCheck();
    }

    // Coroutine to initiate check assets version logic
    private IEnumerator CheckAssetsVersion()
    {  
        // If app version matching is not validated
        while (!APIManager.ResponseManager.CheckVersion)
        {
            // Wait for app version matching validation
            yield return new WaitUntil(predicate: () => APIManager.ResponseManager.CheckVersion);
        }

        // If user has latest assets version
        if (DataManager.instance.GetAssetsVersion() == APIManager.GameInfo.AssetsVersion)
        {
            // Set assets validation flag inside APIManager to true
            APIManager.DataValidator.AreAssetsUpToDate = true;
        }
        
        // Set version checks flag to true inside APIManager
        APIManager.DataValidator.IsVersionChecked = true;
    }

    #endregion

    #endregion
}
