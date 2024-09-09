using UnityEngine;
using UnityEngine.UI;

public class BackGroundColor : MonoBehaviour
{
    public Transform player;
    Image backGround;
    [SerializeField][Range(0.001f,2)]
    float duration;

    int matNum;

	void Start ()
    {
        matNum = PlayerPrefs.GetInt("MatNum", 0);
        backGround = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (GameManager.dead == false)
        {
            chooseBackColor(matNum);
        }
        if(GameManager.dead == true)
        {
            backGround.color = Color.Lerp(backGround.color, new Color32(255, 0, 0, 255), duration);
        }
    }

    void chooseBackColor(int m)
    {
        switch (m)
        {
            case 0:
                if(player.localScale.y == 2)
                {
                    backGround.color = Color.Lerp(backGround.color, new Color32(0, 190, 250, 255), duration);
                }
                if (player.localScale.y == 1.5f)
                {
                    backGround.color = Color.Lerp(backGround.color, new Color32(255, 255, 0, 255), duration);
                }
                if (player.localScale.y == 1)
                {
                    backGround.color = Color.Lerp(backGround.color, new Color32(255, 90, 0, 255), duration);
                }
                if (player.localScale.y == 0.5f)
                {
                    backGround.color = Color.Lerp(backGround.color, new Color32(255, 0, 0, 255), duration);
                }
                break;
            case 1:
                if (player.localScale.y == 2)
                {
                    backGround.color = Color.Lerp(backGround.color, new Color32(0, 190, 250, 255), duration);
                }
                if (player.localScale.y == 1.5f)
                {
                    backGround.color = Color.Lerp(backGround.color, new Color32(255, 255, 0, 255), duration);
                }
                if (player.localScale.y == 1)
                {
                    backGround.color = Color.Lerp(backGround.color, new Color32(255, 90, 0, 255), duration);
                }
                if (player.localScale.y == 0.5f)
                {
                    backGround.color = Color.Lerp(backGround.color, new Color32(255, 0, 0, 255), duration);
                }
                break;
            case 2:
                if(player.localScale.y == 2)
                {
                    backGround.color = Color.Lerp(backGround.color, new Color32(214, 68, 182, 255), duration);
                }
                if (player.localScale.y == 1.5f)
                {
                    backGround.color = Color.Lerp(backGround.color, new Color32(255, 255, 0, 255), duration);
                }
                if (player.localScale.y == 1)
                {
                    backGround.color = Color.Lerp(backGround.color, new Color32(255, 90, 0, 255), duration);
                }
                if (player.localScale.y == 0.5f)
                {
                    backGround.color = Color.Lerp(backGround.color, new Color32(255, 0, 0, 255), duration);
                }
                break;
            case 3:
                if (player.localScale.y == 2)
                {
                    backGround.color = Color.Lerp(backGround.color, new Color32(255, 0, 62, 255), duration);
                }
                if (player.localScale.y == 1.5f)
                {
                    backGround.color = Color.Lerp(backGround.color, new Color32(255, 255, 0, 255), duration);
                }
                if (player.localScale.y == 1)
                {
                    backGround.color = Color.Lerp(backGround.color, new Color32(255, 90, 0, 255), duration);
                }
                if (player.localScale.y == 0.5f)
                {
                    backGround.color = Color.Lerp(backGround.color, new Color32(255, 0, 0, 255), duration);
                }
                break;
            case 4:
                if (player.localScale.y == 2)
                {
                    backGround.color = Color.Lerp(backGround.color, new Color32(140, 140, 140, 255), duration);
                }
                if (player.localScale.y == 1.5f)
                {
                    backGround.color = Color.Lerp(backGround.color, new Color32(255, 255, 0, 255), duration);
                }
                if (player.localScale.y == 1)
                {
                    backGround.color = Color.Lerp(backGround.color, new Color32(255, 90, 0, 255), duration);
                }
                if (player.localScale.y == 0.5f)
                {
                    backGround.color = Color.Lerp(backGround.color, new Color32(255, 0, 0, 255), duration);
                }
                break;
            case 5:
                if (player.localScale.y == 2)
                {
                    backGround.color = Color.Lerp(backGround.color, new Color32(7, 103, 23, 255), duration);
                }
                if (player.localScale.y == 1.5f)
                {
                    backGround.color = Color.Lerp(backGround.color, new Color32(255, 255, 0, 255), duration);
                }
                if (player.localScale.y == 1)
                {
                    backGround.color = Color.Lerp(backGround.color, new Color32(255, 90, 0, 255), duration);
                }
                if (player.localScale.y == 0.5f)
                {
                    backGround.color = Color.Lerp(backGround.color, new Color32(255, 0, 0, 255), duration);
                }
                break;
            case 6:
                if (player.localScale.y == 2)
                {
                    backGround.color = Color.Lerp(backGround.color, new Color32(217, 217, 217, 255), duration);
                }
                if (player.localScale.y == 1.5f)
                {
                    backGround.color = Color.Lerp(backGround.color, new Color32(255, 255, 0, 255), duration);
                }
                if (player.localScale.y == 1)
                {
                    backGround.color = Color.Lerp(backGround.color, new Color32(255, 90, 0, 255), duration);
                }
                if (player.localScale.y == 0.5f)
                {
                    backGround.color = Color.Lerp(backGround.color, new Color32(255, 0, 0, 255), duration);
                }
                break;
            case 7:
                if (player.localScale.y == 2)
                {
                    backGround.color = Color.Lerp(backGround.color, new Color32(91, 87, 0, 255), duration);
                }
                if (player.localScale.y == 1.5f)
                {
                    backGround.color = Color.Lerp(backGround.color, new Color32(255, 255, 0, 255), duration);
                }
                if (player.localScale.y == 1)
                {
                    backGround.color = Color.Lerp(backGround.color, new Color32(255, 90, 0, 255), duration);
                }
                if (player.localScale.y == 0.5f)
                {
                    backGround.color = Color.Lerp(backGround.color, new Color32(255, 0, 0, 255), duration);
                }
                break;
            case 8:
                if (player.localScale.y == 2)
                {
                    backGround.color = Color.Lerp(backGround.color, new Color32(127, 65, 233, 255), duration);
                }
                if (player.localScale.y == 1.5f)
                {
                    backGround.color = Color.Lerp(backGround.color, new Color32(255, 255, 0, 255), duration);
                }
                if (player.localScale.y == 1)
                {
                    backGround.color = Color.Lerp(backGround.color, new Color32(255, 90, 0, 255), duration);
                }
                if (player.localScale.y == 0.5f)
                {
                    backGround.color = Color.Lerp(backGround.color, new Color32(255, 0, 0, 255), duration);
                }
                break;
            case 9:
                if (player.localScale.y == 2)
                {
                    backGround.color = Color.Lerp(backGround.color, new Color32(207, 207, 207, 255), duration);
                }
                if (player.localScale.y == 1.5f)
                {
                    backGround.color = Color.Lerp(backGround.color, new Color32(255, 255, 0, 255), duration);
                }
                if (player.localScale.y == 1)
                {
                    backGround.color = Color.Lerp(backGround.color, new Color32(255, 90, 0, 255), duration);
                }
                if (player.localScale.y == 0.5f)
                {
                    backGround.color = Color.Lerp(backGround.color, new Color32(255, 0, 0, 255), duration);
                }
                break;
        }
    }
}
