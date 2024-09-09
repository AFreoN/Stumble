using UnityEngine;

public class RemBlock : MonoBehaviour
{
    public int ForceX, ForceZ;
    Rigidbody rb;
    int[] sign = { -1, 1 };

	void Awake ()
    {
        rb = GetComponent<Rigidbody>();
        int ForceY = Random.Range(20, 36);
        rb.AddForce(ForceX, ForceY, ForceZ, ForceMode.Impulse);
        Destroy(gameObject, 4);
	}
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            int s = Random.Range(0, 2);
            rb.AddForce(ForceX*sign[s], Random.Range(20, 41), ForceZ*sign[s], ForceMode.Impulse);
        }
    }
}
