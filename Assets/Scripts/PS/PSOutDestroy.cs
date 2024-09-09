using UnityEngine;

public class PSOutDestroy : MonoBehaviour {

    private void Awake()
    {
        Destroy(gameObject, 0.5f);
    }
}
