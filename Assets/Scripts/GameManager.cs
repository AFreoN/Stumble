using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using VoxelBusters.NativePlugins;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //For Material Number
    public static int MatNumAll;

    public GameObject StartPanel;
    public GameObject GameOverPanel;
    public GameObject InGameCanvas;
    public GameObject stumbleHeader;
    public GameObject LayersPanel;
    public GameObject helpPanel;
    public GameObject GiftPanel;
    public static GameManager instance;

    public Animator cameraMain;
    public Animator gameOverPanel;

    //Game States
    public static bool startGame = false;
    public static bool dead = false;

    //For Game Speed
    float scaleTime;
    float changed = 0.1f;

    //For Quitting Application
    bool click = false;
    float timer;

    //For MainTheme
    public static int themeNum;

    void Awake ()
    {
        instance = this;
        scaleTime = 0;
        if (PlayerPrefs.GetInt("FirstTime", 0) == 1)
        {
            Load();
        }
        else
        {
            SaveSystem.LayerSave();
            PlayerPrefs.SetInt("MatNum", 0);
            PlayerPrefs.SetInt("HighScore", 0);
            PlayerPrefs.SetInt("TotalCoins", 0);
        }
        dead = false;
        startGame = false;
        click = false;
        stumbleHeader.SetActive(true);
        StartPanel.SetActive(true);
        GameOverPanel.SetActive(false);
        InGameCanvas.SetActive(false);
        LayersPanel.SetActive(false);
        helpPanel.SetActive(false);
        GiftPanel.SetActive(false);
        themeNum = UnityEngine.Random.Range(1, 3);
	}
    private void Start()
    {
        if (PlayerPrefs.GetInt("Audio", 1) == 1)
        {
            AudioManager.instance.Play("MainTheme"+themeNum);
        }
        if (PlayerPrefs.GetInt("FirstTime", 0) == 0)
        {
            PlayerPrefs.SetInt("FirstTime", 1);
        }
    }

    void Update()
    {
        #region For Quitting the Application
        if (click == false && Input.GetKey(KeyCode.Escape))
        {
        }
        if (click == false && Input.GetKeyUp(KeyCode.Escape))
        {
            NPBinding.UI.ShowToast("Press again to Exit", eToastMessageLength.SHORT);
            click = true;
            timer = Time.time + 0.5f;
        }
        else if(click == true && Input.GetKeyDown(KeyCode.Escape))
        {
            click = false;
            Application.Quit();
        }
        if(click == true)
        {
            if(Time.time > timer)
            {
                click = false;
            }
        }
        #endregion
        if (dead == false && startGame == true)
        {
            scaleTime += Time.deltaTime;
            Time.timeScale = 1 + scaleTime / 200;
            if(scaleTime/200 > changed)
            {
                scaleTime -= 0.05f;
                changed += 0.05f;
            }
        }
        else if(dead == true)
        {
            Time.timeScale = 1;
        }
    }
    public void StartGameBtn()
    {
        //uicamera.SetActive(false);
        StartPanel.SetActive(false);
        stumbleHeader.SetActive(false);
        InGameCanvas.SetActive(true);
        cameraMain.SetTrigger("start");
        StartCoroutine(start());
    }
    IEnumerator start()
    {
        yield return new WaitForSeconds(0.32f);
        startGame = true;
    }
    #region Layer & Help Panel (open close)
    public void layerspnlBtn()
    {
        AudioManager.instance.Play("Click1");
        LayersPanel.SetActive(true);
    }
    public void closeLayers()
    {
        AudioManager.instance.Play("Click1");
        LayersPanel.SetActive(false);
    }
    public void OpenHelpPanel()
    {
        AudioManager.instance.Play("Click1");
        helpPanel.SetActive(true);
    }
    public void CloseHelpPanel()
    {
        AudioManager.instance.Play("Click1");
        helpPanel.SetActive(false);
    }
    #endregion
    #region GiftPanel
    public void openGiftPanel()
    {
        if (PlayerPrefs.GetInt("TotalCoins") >= 200)
        {
            AudioManager.instance.Play("BuyBtn");
            GiftPanel.SetActive(true);
            KeyValueRestore.tempCoins = PlayerPrefs.GetInt("TotalCoins") - 200;
        }
        else
        {
            AudioManager.instance.Play("Error");
            NPBinding.UI.ShowToast("You don't have enough Diamonds", eToastMessageLength.SHORT);
        }
    }
    #endregion
    public void death()
    {
        AudioManager.instance.Pause("MainTheme"+themeNum);
        dead = true;
        startGame = false;
        GameOverPanel.SetActive(true);
        gameOverPanel.SetTrigger("play");
        if (AdsShow.gamesPlayed > 5)
        {
            int r = UnityEngine.Random.Range(1, 3);
            if (r == 1)
            {
                AdsShow.gamesPlayed = 0;
                AdsShow.instance.showVideoAds();
            }
            else if(r == 2)
            {
                AdsShow.instance.ShowBanner();
                AdsShow.gamesPlayed = 0;
            }
        }
    }

    public void restart()
    {
        GameEndAnim.play = true;
        cameraMain.SetTrigger("zoomin");
        AudioManager.instance.Play("CameraIn");
        AudioManager.instance.Stop("MainTheme"+themeNum);
        StartCoroutine(endGame());
    }
    public void LoadLayers(int num)
    {
        AudioManager.instance.Stop("MainTheme"+themeNum);
        MatNumAll = num;
        Save();
        SceneManager.LoadScene("Game");
    }
    public void LayerSaved(int num)
    {
        MatNumAll = num;
        Save();
        SaveSystem.LayerSave();
    }

    IEnumerator endGame()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Game");
    }

    #region Save&Load
    public void Save()
    {
        SaveSystem.Save();
    }
    public void Load()
    {
        PlayerData data = SaveSystem.Load();
        MatNumAll = data.materialNumber;
        PlayerPrefs.SetInt("MatNum", data.materialNumber);
        PlayerPrefs.SetInt("HighScore", data.HighScore);
        PlayerPrefs.SetInt("TotalCoins", data.Coins);
        Debug.Log("MatNUm = " + data.materialNumber + " " + "highscore = " + data.HighScore + " " + "Coins = " + data.Coins);
    }
    #endregion
}
