using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleColor : MonoBehaviour
{
    Renderer rend;
    public Material defMaterial;
    public Material blossom;
    public Material brick1;
    public Material brick2;
    public Material rectro;
    public Material Leather;
    public Material Wood;
    public Material Steel;
    public Material Check;

    void Start ()
    {
        rend = GetComponent<Renderer>();
        int Matnum = PlayerPrefs.GetInt("MatNum", 0);
        if(Matnum == 0)
        {
            rend.material = defMaterial;
        }
        colorChooser(Matnum);
	}
    void colorChooser(int m)
    {
        switch(m)
        {
            case 0:
                if (PlayerMovement.forHole == 1.5f)
                {
                    rend.material.color = new Color32(0, 255, 0, 255);
                }
                else if (PlayerMovement.forHole == 1)
                {
                    rend.material.color = new Color32(255, 255, 0, 255);
                }
                else if (PlayerMovement.forHole == 0.5f)
                {
                    rend.material.color = new Color32(207, 150, 0, 255);
                }
                else if (PlayerMovement.forHole == 0)
                {
                    rend.material.color = new Color32(255, 0, 0, 255);
                }
                break;
            case 1:
                rend.material = defMaterial;
                rend.material.color = new Color32(255, 255, 255, 255);
                break;
            case 2:
                rend.material = blossom;
                break;
            case 3:
                rend.sharedMaterial = brick1;
                break;
            case 4:
                rend.sharedMaterial = brick2;
                break;
            case 5:
                rend.sharedMaterial = rectro;
                break;
            case 6:
                rend.sharedMaterial = Leather;
                break;
            case 7:
                rend.sharedMaterial = Wood;
                break;
            case 8:
                rend.sharedMaterial = Steel;
                break;
            case 9:
                rend.sharedMaterial = Check;
                break;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Fall")
        {
            Destroy(collision.gameObject);
        }
    }
}
