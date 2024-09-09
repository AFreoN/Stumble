using UnityEngine;

public class RemPlayerMat : MonoBehaviour
{
    public Material[] RemMat;
    public SpriteRenderer topMat;
    int matnum;

    void Start ()
    {
        matnum = PlayerPrefs.GetInt("MatNum", 0);
        this.GetComponent<Renderer>().sharedMaterial = RemMat[matnum];
        topColorChooser(matnum);
        float temp = PlayerMovement.forRemPlayer;
		if(transform.localScale.y == 0.5f && temp == 2)
        {
            //rend.material = materials[0];
            RemMat[matnum].mainTextureScale = new Vector2(1, 0.25f);
            RemMat[matnum].SetTextureOffset("_MainTex", new Vector2(0, 0));
            if (matnum == 0)
            {
                topMat.color = new Color32(0, 255, 0, 255);
            }
        }
        else if(transform.localScale.y == 1 && temp == 2)
        {
            //rend.material = materials[1];
            RemMat[matnum].mainTextureScale = new Vector2(1, 0.5f);
            RemMat[matnum].SetTextureOffset("_MainTex", new Vector2(0, 0));
            if (matnum == 0)
            {
                topMat.color = new Color32(255, 255, 0, 255);
            }
        }
        else if (transform.localScale.y == 1.5f && temp == 2)
        {
            //rend.material = materials[2];
            RemMat[matnum].mainTextureScale = new Vector2(1, 0.75f);
            RemMat[matnum].SetTextureOffset("_MainTex", new Vector2(0, 0));
            if (matnum == 0)
            {
                topMat.color = new Color32(207, 150, 0, 255);
            }
        }
        else if (transform.localScale.y == 2 && temp == 2)
        {
            //rend.material = materials[3];
            RemMat[matnum].mainTextureScale = new Vector2(1, 1);
            RemMat[matnum].SetTextureOffset("_MainTex", new Vector2(0, 0));
            if (matnum == 0)
            {
                topMat.color = new Color32(255, 0, 0, 255);
            }
        }
        //For Player at 3 life
        if(transform.localScale.y == 0.5f && temp == 1.5f)
        {
            //rend.material.color = new Color32(255, 255, 0, 255);
            RemMat[matnum].mainTextureScale = new Vector2(1, 0.25f);
            RemMat[matnum].SetTextureOffset("_MainTex", new Vector2(0, 0.25f));
            if (matnum == 0)
            {
                topMat.color = new Color32(255, 255, 0, 255);
            }
        }
        else if(transform.localScale.y == 1 && temp == 1.5f)
        {
            //rend.material = materials[4];
            RemMat[matnum].mainTextureScale = new Vector2(1, 0.5f);
            RemMat[matnum].SetTextureOffset("_MainTex", new Vector2(0, 0.25f));
            if (matnum == 0)
            {
                topMat.color = new Color32(207, 150, 0, 255);
            }
        }
        else if(transform.localScale.y == 1.5f && temp == 1.5f)
        {
            //rend.material = materials[5];
            RemMat[matnum].mainTextureScale = new Vector2(1, 0.75f);
            RemMat[matnum].SetTextureOffset("_MainTex", new Vector2(0, 0.25f));
            if (matnum == 0)
            {
                topMat.color = new Color32(255, 0, 0, 255);
            }
        }
        //For Player at 2 Life
        if(transform.localScale.y == 0.5f && temp == 1)
        {
            //rend.material.color = new Color32(255, 90, 0, 255);
            RemMat[matnum].mainTextureScale = new Vector2(1, 0.25f);
            RemMat[matnum].SetTextureOffset("_MainTex", new Vector2(0, 0.5f));
            if (matnum == 0)
            {
                topMat.color = new Color32(207, 150, 0, 255);
            }
        }
        else if (transform.localScale.y == 1 && temp == 1)
        {
            //rend.material = materials[6];
            RemMat[matnum].mainTextureScale = new Vector2(1, 0.5f);
            RemMat[matnum].SetTextureOffset("_MainTex", new Vector2(0, 0.5f));
            if (matnum == 0)
            {
                topMat.color = new Color32(255, 0, 0, 255);
            }
        }
        //For Player at 1 Life
        if(transform.localScale.y == 0.5f && temp == 0.5f)
        {
            //rend.material.color = new Color32(255, 0, 0, 255);
            RemMat[matnum].mainTextureScale = new Vector2(1, 0.25f);
            RemMat[matnum].SetTextureOffset("_MainTex", new Vector2(0, 0.75f));
            if (matnum == 0)
            {
                topMat.color = new Color32(255, 0, 0, 255);
            }
        }
    }

    void topColorChooser(int mn)
    {
        switch(mn)
        {
            case 0:
                topMat.color = new Color32(255, 0, 0, 255);
                break;
            case 1:
                topMat.color = new Color32(255, 255, 255, 255);
                break;
            case 2:
                topMat.color = new Color32(255, 0, 160, 255);
                break;
            case 3:
                topMat.gameObject.SetActive(false);
                break;
            case 4:
                topMat.gameObject.SetActive(false);
                break;
            case 5:
                topMat.gameObject.SetActive(false);
                break;
            case 6:
                topMat.gameObject.SetActive(false);
                break;
            case 7:
                topMat.gameObject.SetActive(false);
                break;
            case 8:
                topMat.gameObject.SetActive(false);
                break;
            case 9:
                topMat.gameObject.SetActive(false);
                break;
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
