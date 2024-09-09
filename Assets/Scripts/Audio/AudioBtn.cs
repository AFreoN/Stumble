using UnityEngine.UI;
using UnityEngine;

public class AudioBtn : MonoBehaviour {

    public Sprite AudioON;
    public Sprite AudioOFF;
    bool AudioisON = true;

	void Awake ()
    {
        if (PlayerPrefs.GetInt("Audio", 1) == 1)
        {
            gameObject.GetComponent<Image>().sprite = AudioON;
            AudioListener.pause = false;
        }
        else if(PlayerPrefs.GetInt("Audio",1) == 0)
        {
            gameObject.GetComponent<Image>().sprite = AudioOFF;
            AudioListener.pause = true;
        }
	}

    public void Swap()
    {
        if (AudioisON == true)
        {
            gameObject.GetComponent<Image>().sprite = AudioOFF;
            PlayerPrefs.SetInt("Audio", 0);
            AudioManager.instance.Pause("MainTheme"+GameManager.themeNum);
            AudioListener.pause = true;
            AudioisON = false;
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = AudioON;
            PlayerPrefs.SetInt("Audio", 1);
            AudioManager.instance.Play("MainTheme"+GameManager.themeNum);
            AudioListener.pause = false;
            AudioManager.instance.Play("Click1");
            AudioisON = true;
        }
    }
}
