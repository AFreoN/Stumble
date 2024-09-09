using UnityEngine;

public class BackPS : MonoBehaviour
{
    public GameObject DefaultPS;
    public GameObject blossom;
    public GameObject BrickPs;
    public GameObject RectroPS;
    public GameObject LeatherPS;
    public GameObject WoodPS;
    public GameObject SteelPS;

    int matNum;

    private void Start()
    {
        matNum = PlayerPrefs.GetInt("MatNum", 0);
        if(matNum < 2)
        {
            DefaultPS.SetActive(true);
            blossom.SetActive(false);
            BrickPs.SetActive(false);
            RectroPS.SetActive(false);
            LeatherPS.SetActive(false);
            WoodPS.SetActive(false);
        }
        if(matNum == 2 )
        {
            blossom.SetActive(true);
            DefaultPS.SetActive(false);
            BrickPs.SetActive(false);
            RectroPS.SetActive(false);
            LeatherPS.SetActive(false);
            SteelPS.SetActive(false);
        }
        else if(matNum == 3 || matNum == 4)
        {
            BrickPs.SetActive(true);
            blossom.SetActive(false);
            DefaultPS.SetActive(false);
            RectroPS.SetActive(false);
            LeatherPS.SetActive(false);
        }
        else if(matNum == 5)
        {
            RectroPS.SetActive(true);
            BrickPs.SetActive(false);
            blossom.SetActive(false);
            DefaultPS.SetActive(false);
            LeatherPS.SetActive(false);
        }
        else if(matNum == 6)
        {
            LeatherPS.SetActive(true);
            RectroPS.SetActive(false);
            BrickPs.SetActive(false);
            blossom.SetActive(false);
            DefaultPS.SetActive(false);
        }
        else if(matNum == 7)
        {

        }
    }
}
