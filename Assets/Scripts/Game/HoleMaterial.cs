using UnityEngine;

public class HoleMaterial : MonoBehaviour {

    public Material Mdeafult;
    public Material blossom;
    public Material brick1;
    public Material brick2;
    public Material rectro;
    public Material Leather;
    public Material wood;
    public Material Steel;
    public Material Check;

    int matnum;
    Renderer rend;

	void Start ()
    {
        rend = GetComponent<Renderer>();
        matnum = PlayerPrefs.GetInt("MatNum", 0);
        matChoose(matnum);
	}

    void matChoose(int m)
    {
        switch(m)
        {
            case 0:
                rend.material = Mdeafult;
                break;
            case 1:
                rend.material = Mdeafult;
                break;
            case 2:
                rend.material = blossom;
                break;
            case 3:
                rend.material = brick1;
                break;
            case 4:
                rend.material = brick2;
                break;
            case 5:
                rend.material = rectro;
                break;
            case 6:
                rend.material = Leather;
                break;
            case 7:
                rend.material = wood;
                break;
            case 8:
                rend.material = Steel;
                break;
            case 9:
                rend.material = Check;
                break;
        }
    }
}
