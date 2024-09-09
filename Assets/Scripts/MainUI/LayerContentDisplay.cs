using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LayerContentDisplay : MonoBehaviour
{
    public static LayerContentDisplay instance;
    GameManager gm;

    //For Buy Button
    public Button buyBtn;

    public static int LayerLength = 10;

    // For LayerData
    public static int tempLayerNum = 0;
    public static bool unlock = false;

    public static bool unlock0 = true;
    public static bool unlock1 = false;
    public static bool unlock2 = false;
    public static bool unlock3 = false;
    public static bool unlock4 = false;
    public static bool unlock5 = false;
    public static bool unlock6 = false;
    public static bool unlock7 = false;
    public static bool unlock8 = false;
    public static bool unlock9 = false;

    int i = 0;
    int[] layerArray;

    //For GiftShower
    public static int LayerNum = 0;
    public static bool change = false;
    bool clicked = false;

    void Awake ()
    {
        if(instance == null)
        {
            instance = this;
        }
        gm = GameManager.instance;
        LayerLength = transform.childCount;
        LayerData data = SaveSystem.LayerLoad();
        unlock0 = data.IsUnlocked0;
        unlock1 = data.IsUnlocked1;
        unlock2 = data.IsUnlocked2;
        unlock3 = data.IsUnlocked3;
        unlock4 = data.IsUnlocked4;
        unlock5 = data.IsUnlocked5;
        unlock6 = data.IsUnlocked6;
        unlock7 = data.IsUnlocked7;
        unlock8 = data.IsUnlocked8;
        unlock9 = data.IsUnlocked9;
        if (data.IsUnlocked0 == false)
        {
            transform.GetChild(0).GetComponent<Button>().interactable = false;
            i++;
        }
        if (data.IsUnlocked1 == false)
        {
            transform.GetChild(1).GetComponent<Button>().interactable = false;
            i++;
        }
        if (data.IsUnlocked2 == false)
        {
            transform.GetChild(2).GetComponent<Button>().interactable = false;
            i++;
        }
        if (data.IsUnlocked3 == false)
        {
            transform.GetChild(3).GetComponent<Button>().interactable = false;
            i++;
        }
        if (data.IsUnlocked4 == false)
        {
            transform.GetChild(4).GetComponent<Button>().interactable = false;
            i++;
        }
        if (data.IsUnlocked5 == false)
        {
            transform.GetChild(5).GetComponent<Button>().interactable = false;
            i++;
        }
        if (data.IsUnlocked6 == false)
        {
            transform.GetChild(6).GetComponent<Button>().interactable = false;
            i++;
        }
        if (data.IsUnlocked7 == false)
        {
            transform.GetChild(7).GetComponent<Button>().interactable = false;
            i++;
        }
        if (data.IsUnlocked8 == false)
        {
            transform.GetChild(8).GetComponent<Button>().interactable = false;
            i++;
        }
        if (data.IsUnlocked9 == false)
        {
            transform.GetChild(9).GetComponent<Button>().interactable = false;
            i++;
        }
        if (i > 0)
        {
            arrayCreator();
        }
        if(i == 0)
        {
            buyBtn.interactable = false;
        }
        else if(i > 0)
        {
            buyBtn.interactable = true;
        }
    }
    #region arrayCreator
    void arrayCreator()
    {
        LayerData data = SaveSystem.LayerLoad();
        layerArray = new int[i];
        int t = 0;
        if (data.IsUnlocked0 == false)
        {
            layerArray[t] = 0;
            t++;
        }
        if (data.IsUnlocked1 == false)
        {
            layerArray[t] = 1;
            t++;
        }
        if (data.IsUnlocked2 == false)
        {
            layerArray[t] = 2;
            t++;
        }
        if (data.IsUnlocked3 == false)
        {
            layerArray[t] = 3;
            t++;
        }
        if (data.IsUnlocked4 == false)
        {
            layerArray[t] = 4;
            t++;
        }
        if (data.IsUnlocked5 == false)
        {
            layerArray[t] = 5;
            t++;
        }
        if (data.IsUnlocked6 == false)
        {
            layerArray[t] = 6;
            t++;
        }
        if (data.IsUnlocked7 == false)
        {
            layerArray[t] = 7;
            t++;
        }
        if (data.IsUnlocked8 == false)
        {
            layerArray[t] = 8;
            t++;
        }
        if (data.IsUnlocked9 == false)
        {
            layerArray[t] = 9;
            t++;
        }
    }
    #endregion
    public void getGift()
    {
        if (clicked == false)
        {
            clicked = true;
            AudioManager.instance.Play("LayerUnlocked");
            PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") - 200);
            int randomNum = Random.Range(0, i);
            LayerNum = layerArray[randomNum];
            giftSaver(layerArray[randomNum]);
            change = true;
            gm.LayerSaved(layerArray[randomNum]);
        }
        else if (clicked == true)
        {
            SceneManager.LoadScene("Game");
        }
    }

    void giftSaver(int s)
    {
        switch(s)
        {
            case 1:
                unlock1 = true;
                break;
            case 2:
                unlock2 = true;
                break;
            case 3:
                unlock3 = true;
                break;
            case 4:
                unlock4 = true;
                break;
            case 5:
                unlock5 = true;
                break;
            case 6:
                unlock6 = true;
                break;
            case 7:
                unlock7 = true;
                break;
            case 8:
                unlock8 = true;
                break;
            case 9:
                unlock9 = true;
                break;
        }
    }
}
