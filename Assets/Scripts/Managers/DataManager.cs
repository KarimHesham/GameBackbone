using UnityEngine;

public class DataManager : MonoBehaviour
{
    #region Declaration

    // Define DataManager instance
    public static DataManager instance;

    // Enum to represent DataStore flag possible values
    public enum DataStore
    {
        PlayerPrefs,
        Sqlite,
    }

    // Flag to hold active DataStore type
    private readonly DataStore activeDataStore;

    #endregion


    #region Initialization

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
    }

    #endregion


    #region Functionality

    // Method to set that user opened app for first time
    public void SetFirst(int isFirst)
    {
        switch (activeDataStore)
        {
            case DataStore.PlayerPrefs:
                {
                    PlayerPrefs.SetInt("IsFirst", isFirst);
                    PlayerPrefs.Save();
                }
                break;
            case DataStore.Sqlite:
                {
                    // Set value using Sqlite
                }
                break;
        }
    }

    // Method to set user app version inside local storage
    public void SetAppVersion(string version)
    {
        switch(activeDataStore)
        {
            case DataStore.PlayerPrefs:
                {
                    PlayerPrefs.SetString("AppVersion", version);
                    PlayerPrefs.Save();
                }
                break;
            case DataStore.Sqlite:
                {
                    // Set value using Sqlite
                }
                break;
        }
    }

    // Method to set user assets version inside local storage
    public void SetAssetsVersion(string version)
    {
        switch (activeDataStore)
        {
            case DataStore.PlayerPrefs:
                {
                    PlayerPrefs.SetString("AssetsVersion", version);
                    PlayerPrefs.Save();
                }
                break;
            case DataStore.Sqlite:
                {
                    // Set value using Sqlite
                }
                break;
        }
    }

    // Method to set sound preference inside local storage
    public void SetSoundPref(int sound)
    {
        switch (activeDataStore)
        {
            case DataStore.PlayerPrefs:
                {
                    PlayerPrefs.SetInt("Sound", sound);
                    PlayerPrefs.Save();
                }
                break;
            case DataStore.Sqlite:
                {
                    // Set value using Sqlite
                }
                break;
        }
    }

    // Method to set notifications preference inside local storage
    public void SetNotifications(int notifications)
    {
        switch (activeDataStore)
        {
            case DataStore.PlayerPrefs:
                {
                    PlayerPrefs.SetInt("Notifications", notifications);
                    PlayerPrefs.Save();
                }
                break;
            case DataStore.Sqlite:
                {
                    // Set value using Sqlite
                }
                break;
        }
    }

    // Method to set language preference inside local storage
    public void SetLanguage(string language)
    {
        switch (activeDataStore)
        {
            case DataStore.PlayerPrefs:
                {
                    PlayerPrefs.SetString("Language", language);
                    PlayerPrefs.Save();
                }
                break;
            case DataStore.Sqlite:
                {
                    // Set value using Sqlite
                }
                break;
        }
    }

    // Method to get if user is first time using app from local storage
    public int GetIsFirst()
    {
        int isFirst = 0;

        switch (activeDataStore)
        {
            case DataStore.PlayerPrefs:
                {
                    isFirst = PlayerPrefs.GetInt("IsFirst");
                }
                break;
            case DataStore.Sqlite:
                {
                    // Set value using Sqlite
                }
                break;
        }

        return isFirst;
    }

    // Method to get and return user app version from local storage
    public string GetAppVersion()
    {
        string version = null;

        switch (activeDataStore)
        {
            case DataStore.PlayerPrefs:
                {
                  version = PlayerPrefs.GetString("AppVersion");
                }
                break;
            case DataStore.Sqlite:
                {
                    // Set value using Sqlite
                }
                break;
        }
     
        return version;
    }

    // Method to get and return user assets version from local storage

    public string GetAssetsVersion()
    {
        string version = null;

        switch (activeDataStore)
        {
            case DataStore.PlayerPrefs:
                {
                   version = PlayerPrefs.GetString("AssetsVersion");
                }
                break;
            case DataStore.Sqlite:
                {
                    // Set value using Sqlite
                }
                break;
        }
        return version;
    }

    // Method to get sound preference from local storage
    public int GetSoundPref()
    {
        int sound = 0;

        switch (activeDataStore)
        {
            case DataStore.PlayerPrefs:
                {
                    sound = PlayerPrefs.GetInt("Sound");
                }
                break;
            case DataStore.Sqlite:
                {
                    // Set value using Sqlite
                }
                break;
        }
        return sound;
    }

    // Method to get notifications preference from local storage
    public int GetNotifications()
    {
        int notifications = 0;

        switch (activeDataStore)
        {
            case DataStore.PlayerPrefs:
                {
                    notifications = PlayerPrefs.GetInt("Notifications");
                }
                break;
            case DataStore.Sqlite:
                {
                    // Set value using Sqlite
                }
                break;
        }
        return notifications;
    }

    // Method to get language preference from local storage
    public string GetLanguage()
    {
        string language = null;

        switch (activeDataStore)
        {
            case DataStore.PlayerPrefs:
                {
                    language = PlayerPrefs.GetString("Language");
                }
                break;
            case DataStore.Sqlite:
                {
                    // Set value using Sqlite
                }
                break;
        }

        return language;
    }

    #endregion
}
