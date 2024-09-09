using UnityEngine;

public class TopRemBlocks : MonoBehaviour {

    public int matNum;

    void Start()
    {
        if (PlayerPrefs.GetInt("MatNum", 0) != matNum)
        {
            gameObject.SetActive(false);
        }
    }
}
