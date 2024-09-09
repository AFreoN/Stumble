using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;
using UnityEngine.UI;
using VoxelBusters.NativePlugins;
using System.Collections;

public class GPActivate : MonoBehaviour {

    public static GPActivate Instance;

    public GameObject signINBtn;
    public GameObject LeaderBoardsBtn;

    private void Awake()
    {
        Instance = this;
        if(PlayerPrefs.HasKey("posted") == false)
        {
            PlayerPrefs.SetInt("posted", 0);
        }
        if (!PlayGamesPlatform.Instance.localUser.authenticated)
        {
            signINBtn.SetActive(true);
            LeaderBoardsBtn.SetActive(false);
        }
        else if(PlayGamesPlatform.Instance.localUser.authenticated)
        {
            signINBtn.SetActive(false);
            LeaderBoardsBtn.SetActive(true);
        }
    }

    void Start ()
    {
        if (AdsShow.gamesPlayed == 1)
        {
            // Create client configuration
            PlayGamesClientConfiguration config = new
                PlayGamesClientConfiguration.Builder()
                .Build();

            // Enable debugging output (recommended)
            PlayGamesPlatform.DebugLogEnabled = true;

            // Initialize and activate the platform
            PlayGamesPlatform.InitializeInstance(config);
            PlayGamesPlatform.Activate();

            SignIn();
        }
    }

    public void SignIn()
    {
        if (!PlayGamesPlatform.Instance.localUser.authenticated)
        {
            // Sign in with Play Game Services, showing the consent dialog
            // by setting the second parameter to isSilent=false.
            PlayGamesPlatform.Instance.Authenticate(SignInCallback, false);
        }
        else
        {
            // Sign out of play games
            PlayGamesPlatform.Instance.SignOut();
        }
    }
    public void SignInCallback(bool success)
    {
        if (success)
        {
            if (PlayerPrefs.GetInt("posted") == 0)
            {
                PlayerPrefs.SetInt("posted", 1);
            }
            signINBtn.SetActive(false);
            LeaderBoardsBtn.SetActive(true);
            NPBinding.UI.ShowToast("Welcome" + Social.localUser.userName, eToastMessageLength.SHORT);
            PlayerData data = SaveSystem.Load();
            Social.ReportScore(data.HighScore, GPGSIds.leaderboard_high_scores, (bool _success) =>
            {
                Debug.Log("(Lollygagger) Leaderboard update success: " + _success);
            });
        }
        else
        {
            signINBtn.SetActive(true);
            LeaderBoardsBtn.SetActive(false);
            NPBinding.UI.ShowToast("Failed to Sign in play games", eToastMessageLength.SHORT);
        }
        
    }

    public void ShowLeaderboards()
    {
        if (PlayGamesPlatform.Instance.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.ShowLeaderboardUI();
        }
        else
        {
            Debug.Log("Cannot show leaderboard: not authenticated");
        }
    }
}
