using UnityEngine;

public class APIManager : MonoBehaviour
{
    #region Declaration

    // Defining APIManager instance
    public static APIManager instance;

    // Flag to check active backend implementation
    public enum Server
    {
        Firebase,
        Azure,
        AWS,
        WebApi
    }

    // Structure to handle request status
    public struct RequestManager
    {
        // Flag to check if CheckInternet request is complete
        public static bool CheckInternet;
        // Flag to check if CheckVersion request is complete
        public static bool CheckVersion;
        // Flag to check if GetAssetBundle request is complete
        public static bool GetAssetBundle;

    }

    // Structure to handle response status
    public struct ResponseManager
    {
        // Flag to check if CheckInternet response is successful
        public static bool CheckInternet;
        // Flag to check if CheckVersion response is successful
        public static bool CheckVersion;
        // Flag to check if GetAssetBundle response is successful
        public static bool GetAssetBundle;
    }

    // Structure to pass game info
    public struct GameInfo
    {
        // Variable to detect if network connection is available
        public static bool isInternetAvailable;
        // Variable to hold app version value retrieved from server
        public static string AppVersion;
        // Variable to hold assets version value retrieved from server
        public static string AssetsVersion;
        // Variable to hold network connection type
        public static string NetworkConnectionType;
    }

    // Structure to validate data
    public struct DataValidator
    {
        // Flag to check if app is updated to latest version
        public static bool IsAppUpToDate;
        // Flag to check if assets are updated to latest version
        public static bool AreAssetsUpToDate;
        // Flag to check if all version checks are complete
        public static bool IsVersionChecked;

        // Variable to store asset bundle download progress
        public static float AssetBundleDownloadProgress;

        // Variable to store asset bundle content
        public static UnityEngine.AssetBundle assetBundle;
    }

    #endregion


    #region Initialization

    // Initialize APIManager class instance
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

    // Flag to set active backend
    private readonly Server activeServer = Server.WebApi;

    #endregion


    #region Functionality

    // Method to call CheckInternetConnection method from active server
    public void CheckInternetConnection()
    {
        // Check active backend flag
        switch (activeServer)
        {
            case Server.Firebase:
                {
                    // Call Firebase SDK;
                }
                break;

            case Server.Azure:
                {
                    // Call Microsoft Azure SDK;
                }
                break;

            case Server.AWS:
                {
                    // Call Amazon Web Services SDK;
                }
                break;

            case Server.WebApi:
                {
                    // Call GetAppVersion from RestAPI
                    RestApi.instance.CheckInternetConnection();
                }
                break;
        }
    }

    // Method to call GetAppVersion method from active server
    public void CheckVersion()
    {
        // Check active backend flag
        switch (activeServer)
        {
            case Server.Firebase:
                {
                    // Call Firebase SDK;
                }
                break;

            case Server.Azure:
                {
                    // Call Microsoft Azure SDK;
                }
                break;

            case Server.AWS:
                {
                    // Call Amazon Web Services SDK;
                }
                break;

            case Server.WebApi:
                {
                    // Call GetAppVersion from RestAPI
                    RestApi.instance.CheckVersion();
                }
                break;
        }
    }

    public void DownloadAssetBundle()
    {
        // Check active backend flag
        switch (activeServer)
        {
            case Server.Firebase:
                {
                    // Call Firebase SDK;
                }
                break;

            case Server.Azure:
                {
                    // Call Microsoft Azure SDK;
                }
                break;

            case Server.AWS:
                {
                    // Call Amazon Web Services SDK;
                }
                break;

            case Server.WebApi:
                {
                    // Call DownloadAssetBundle from RestAPI
                    RestApi.instance.DownloadAssetBundle();
                }
                break;
        }
    }

    #endregion
}
