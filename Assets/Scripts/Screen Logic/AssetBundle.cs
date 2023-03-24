using UnityEngine;

public class AssetBundle : MonoBehaviour
{
    #region Declaration

    public AudioSource SoundPlayer1;
    public AudioSource SoundPlayer2;

    #endregion
    

    #region Functionality
    public void SoundButton1()
    {
        SoundPlayer1.Play();
    }

    public void SoundButton2()
    {
        SoundPlayer2.Play();
    }

    #endregion

}
