using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform player;
    Vector3 offset;

	void Start ()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        offset = player.position - transform.position;
    }

    private void FixedUpdate()
    {
        if (GameManager.dead == false)
        {
            Vector3 cuurentPos = player.position - offset;
            transform.position = Vector3.Lerp(transform.position, cuurentPos, 0.5f);
        }
    }
}
