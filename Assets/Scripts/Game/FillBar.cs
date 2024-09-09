using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System;

public class FillBar : MonoBehaviour
{
    public static FillBar instance;

    public Transform player;
    public Image fillerImg;
    float num;
    float score;
    float numScore;
    float playerScale;
    //For StupidUpdate
    int CurrentScore;

    bool increasecoins = false;

    //For AnimCoinsText
    public Text mainCointext;
    public Animator animCoin;

    //For SuperCharge
    public Image SpFillerImg;
    public Button spPowerBtn;
    public GameObject LightImg;
    float SPfillCount = 0;
    public static bool ActicateSpBtn = false;
    public static bool superPower = false;
    bool decreaseFill = false;
    float reducer = 10;
    //For CountDown Text
    public Text countDownText;
    float timerCountDown = 0;
    int cycles = 10;

    void Awake ()
    {
        instance = this;
        fillerImg.fillAmount = 0;
        SpFillerImg.fillAmount = 0;
        mainCointext.text = "0";
        increasecoins = false;
        score = KeyValues.scoreCount;
        CurrentScore = KeyValues.scoreCount;
        playerScale = player.localScale.y;
        randomNum();
        //For SuperPower
        superPower = false;
        ActicateSpBtn = false;
        decreaseFill = false;
        LightImg.SetActive(false);
        spPowerBtn.interactable = false;
        countDownText.text = "";
    }

	void Update ()
    {
        if(GameManager.dead == true && fillerImg.gameObject.activeInHierarchy == true && SpFillerImg.gameObject.activeInHierarchy == true)
        {
            fillerImg.gameObject.SetActive(false);
            SpFillerImg.gameObject.SetActive(false);
        }
        else if(fillerImg.gameObject.activeInHierarchy == false && SpFillerImg.gameObject.activeInHierarchy == false && GameManager.dead == false)
        {
            fillerImg.gameObject.SetActive(true);
            SpFillerImg.gameObject.SetActive(true);
        }
        if(player.localScale.y == playerScale)
        {
            if (KeyValues.scoreCount != CurrentScore && numScore > KeyValues.scoreCount)
            {
                CurrentScore = KeyValues.scoreCount;
                float diff = numScore - KeyValues.scoreCount;
                float div = diff / num;
                fillerImg.fillAmount = 1 - div;
                if(increasecoins == true)
                {
                    KeyValues.coins += 1;
                    forSuperPower();
                    mainCointext.text = KeyValues.coins.ToString();
                    animCoin.SetTrigger("play");
                }
                if(PlayerMovement.moveFast == true)
                {
                    PlayerMovement.SpeedMultiplier += 0.01f;
                }
            }
            else if(KeyValues.scoreCount != CurrentScore && player.localScale.y < 2)
            {
                CurrentScore = KeyValues.scoreCount;
                fillerImg.fillAmount = 0;
                score = KeyValues.scoreCount;
                randomNum();
                //For Coins Start
                increasecoins = true;
                KeyValues.coins += 1;
                mainCointext.text = KeyValues.coins.ToString();
                animCoin.SetTrigger("play");
                //For Coins End
                forSuperPower();
                if (player.localScale.y < 2)
                {
                    IncreasePlayerSize();
                }
                //ForPlayerSpeed
                PlayerMovement.moveFast = true;
                PlayerMovement.SpeedMultiplier += 0.01f;
            }
            else if (KeyValues.scoreCount != CurrentScore && player.localScale.y == 2)
            {
                CurrentScore = KeyValues.scoreCount;
                fillerImg.fillAmount = 1;
                //score = KeyValues.scoreCount;
                //For Coins Start
                increasecoins = true;
                KeyValues.coins += 1;
                mainCointext.text = KeyValues.coins.ToString();
                animCoin.SetTrigger("play");
                //For Coins End
                forSuperPower();
                //ForPlayer Speed
                PlayerMovement.moveFast = true;
                PlayerMovement.SpeedMultiplier += 0.01f;
            }
        }
        else if(player.localScale.y < playerScale && player.localScale.y < 2 )
        {
            playerScale = player.localScale.y;
            score = KeyValues.scoreCount;
            fillerImg.fillAmount = 0;
            increasecoins = false;
            randomNum();
            PlayerMovement.moveFast = false;
            PlayerMovement.SpeedMultiplier = 1;
            //For SuperCharge
            if (decreaseFill == false && superPower == false)
            {
                SpFillerImg.fillAmount = 0;
                SPfillCount = 0;
                ActicateSpBtn = false;
            }
        }
        if (ThunderBtn.used == false && SpFillerImg.fillAmount == 1 && ActicateSpBtn == false)
        {
            ActicateSpBtn = true;
        }
        if (decreaseFill == true)
        {
            reduceFillamount();
        }
        if(superPower == true)
        {
            CountDown();
        }
	}

    private void reduceFillamount()
    {
        if (SpFillerImg.fillAmount == 0)
        {
            decreaseFill = false;
            reducer = 10;
            SpFillerImg.fillAmount = 0;
            SPfillCount = 0;
        }
        else
        {
            reducer -= Time.deltaTime;
            float cur = 10 - reducer;
            SpFillerImg.fillAmount = 1 - cur / 10;
        }
    }

    void forSuperPower()
    {
        if (SpFillerImg.fillAmount < 1 && decreaseFill == false && superPower == false)
        {
            SPfillCount += 1;
            float spdiff = 8 - SPfillCount;
            SpFillerImg.fillAmount = 1 - spdiff / 8;
        }
        else if(ThunderBtn.used == false && SpFillerImg.fillAmount == 1 && decreaseFill == false && superPower == false)
        {
            SpFillerImg.fillAmount = 1;
            SPfillCount = 8;
            if (ActicateSpBtn == false)
            {
                ActicateSpBtn = true;
            }
        }
        else if(ThunderBtn.used == true && SpFillerImg.fillAmount == 1 && decreaseFill == false && superPower == false && ActicateSpBtn == true)
        {
            SpFillerImg.fillAmount = 1;
            SPfillCount = 8;
        }
        else if (ThunderBtn.used == true && SpFillerImg.fillAmount == 1 && decreaseFill == false && superPower == false && ActicateSpBtn == false)
        {
            SpFillerImg.fillAmount = 0;
            SPfillCount = 0;
            ThunderBtn.used = false;
        }
    }

    public void activateSuperPower()
    {
        timerCountDown = Time.time + 10;
        superPower = true;
        decreaseFill = true;
        ThunderBtn.used = false;
        ActicateSpBtn = false;
        spPowerBtn.interactable = false;
        LightImg.SetActive(false);
        StartCoroutine(offPower());
    }

    void CountDown()
    {
        if (GameManager.dead == false)
        {
            float t = timerCountDown - Time.time;
            if (t <= cycles)
            {
                if (cycles != 0)
                {
                    countDownText.text = cycles.ToString();
                }
                else
                {
                    countDownText.text = "";
                }
                cycles -= 1;
            }
        }
        else if(GameManager.dead == true)
        {
            countDownText.text = "";
        }
    }
    IEnumerator offPower()
    {
        yield return new WaitForSeconds(10);
        superPower = false;
        cycles = 10;
    }

    void randomNum()
    {
        num = UnityEngine.Random.Range(12, 16);
        numScore = score + num;
    }
    
    void IncreasePlayerSize()
    {
        player.localScale = new Vector3(player.localScale.x, player.localScale.y + 0.5f, player.localScale.z);
        playerScale = player.localScale.y;
        StartCoroutine(forRem());
    }
    IEnumerator forRem()
    {
        yield return new WaitForSeconds(0.5f);
        PlayerMovement.forRemPlayer = player.localScale.y;
    }

    public void coinsAfterAD()
    {
        int c = KeyValues.coins * 2;
        mainCointext.text = c.ToString();
    }
}
