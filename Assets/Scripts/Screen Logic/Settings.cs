using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    #region Declaration

    public TextMeshProUGUI soundValue;
    public TextMeshProUGUI notificationValue;

    #endregion


    #region Functionality

    // Method to handle start logic
    private void Start()
    {
        if (DataManager.instance.GetSoundPref() == 1)
            soundValue.text = "On";
        else
            soundValue.text = "Off";
        if (DataManager.instance.GetNotifications() == 1)
            notificationValue.text = "On";
        else
            notificationValue.text = "Off";
    }

    // Method to handle back button click logic
    public void BackButton()
    {
        UIManager.instance.Main();
    }

    // Method to handle sound button click logic
    public void SoundButton()
    {
        if(DataManager.instance.GetSoundPref() == 1 || DataManager.instance.GetSoundPref() != 0)
        {
            DataManager.instance.SetSoundPref(0);
            soundValue.text = "Off";
        }
        else
        {
            DataManager.instance.SetSoundPref(1);
            soundValue.text = "On";
        }
    }

    // Method to handle notifications button click logic
    public void NotificationsButton()
    {
        if(DataManager.instance.GetNotifications() == 1 || DataManager.instance.GetNotifications() != 0)
        {
            DataManager.instance.SetNotifications(0);
            notificationValue.text = "Off";
        }
        else
        {
            DataManager.instance.SetNotifications(1);
            notificationValue.text = "On";
        }
    }

    // Method to handle English language button click logic
    public void EnglishButton()
    {
        DataManager.instance.SetLanguage("en");
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
    }

    // Method to handle Arabic language button click logic
    public void ArabicButton()
    {
        DataManager.instance.SetLanguage("ar");
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[1];
    }

    // Method to handle Spanish language button click logic
    public void SpanishButton()
    {
        DataManager.instance.SetLanguage("es");
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[2];
    }

    #endregion
}
