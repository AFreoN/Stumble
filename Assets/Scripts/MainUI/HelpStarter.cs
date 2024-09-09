using UnityEngine;
using System.Collections;

public class HelpStarter : MonoBehaviour
{
    public GameObject coverImg;
    public GameObject HelpCloseCoverImg;
    public GameObject tapFinger;
    public GameObject HelpBtn;
    public GameObject swipeFinger;
    public GameObject helpPanel;

    bool work = false;

	void Awake ()
    {
        helpPanel.SetActive(false);
		if(PlayerPrefs.GetInt("FirstTime",0) == 0)
        {
            coverImg.SetActive(false);
            tapFinger.SetActive(false);
            HelpBtn.SetActive(false);
            HelpCloseCoverImg.SetActive(false);
            swipeFinger.SetActive(false);
            StartCoroutine(setter());
        }
        else
        {
            this.gameObject.SetActive(false);
        }
	}

    IEnumerator setter()
    {
        yield return new WaitForSeconds(2);
        coverImg.SetActive(true);
        tapFinger.SetActive(true);
        HelpBtn.SetActive(true);
        HelpCloseCoverImg.SetActive(false);
        swipeFinger.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(work == true)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Ended)
                {
                    this.gameObject.SetActive(false);
                }
            }
            if(Input.GetMouseButtonDown(0))
            {
                this.gameObject.SetActive(false);
            }
        }
	}

    public void openHelpPanel()
    {
        helpPanel.SetActive(true);
        coverImg.SetActive(false);
        tapFinger.SetActive(false);
        HelpBtn.SetActive(false);
        HelpCloseCoverImg.SetActive(true);
        swipeFinger.SetActive(true);
        StartCoroutine(worker());
    }

    IEnumerator worker()
    {
        yield return new WaitForSeconds(1);
        work = true;
    }
}
