using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    #region Initialization
    
    // Define UIManager instance
    public static UIManager instance;

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


    #region ScenesManagement

    // Method to load Loading Scene
    public void Loading()
    {
        SceneManager.LoadScene("Loading");
    }

    // Method to load Test Asset Bundle Scene
    public void TestAssetBundle()
    {
        SceneManager.LoadScene("Test Asset Bundle");
    }

    // Method to load Intro Scene
    public void Intro()
    {
        SceneManager.LoadScene("Intro");
    }

    // Method to load Main Scene
    public void Main()
    {
        SceneManager.LoadScene("Main");
    }

    // Method to load Settings Scene
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }

    // Method to load Support Scene
    public void Support()
    {
        SceneManager.LoadScene("Support");
    }

    // Method to load Map Scene
    public void Map()
    {
        SceneManager.LoadScene("Map");
    }

    // Method to load Inbox Scene
    public void Inbox()
    {
        SceneManager.LoadScene("Inbox");
    }

    // Method to load Leaderboard Scene
    public void Leaderboard()
    {
        SceneManager.LoadScene("Leaderboard");
    }

    // Method to load Alliance Scene
    public void Alliance()
    {
        SceneManager.LoadScene("Alliance");
    }

    // Method to load BattlePass Scene
    public void BattlePass()
    {
        SceneManager.LoadScene("BattlePass");
    }

    // Method to load ViewAds Scene
    public void ViewAds()
    {
        SceneManager.LoadScene("ViewAds");
    }

    // Method to load Offers Scene
    public void Offers()
    {
        SceneManager.LoadScene("Offers");
    }

    // Method to load Shop Scene
    public void Shop()
    {
        SceneManager.LoadScene("Shop");
    }

    // Method to load Missions Scene
    public void Missions()
    {
        SceneManager.LoadScene("Missions");
    }

    // Method to load Profile Scene
    public void Profile()
    {
        SceneManager.LoadScene("Profile");
    }

    // Method to load DailyShop Scene
    public void DailyShop()
    {
        SceneManager.LoadScene("DailyShop");
    }

    // Method to load EventsScene
    public void Events()
    {
        SceneManager.LoadScene("Events");
    }

    // Method to load Inventory Scene
    public void Inventory()
    {
        SceneManager.LoadScene("Inventory");
    }

    // Method to load Inventory Scene
    public void Club()
    {
        SceneManager.LoadScene("Club");
    }

    #endregion
}
