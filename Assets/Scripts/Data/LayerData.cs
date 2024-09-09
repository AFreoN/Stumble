using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LayerData
{
    public static LayerData instance;

    public bool IsUnlocked0 = true;
    public bool IsUnlocked1 = false;
    public bool IsUnlocked2 = false;
    public bool IsUnlocked3 = false;
    public bool IsUnlocked4 = false;
    public bool IsUnlocked5 = false;
    public bool IsUnlocked6 = false;
    public bool IsUnlocked7 = false;
    public bool IsUnlocked8 = false;
    public bool IsUnlocked9 = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public LayerData()
    {
        IsUnlocked0 = LayerContentDisplay.unlock0;
        IsUnlocked1 = LayerContentDisplay.unlock1;
        IsUnlocked2 = LayerContentDisplay.unlock2;
        IsUnlocked3 = LayerContentDisplay.unlock3;
        IsUnlocked4 = LayerContentDisplay.unlock4;
        IsUnlocked5 = LayerContentDisplay.unlock5;
        IsUnlocked6 = LayerContentDisplay.unlock6;
        IsUnlocked7 = LayerContentDisplay.unlock7;
        IsUnlocked8 = LayerContentDisplay.unlock8;
        IsUnlocked9 = LayerContentDisplay.unlock9;
    }

}
