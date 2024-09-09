using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;
using VoxelBusters.NativePlugins;
using UnityEngine.Advertisements;

public class GameOverPanel : MonoBehaviour
{

    public GameObject signINBtn;
    public GameObject LeaderBoardsBtn;

    public GameObject adsCoinBtn;
    public GameObject tapText;

    //For Rate and Facebook Page Navigation Buttons
    public GameObject rateBtn;
    public GameObject facebookBtn;

    void OnEnable ()
    {
        tapText.SetActive(true);
        if (KeyValues.coins > 0)
        {
            adsCoinBtn.SetActive(true);
        }
        else
        {
            adsCoinBtn.SetActive(false);
        }
        if (!PlayGamesPlatform.Instance.localUser.authenticated)
        {
            signINBtn.SetActive(true);
            LeaderBoardsBtn.SetActive(false);
        }
        else if (PlayGamesPlatform.Instance.localUser.authenticated)
        {
            signINBtn.SetActive(false);
            LeaderBoardsBtn.SetActive(true);
        }

        int r = Random.Range(0, 2);
        if(r == 0)
        {
            rateBtn.SetActive(true);
            facebookBtn.SetActive(false);
        }
        else
        {
            rateBtn.SetActive(false);
            facebookBtn.SetActive(true);
        }
    }

    private void Update()
    {
        if(GameEndAnim.play == true && adsCoinBtn.activeInHierarchy == true)
        {
            adsCoinBtn.SetActive(false);
        }
        if(GameEndAnim.play == true && tapText.activeInHierarchy == true)
        {
            tapText.SetActive(false);
        }
    }

    #region Show Rewarded Video Ads
    public void DoubleCoins()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show("rewardedVideo", new ShowOptions() { resultCallback = HandleAdResult });
        }
        else
        {
            AudioManager.instance.Play("Error");
            NPBinding.UI.ShowToast("Make sure you connected to the Internet", eToastMessageLength.SHORT);

        }
    }

    private void HandleAdResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                adsCoinBtn.SetActive(false);
                FillBar.instance.coinsAfterAD();
                SaveSystem.Save();
                NPBinding.UI.ShowToast("You got " + KeyValues.coins +" Diamonds", eToastMessageLength.SHORT);
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

    #region FaceBook page Navigation

    public void openFacebookPage()
    {
        Application.OpenURL("https://www.facebook.com/AStar-Games-2203484576570889/");
    }
    #endregion /Facebook
}
