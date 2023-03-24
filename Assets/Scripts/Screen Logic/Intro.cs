using UnityEngine;
using UnityEngine.Video;

public class Intro : MonoBehaviour
{
    #region Behaviour

    // Start is called before the first frame update
    void Start()
    {       
        VideoPlayer.loopPointReached += SwitchSceneAfterVideo;
    }

    #endregion


    #region UIObjects

    public VideoPlayer VideoPlayer;

    #endregion


    #region Functionality

    // Method to switch to Main Scene
    public void SwitchSceneAfterVideo(UnityEngine.Video.VideoPlayer vp)
    {
        // Call UIManager to load Loading Scene
        UIManager.instance.Main();
    }

    public void SkipButton()
    {
        UIManager.instance.Main();
    }
 
    #endregion
}
