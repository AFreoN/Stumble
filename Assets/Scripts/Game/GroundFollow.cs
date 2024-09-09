using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFollow : MonoBehaviour {
    Transform player;
    Vector3 offset;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        offset = player.position - transform.position;
    }

    private void FixedUpdate()
    {
        if (GameManager.dead == false)
        {
            Vector3 CurrentPos = player.position - offset;
            transform.position = Vector3.Lerp(transform.position, new Vector3(CurrentPos.x, transform.position.y, transform.position.z), 0.5f);
        }
    }
}
