using UnityEngine;

public class PlayerTop : MonoBehaviour {

    int matNum;

	void Start ()
    {
        gameObject.SetActive(true);
        matNum = PlayerPrefs.GetInt("MatNum", 0);
        colorChoose(matNum);
	}

    void colorChoose(int c)
    {
        switch(c)
        {
            case 0:
                gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 0, 0, 255);
                break;
            case 1:
                gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
                break;
            case 2:
                gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 0, 210, 255);
                break;
            case 3:
                gameObject.SetActive(false);
                break;
            case 4:
                gameObject.SetActive(false);
                break;
            case 5:
                gameObject.SetActive(false);
                break;
            case 6:
                gameObject.SetActive(false);
                break;
            case 7:
                gameObject.SetActive(false);
                break;
            case 8:
                gameObject.SetActive(false);
                break;
            case 9:
                gameObject.SetActive(false);
                break;
        }
    }
}
