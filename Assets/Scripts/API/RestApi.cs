using Newtonsoft.Json;
using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class RestApi : MonoBehaviour
{
    #region Declaration

    // Define RestApi instance to be called by other scripts
    public static RestApi instance;

    // Class to store GameInfo data that is received as responses from server calls
    [Serializable]
    public class GameInfo
    {
        public string appVersion;
        public string assetsVersion;
    }

    #endregion


    #region Initialization

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

    // Method to call web server to check internet connection
    public void CheckInternetConnection()
    {
        string uri = "http://waleedbaz-002-site2.htempurl.com/Webservices/api/checkconnection";
        StartCoroutine(GetInternetConnection(uri));
    }

    // Method to call web server and get latest app version result
    public void CheckVersion()
    {
        string uri = "http://waleedbaz-002-site2.htempurl.com/Webservices/api/gameinfo/0";
        StartCoroutine(GetVersion(uri));
    }

    // Method to call web server and download asset bundle
    public void DownloadAssetBundle()
    {
        string uri = "http://waleedbaz-002-site2.htempurl.com/Assets/Bundle/testbundle.unity3d";
        StartCoroutine(GetAssetBundle(uri));
    }

    #endregion


    #region Coroutines

    // Coroutine to initiate CheckInternetConnection request logic
    private IEnumerator GetInternetConnection(string uri)
    {
        using UnityWebRequest webRequest = UnityWebRequest.Get(uri);

        yield return webRequest.SendWebRequest();

        switch (webRequest.result)
        {
            case UnityWebRequest.Result.ConnectionError:
                // Log error in console
                Debug.LogError("Error:" + webRequest.error);
                break;
            // If data processing error occurred
            case UnityWebRequest.Result.DataProcessingError:
                // Log error in console
                Debug.LogError("Error:" + webRequest.error);
                break;
            // If protocol error occurred
            case UnityWebRequest.Result.ProtocolError:
                // Log error in console
                Debug.LogError("Error: " + webRequest.error);
                break;
            // If request received successful response
            case UnityWebRequest.Result.Success:
                string response = System.Text.Encoding.UTF8.GetString(webRequest.downloadHandler.data);
                bool internet = Convert.ToBoolean(response);
                Debug.Log(internet);
                APIManager.GameInfo.isInternetAvailable = internet;
                APIManager.ResponseManager.CheckInternet = true;
                break;
        }

        // Set CheckInternet request flag inside APIManager to true
        APIManager.RequestManager.CheckInternet = true;
    }

    // Coroutine to initiate GetAppVersion request logic
    private IEnumerator GetVersion(string uri)
    {
        using UnityWebRequest webRequest = UnityWebRequest.Get(uri);

        // Request and wait for the desired page.
        yield return webRequest.SendWebRequest();

        yield return new WaitUntil(predicate: () => webRequest.isDone);

        // Check request result
        switch (webRequest.result)
        {
            // If connection error occurred
            case UnityWebRequest.Result.ConnectionError:
                // Log error in console
                Debug.LogError("Error:" + webRequest.error);
                break;
            // If data processing error occurred
            case UnityWebRequest.Result.DataProcessingError:
                // Log error in console
                Debug.LogError("Error:" + webRequest.error);
                break;
            // If protocol error occurred
            case UnityWebRequest.Result.ProtocolError:
                // Log error in console
                Debug.LogError("Error: " + webRequest.error);
                break;
            // If request received successful response
            case UnityWebRequest.Result.Success:
                // Assign received response value to GameInfo class inside APIManager
                string response = System.Text.Encoding.UTF8.GetString(webRequest.downloadHandler.data);
                // Deserialize response into GameInfo object
                GameInfo info = JsonConvert.DeserializeObject<GameInfo>(response);

                // Set retrieved values for app version and asset version to corresponding variables inside APIManager
                APIManager.GameInfo.AppVersion = info.appVersion;
                APIManager.GameInfo.AssetsVersion = info.assetsVersion;

                // Set GetAppVersionResponse flag to true inside APIManager
                APIManager.ResponseManager.CheckVersion = true;
                break;
        }

        // Set GetAppVersion request flag to true inside APIManager
        APIManager.RequestManager.CheckVersion = true;
    }

    // Coroutine to initate GetAssetBundle request
    private IEnumerator GetAssetBundle(string uri)
    {
        string url = uri;
        using (var webRequest = new UnityWebRequest(url, UnityWebRequest.kHttpVerbGET))
        {
            webRequest.downloadHandler = new DownloadHandlerAssetBundle(url, 1, 0);
            yield return webRequest.SendWebRequest();
            UnityEngine.AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(webRequest);

            // Check request result
            switch (webRequest.result)
            {
                // If connection error occurred
                case UnityWebRequest.Result.ConnectionError:
                    // Log error in console
                    Debug.LogError("Error:" + webRequest.error);
                    break;
                // If data processing error occurred
                case UnityWebRequest.Result.DataProcessingError:
                    // Log error in console
                    Debug.LogError("Error:" + webRequest.error);
                    break;
                // If protocol error occurred
                case UnityWebRequest.Result.ProtocolError:
                    // Log error in console
                    Debug.LogError("Error: " + webRequest.error);
                    break;
                // If request received successful response
                case UnityWebRequest.Result.Success:
                    Debug.Log("Asset Request Successfull!");
                    // Extract asset bundle from the request content
                    bundle = UnityEngine.Networking.DownloadHandlerAssetBundle.GetContent(webRequest);

                    // Set value to GetAssetBundle response flag to true inside APIManager
                    APIManager.ResponseManager.GetAssetBundle = true;
                 
                    // Set asset bundle to bundle inside APIManager
                    APIManager.DataValidator.assetBundle = bundle;
                    APIManager.DataValidator.AreAssetsUpToDate = true;           
                    break;
            }

            APIManager.RequestManager.GetAssetBundle = true;
        }
    }

    #endregion

    #endregion
}
