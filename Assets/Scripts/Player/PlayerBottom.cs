using UnityEngine;

public class PlayerBottom : MonoBehaviour
{
    int matNum;
    public Transform player;

    void Start()
    {
        gameObject.SetActive(true);
        matNum = PlayerPrefs.GetInt("MatNum", 0);
        colorChoose(matNum);
    }

    private void Update()
    {
        if (player.localScale.y == 2)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color32(0, 255, 0, 255);
        }
        else if (player.localScale.y == 1.5f)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 0, 255);
        }
        else if (player.localScale.y == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 90, 0, 255);
        }
        else if (player.localScale.y == 0.5f)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 0, 0, 255);
        }
    }

    void colorChoose(int c)
    {
        switch (c)
        {
            case 0:
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
