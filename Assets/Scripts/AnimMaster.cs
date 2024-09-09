using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimMaster : MonoBehaviour
{
    public Animator cameraMain;
    public Animator stumbleText;
    public Animator FadeImg;
    public Animator MainPanel;
    public static int gamesPlayed = 0;

	void Awake ()
    {
        if (gamesPlayed == 0)
        {
            Time.timeScale = 1;
            FadeImg.SetTrigger("play");
            stumbleText.SetTrigger("play");
            StartCoroutine(playRem());
        }
        else if(gamesPlayed > 0)
        {
            Time.timeScale = 2;
            FadeImg.SetTrigger("play");
            stumbleText.SetTrigger("play");
            StartCoroutine(playRem());
        }
        gamesPlayed++;
    }

    IEnumerator playRem()
    {
        yield return new WaitForSeconds(0.5f);
        cameraMain.SetTrigger("zoomout");
        AudioManager.instance.Play("CameraOut");
        StartCoroutine(pauseCamera());
        yield return new WaitForSeconds(0.5f);
        MainPanel.SetTrigger("play");
        Time.timeScale = 1;
    }
    IEnumerator pauseCamera()
    {
        yield return new WaitForSeconds(1.5f);
        cameraMain.StopPlayback();
    }
}
