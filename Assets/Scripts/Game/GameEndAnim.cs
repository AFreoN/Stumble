using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndAnim : MonoBehaviour
{
    int[] multiplier = { -1, 1 };
    bool ready = true;
    public static bool play = false;
    int X, Y, Z; float rotX, rotY, rotZ;

    private void Awake()
    {
        ready = true;
        play = false;
        X = multiplier[Random.Range(0, 2)];
        Y = multiplier[Random.Range(0, 2)];
        Z = multiplier[Random.Range(0, 2)];
    }

    void Update()
    {
        if (play == true && ready == true)
        {
            rotX += Random.Range(120,240) * X * Time.deltaTime;
            rotY += Random.Range(120, 240) * Y * Time.deltaTime;
            rotZ += Random.Range(120, 240) * Z * Time.deltaTime;
            float forceX = Random.Range(0.6f, 1.2f) * X * Time.deltaTime;
            float forceY = Random.Range(7f, 10f) * Time.deltaTime;
            float forceZ = Random.Range(0.6f, 1.2f) * Z * Time.deltaTime;
            transform.Translate(forceX, forceY, forceZ,Space.World);
            //transform.Rotate(transform.position, 2);
            transform.localRotation = Quaternion.Euler(rotX, rotY, rotZ);
        }
    }
}
