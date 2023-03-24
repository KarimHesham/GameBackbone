using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    #region Declaration

    #region UIObjects

    public TextMeshProUGUI AppVersionText;
    public TextMeshProUGUI DownloadAssetsProgress;
    public GameObject CheckNetworkNotifier;
    public GameObject UpdateAppAlert;
    public GameObject DownloadAssetsAlert;
    public GameObject DownloadAssetsNotifier;
    public GameObject UpdateAppNotifier;
    public GameObject NoNetworkAlert;
    public GameObject ProceedButton;

    #endregion

    #endregion


    #region Behaviour

    // Start is called before the first frame update
    void Start()
    {
        // Check user app version and display it on screen
        SetAppVersionText();

        // Manage screen time and switch to next scene
        SwitchSceneAfterLoading();
    }

    #endregion


    #region Functionality

    #region Methods

    // Method to switch scene when proceed button is clicked
    public void OnProceedButton()
    {
        // Check if user is first time using the app
        if (DataManager.instance.GetIsFirst() == 0)
        {
            // Call DataManager to set isFirst inside player pref to false
            DataManager.instance.SetFirst(1);
            // Call UIManager to load Intro Scene
            UIManager.instance.Intro();
        }
        else
        {
            // Call UIManager to load Main Scene
            UIManager.instance.Main();
        }
        
    }

    // Method to detect app version and assign the value to app version text gameobject
    public void SetAppVersionText()
    {
        // Retrieve app version from settings and display it on screen
        AppVersionText.text = "Version " + Application.version;
    }

    // Method to initate check network process
    public void CheckNetwork()
    {
        // Call utility class to trigger CheckNetworkConnection method
        Utility.instance.CheckNetworkConnection();
        NoNetworkAlert.SetActive(false);
    }
    // Method to disable UpdateAppAlert when later button is clicked
    public void SetUpdateAppAlert(bool active)
    {
        UpdateAppAlert.SetActive(active);
    }

    // Method to disable UpdateAssetsAlert when later button is clicked
    public void SetUpdateAssetsAlert(bool active)
    {
        DownloadAssetsAlert.SetActive(active);
    }
    
    // Method to initiate update app version process
    public void UpdateAppVersion()
    {
        StartCoroutine(UpdateApp());
    }

    // Method to check if user's app and assets versions match latest version
    public void CheckVersion()
    {
        // Call CheckVersions coroutine
        StartCoroutine(CheckVersions());
    }  

    // Method to download asset bundle
    public void LoadAssetBundle()
    {
        StartCoroutine(DownloadAssetBundle());
    }

    // Method to load Intro Scene after loading is complete
    public void SwitchSceneAfterLoading()
    {
        // Call SwitchScene coroutine
        StartCoroutine(SwitchScene());
    }

    #endregion


    #region Coroutines 

    // Coroutine to start check version process
    private IEnumerator CheckVersions()
    {
        // Call utility class to make CheckNetworkConnection request
        CheckNetwork();

        while(!APIManager.RequestManager.CheckInternet)
        {
            CheckNetworkNotifier.SetActive(true);
            yield return new WaitUntil(predicate: () => APIManager.RequestManager.CheckInternet);
        }

        // If internet is not available
        if(!APIManager.GameInfo.isInternetAvailable)
        {
            // Remove network checking status from screen
            CheckNetworkNotifier.SetActive(false);
            // Display internet check alert on screen
            NoNetworkAlert.SetActive(true);
            // Wait until internet is available
            yield return new WaitUntil(predicate: () => APIManager.GameInfo.isInternetAvailable);      
        }

        // Hide internet check status
        CheckNetworkNotifier.SetActive(false);

        // Call utility class to make CheckVersion request from APIManager
        Utility.instance.CheckVersion();

        // If version checks are not complete
        while (!APIManager.DataValidator.IsVersionChecked)
        {
            // Wait until version checks are complete
            yield return new WaitUntil(predicate: () => APIManager.DataValidator.IsVersionChecked);
        }

        // If user app version does not match latest version
        if (!APIManager.DataValidator.IsAppUpToDate)
        {
            // Show update app alert
            SetUpdateAppAlert(true);

            yield return new WaitUntil(predicate: () => APIManager.DataValidator.IsAppUpToDate);

            if (!APIManager.DataValidator.AreAssetsUpToDate)    // If user assets version does not match latest assets version
            {
                // Show update assets alert
                SetUpdateAssetsAlert(true);

                yield return new WaitUntil(predicate: () => APIManager.DataValidator.AreAssetsUpToDate);
            }
        }          
            Debug.Log("Version Checked Successfully");
    }

    // Method to simulate updating app version from store
    private IEnumerator UpdateApp()
    {
        // Remove update app alert from screen
        UpdateAppAlert.SetActive(false);
        // Show updating app status pop up
        UpdateAppNotifier.SetActive(true);
        // Set app version value inside local storage
        DataManager.instance.SetAppVersion(APIManager.GameInfo.AppVersion);
        // Delay to simulate update process
        yield return new WaitForSeconds(3);
        // Remove updating app status from screen
        UpdateAppNotifier.SetActive(false);
        // Set IsAppUpToDate flag inside APIManager to true
        APIManager.DataValidator.IsAppUpToDate = true;
    }

    // Coroutine to handle Switching Scene
    private IEnumerator SwitchScene()
    {
        // Call check app version method to verify matching version between user device and latest release
        CheckVersion();

        // While isAppUpToDate flag is set to false
        if (!APIManager.DataValidator.IsAppUpToDate && !APIManager.DataValidator.AreAssetsUpToDate)
        {
            // Wait until isAppUpToDate flag is set to true
            yield return new WaitUntil(predicate: () => APIManager.DataValidator.IsAppUpToDate && APIManager.DataValidator.AreAssetsUpToDate);
        }

        // Show proceed button on screen
        ProceedButton.SetActive(true);
    }

    // Coroutine to handle downloading asset bundle
    private IEnumerator DownloadAssetBundle()
    {
        // Call APIManager to initiate GetAssetBundle request from RestApi
        APIManager.instance.DownloadAssetBundle();

        // Set UpdateAssetsAlert to false
        DownloadAssetsAlert.SetActive(false);

        // If GetAssetBundle request is not complete
        while (!APIManager.RequestManager.GetAssetBundle)
        {
            // Set DownloadAssetsPopUp to true
            DownloadAssetsNotifier.SetActive(true);

            // Wait until GetAssetBundle request is complete
            yield return new WaitUntil(predicate: () => APIManager.RequestManager.GetAssetBundle);
        }
        // If GetAssetBundle response was not Ok
        if(!APIManager.ResponseManager.GetAssetBundle)
        {
            // Log failure inside console
            Debug.LogError("LoadingScreen: Bundle Request Failed!");
        }
        
        // If asset bundle is downloaded successfully
        if(APIManager.DataValidator.AreAssetsUpToDate)
        {
            // Set assets version value inside APIManager
            DataManager.instance.SetAssetsVersion(APIManager.GameInfo.AssetsVersion);

            yield return new WaitForSeconds(0.5f);
            // Remove download assets pop up from screen
            DownloadAssetsNotifier.SetActive(false);
        }
    }

    #endregion

    #endregion
}
