using UnityEngine;

public class GroundColor : MonoBehaviour {

    Renderer rend;
    int matNum;
    public Material[] GMaterial;

	void Start ()
    {
        matNum = PlayerPrefs.GetInt("MatNum", 0);
        rend = GetComponent<Renderer>();
        if (matNum < 2)
        {
            rend.material = GMaterial[0];
        }
        else
        {
            rend.material = GMaterial[matNum - 1];
        }
	}
}
