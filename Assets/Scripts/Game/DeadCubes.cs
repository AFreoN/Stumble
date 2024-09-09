using UnityEngine;

public class DeadCubes : MonoBehaviour
{

    Rigidbody rb;
    int[] multiplier = { -1, 1 };

	void OnEnable ()
    {
        int mul = Random.Range(0, 2);
        rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(100, 20, 100*multiplier[mul]), ForceMode.Impulse);
	}
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
