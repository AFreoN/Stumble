using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSize : MonoBehaviour
{
    public Transform playerBox;
    Transform tr;
	void Start ()
    {
		for(int i =1;i < 3;i++)
        {
            tr = Instantiate(playerBox, new Vector3(transform.position.x, 0.5f * i + 0.5f, 0), playerBox.rotation) as Transform;
            tr.SetParent(this.gameObject.transform);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
