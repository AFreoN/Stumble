using UnityEngine;

public class PSEnabler : MonoBehaviour
{
    int matNum;
    public int[] MaterialNumber;

	void Start ()
    {
        int m = 0;
        matNum = PlayerPrefs.GetInt("MatNum", 0);
        for (int i = 0; i < MaterialNumber.Length; i++)
        {
            if (MaterialNumber[i] == matNum)
            {
                gameObject.SetActive(true);
            }
            else
            {
                m += 1;
            }
        }
        if(m == MaterialNumber.Length)
        {
            gameObject.SetActive(false);
        }
	}
}
