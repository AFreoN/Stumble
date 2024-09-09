using System.Collections;
using UnityEngine;

public class BlockHitConrontroller : MonoBehaviour {

    public static bool hitted = false;
    public static BlockHitConrontroller instance;

    private void Awake()
    {
        instance = this;
        hitted = false;
    }
    private void OnEnable()
    {
        instance = this;
        hitted = false;
    }
    private void OnBecameInvisible()
    {
        instance = this;
        hitted = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            hitted = true;
            StartCoroutine(makeFalse());
        }
    }
    IEnumerator makeFalse()
    {
        yield return new WaitForSeconds(1);
        hitted = false;
    }
}
