using UnityEngine.UI;
using UnityEngine;

public class KeyValueRestore : MonoBehaviour
{

    public Text DiamondsText;
    public static int tempCoins;

    private void Awake()
    {
        tempCoins = PlayerPrefs.GetInt("TotalCoins", 0);
    }

    void Start ()
    {
        DiamondsText.text = PlayerPrefs.GetInt("TotalCoins", 0).ToString();
    }

    private void Update()
    {
        DiamondsText.text = tempCoins.ToString();
    }

}
