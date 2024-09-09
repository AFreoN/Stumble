using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{

    public static void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        string path = Application.persistentDataPath + "/stumble.astar";
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData data = new PlayerData(GameManager.MatNumAll,KeyValues.highscore,PlayerPrefs.GetInt("TotalCoins",0)+KeyValues.coins);
        bf.Serialize(stream, data);
        stream.Close();
        PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins", 0) + KeyValues.coins);
    }

    public static PlayerData Load()
    {
        string path = Application.persistentDataPath + "/stumble.astar";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        else
        {
            return null;
        }
    }

    public static void LayerSave()
    {
        BinaryFormatter bf = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Layer.astar";
        FileStream stream = new FileStream(path, FileMode.Create);
        LayerData data = new LayerData();
        bf.Serialize(stream, data);
        stream.Close();
    }

    public static LayerData LayerLoad()
    {
        string path = Application.persistentDataPath + "/Layer.astar";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            LayerData data = formatter.Deserialize(stream) as LayerData;
            stream.Close();
            return data;
        }
        else
        {
            return null;
        }
    }

}
