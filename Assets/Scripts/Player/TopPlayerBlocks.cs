using UnityEngine;

public class TopPlayerBlocks : MonoBehaviour {

    public int matNum;

	void Start ()
    {
		if(PlayerPrefs.GetInt("MatNum",0) != matNum)
        {
            gameObject.SetActive(false);
        }
	}

    private void Update()
    {
        if(GameManager.dead == true && gameObject.activeInHierarchy == true)
        {
            gameObject.SetActive(false);
        }
    }
}
