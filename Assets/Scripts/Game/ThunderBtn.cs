using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ThunderBtn : MonoBehaviour
{
    public GameObject LightImg;
    Button spBtn;
    public float waitTime = 1f;
    public static bool used = false;

    private void Awake()
    {
        used = false;
    }

    void Start ()
    {
        spBtn = GetComponent<Button>();
        spBtn.interactable = false;
        LightImg.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(GameManager.dead == true && gameObject.activeInHierarchy == true)
        {
            gameObject.SetActive(false);
        }
        else if(gameObject.activeInHierarchy == false && GameManager.dead == false)
        {
            gameObject.SetActive(true);
        }
        if(FillBar.superPower == true && spBtn.interactable == true)
        {
            spBtn.interactable = false;
        }
		if(FillBar.ActicateSpBtn == true && spBtn.interactable == false)
        {
            FillBar.ActicateSpBtn = false;
            spBtn.interactable = true;
            LightImg.SetActive(true);
            used = true;
            StartCoroutine(turnOffPower());
        }
	}

    IEnumerator turnOffPower()
    {
        yield return new WaitForSeconds(waitTime);
        LightImg.SetActive(false);
        spBtn.interactable = false;
    }
}
