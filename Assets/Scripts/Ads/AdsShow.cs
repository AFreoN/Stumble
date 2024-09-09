using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using VoxelBusters.NativePlugins;

public class AdsShow : MonoBehaviour
{
    public static AdsShow instance;
    public static int gamesPlayed = 0;

    void Awake()
    {
        instance = this;
        gamesPlayed += 1;
    }

        
    #region Show Rewarded Video Ads
    public void showAd()
    {
        if(Advertisement.IsReady())
        {
            Advertisement.Show("rewardedVideo",new ShowOptions() { resultCallback = HandleAdResult });
        }
        else
        {
            AudioManager.instance.Play("Error");
            NPBinding.UI.ShowToast("Make sure you connected to the Internet", eToastMessageLength.SHORT);

        }
    }

    private void HandleAdResult(ShowResult result)
    {
        switch(result)
        {
            case ShowResult.Finished:
                NPBinding.UI.ShowToast("You got 10 Diamonds", eToastMessageLength.SHORT);
                PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") + 10);
                KeyValueRestore.tempCoins = PlayerPrefs.GetInt("TotalCoins");
                break;
            case ShowResult.Skipped:
                NPBinding.UI.ShowToast("You have not fully watched the AD", eToastMessageLength.SHORT);
                break;
            case ShowResult.Failed:
                NPBinding.UI.ShowToast("Make sure you connected to the Internet", eToastMessageLength.SHORT);
                break;
        }
    }
    #endregion

    #region Non Rewarded Video and Banner Ads Shower
    public void showVideoAds()
    {
        if(Advertisement.IsReady())
        {
            Advertisement.Show("video");
        }
    }

    public void ShowBanner()
    {
        if(Advertisement.IsReady())
        {
            Advertisement.Show("Banner");
        }
    }
    #endregion
}
