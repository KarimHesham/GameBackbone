using System.Collections;
using UnityEngine;

public class TestAssetBundle : MonoBehaviour
{
    #region Behaviour

    // Start is called before the first frame update
    IEnumerator Start()
    {
        if(APIManager.DataValidator.assetBundle == null)
        {
            RestApi.instance.DownloadAssetBundle();
            yield return new WaitUntil(predicate: () => APIManager.RequestManager.GetAssetBundle);
        }
        else
        {
            // Define asset bundle object and call APIManager to retrieve the downloaded assetBundle 
            UnityEngine.AssetBundle downloadedBundle = APIManager.DataValidator.assetBundle;
            // Define a prefab to hold GameObject from the downloaded asset bundle
            var prefab = downloadedBundle.LoadAsset<GameObject>("AssetBundle");
            // Instantiate prefab inside scene
            Instantiate(prefab);
        }        
    }

    #endregion
}
