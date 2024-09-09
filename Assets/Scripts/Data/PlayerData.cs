using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public static PlayerData instance;

    public static int matNum = 0;
    public int materialNumber;
    public int HighScore;
    public int Coins;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public PlayerData(int num,int hScore,int coi)
    {
        materialNumber = num;
        HighScore = hScore;
        Coins = coi;
    }

}
