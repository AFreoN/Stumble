using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class KeyValues : MonoBehaviour
{
    public static KeyValues Instance;

    public Text scoretext;
    public static int scoreCount = 0;
    public static int coins = 0;
    bool readyToUpdate = true;
    int temp;
    Animator anim;

    //For Player Data
    public static int highscore;

    private void Awake()
    {
        Instance = this;
        readyToUpdate = true;
    }

    void Start ()
    {
        scoreCount = 0;
        coins = 0;
        temp = scoreCount;
        scoretext.text = scoreCount.ToString();
        anim = scoretext.GetComponent<Animator>();
        highscore = PlayerPrefs.GetInt("HighScore", 0);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (scoreCount != temp)
        {
            scoretext.text = scoreCount.ToString();
            temp = scoreCount;
            anim.SetTrigger("Zoom");
        }
        if(GameManager.dead == true && readyToUpdate == true)
        {
            updateHighScore();
        }
    }

    public void updateHighScore()
    {
        readyToUpdate = false;
        if (scoreCount > PlayerPrefs.GetInt("HighScore", 0))
        {
            highscore = scoreCount;
            PlayerPrefs.SetInt("HighScore", scoreCount);
            if (Social.localUser.authenticated)
            {
                Social.ReportScore(scoreCount, GPGSIds.leaderboard_high_scores, (bool success) =>
                {
                    Debug.Log("(Lollygagger) Leaderboard update success: " + success);
                });
            }
        }
        else
        {
            highscore = PlayerPrefs.GetInt("HighScore", 0);
        }
        PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins", 0));
        SaveSystem.Save();
    }
}
