using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VoxelBusters;
using VoxelBusters.NativePlugins;

public class VoxelBusterManager : MonoBehaviour
{
    bool isSharing = false;

    public void SharetoSocial()
    {
        isSharing = true;
    }

    private void LateUpdate()
    {
        if(isSharing == true)
        {
            isSharing = false;
            StartCoroutine(CaptureScreenShot());
        }
    }

    IEnumerator CaptureScreenShot()
    {
        yield return new WaitForEndOfFrame();
        Texture2D _texture = ScreenCapture.CaptureScreenshotAsTexture();
        shareSheet(_texture);
    }

    public void shareSheet(Texture2D texture)
    {
        ShareSheet _shareSheet = new ShareSheet();
        _shareSheet.Text = "I Scored " + KeyValues.scoreCount + " points in #Stumble";
        _shareSheet.AttachImage(texture);
        _shareSheet.URL = "https://play.google.com/store/apps/details?id=com.AstarGames.stumble";
        NPBinding.Sharing.ShowView(_shareSheet, FinishSharing);
    }

    void FinishSharing(eShareResult _result)
    {
        NPBinding.UI.ShowToast("Thanks for Sharing!", eToastMessageLength.SHORT);
    }

    public void ShowToastMessage()
    {
        NPBinding.UI.ShowToast("Press again to Exit", eToastMessageLength.SHORT);
    }


    public void RateMyApp()
    {
        NPBinding.Utility.OpenStoreLink("com.AstarGames.stumble");
    }
}
