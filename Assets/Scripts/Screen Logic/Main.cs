using UnityEngine;

public class Main : MonoBehaviour
{
    #region Declaration

    #region UIObjects

    public AudioSource buttonSFX;

    #endregion

    #endregion


    #region Functionality

    private void Start()
    {
        MuteSound();
    }

    public void MuteSound()
    {
        if(DataManager.instance.GetSoundPref() == 0)
        {
            buttonSFX.mute = true;
        }
    }

    public void SoundOnClick()
    {
       buttonSFX.Play(); 
    }

    public void TestAssetsButton()
    {
        SoundOnClick();
        UIManager.instance.TestAssetBundle();
    }

    public void SettingsButton()
    {
        SoundOnClick();
        UIManager.instance.Settings();
    }

    public void SupportButton()
    {
        SoundOnClick();
        UIManager.instance.Support();
    }

    public void InventoryButton()
    {
        SoundOnClick();
        UIManager.instance.Inventory();
    }

    public void InboxButton()
    {
        SoundOnClick();
        UIManager.instance.Inbox();
    }

    public void AllianceButton()
    {
        SoundOnClick();
        UIManager.instance.Alliance();
    }
    public void BattlePassButton()
    {
        SoundOnClick();
        UIManager.instance.BattlePass();
    }

    public void EventsButton()
    {
        SoundOnClick();
        UIManager.instance.Events();
    }

    public void ShopButton()
    {
        SoundOnClick();
        UIManager.instance.Shop();
    }

    public void DailyShopButton()
    {
        SoundOnClick();
        UIManager.instance.DailyShop();
    }

    public void MapButton()
    {
        SoundOnClick();
        UIManager.instance.Map();
    }
    public void ClubButton()
    {
        SoundOnClick();
        UIManager.instance.Club();
    }

    public void ProfileButton()
    {
        SoundOnClick();
        UIManager.instance.Profile();
    }

    public void OffersButton()
    {
        SoundOnClick();
        UIManager.instance.Offers();
    }

    public void MissionsButton()
    {
        SoundOnClick();
        UIManager.instance.Missions();
    }

    public void LeaderboardButton()
    {
        SoundOnClick();
        UIManager.instance.Leaderboard();
    }

    public void ViewAdsButton()
    {
        SoundOnClick();
        UIManager.instance.ViewAds();
    }

    #endregion
}
