using UnityEngine;

public class BlockColor : MonoBehaviour {

    Renderer rend;

	void Awake ()
    {
        rend = GetComponent<Renderer>();
        int red = Random.Range(0, 256);
        int green = Random.Range(0, 256);
        int blue = Random.Range(0, 256);
        rend.material.color = new Color32((byte)red, (byte)green, (byte)blue, 255);
	}
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
