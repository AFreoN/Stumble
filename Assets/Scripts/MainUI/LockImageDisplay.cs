using UnityEngine;
using UnityEngine.UI;

public class LockImageDisplay : MonoBehaviour
{

	void Start ()
    {
		if(transform.GetComponentInParent<Button>().interactable == false)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
	}
}
