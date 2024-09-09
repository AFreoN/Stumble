using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDeadCubes : MonoBehaviour
{
    objectPooler op;
    public Transform[] deadCubes;
    public Transform WhiteCubes;
    bool ready = true;
    public Transform player;

    int matnum;

    void Start()
    {
        op = objectPooler.Instance;
        matnum = PlayerPrefs.GetInt("MatNum", 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.dead == true && ready == true)
        {
            AudioManager.instance.Play("Explosion");
            float s = player.localScale.y * 2;
            if (matnum == 0)
            {
                CubeSpawn(s);
            }
            else if (matnum != 9)
            {
                SpawnBuyedDeadCubes(s);
            }
            else if (matnum == 9)
            {
                SpawnCheckBox(s);
            }
            ready = false;
        }
    }
    #region Default Color
    private void CubeSpawn(float s)
    {
        switch ((int)s)
        {
            case 1:
                for (int i = 1; i < 5; i++)
                {
                    for (int j = 1; j < 5; j++)
                    {
                        op.SpawnformPool("RDeadCube", new Vector3(player.position.x + 1.25f - 0.5f * i, player.position.y - 0.5f, player.position.z + 1.25f - 0.5f * j), Quaternion.identity);
                    }
                }
                break;
            case 2:
                for (int i = 1; i < 5; i++)
                {
                    for (int j = 1; j < 5; j++)
                    {
                        op.SpawnformPool("RDeadCube", new Vector3(player.position.x + 1.25f - 0.5f * i, player.position.y, player.position.z + 1.25f - 0.5f * j), Quaternion.identity);
                    }
                }
                for (int i = 1; i < 5; i++)
                {
                    for (int j = 1; j < 5; j++)
                    {
                        op.SpawnformPool("ODeadCube", new Vector3(player.position.x + 1.25f - 0.5f * i, player.position.y - 0.5f, player.position.z + 1.25f - 0.5f * j), Quaternion.identity);
                    }
                }
                break;
            case 3:
                for (int i = 1; i < 5; i++)
                {
                    for (int j = 1; j < 5; j++)
                    {
                        op.SpawnformPool("RDeadCube", new Vector3(player.position.x + 1.25f - 0.5f * i, player.position.y + 0.5f, player.position.z + 1.25f - 0.5f * j), Quaternion.identity);
                    }
                }
                for (int i = 1; i < 5; i++)
                {
                    for (int j = 1; j < 5; j++)
                    {
                        op.SpawnformPool("ODeadCube", new Vector3(player.position.x + 1.25f - 0.5f * i, player.position.y, player.position.z + 1.25f - 0.5f * j), Quaternion.identity);
                    }
                }
                for (int i = 1; i < 5; i++)
                {
                    for (int j = 1; j < 5; j++)
                    {
                        op.SpawnformPool("YDeadCube", new Vector3(player.position.x + 1.25f - 0.5f * i, player.position.y - 0.5f, player.position.z + 1.25f - 0.5f * j), Quaternion.identity);
                    }
                }
                break;
            case 4:
                for (int i = 1; i < 5; i++)
                {
                    for (int j = 1; j < 5; j++)
                    {
                        op.SpawnformPool("RDeadCube", new Vector3(player.position.x + 1.25f - 0.5f * i, player.position.y + 1, player.position.z + 1.25f - 0.5f * j), Quaternion.identity);
                    }
                }
                for (int i = 1; i < 5; i++)
                {
                    for (int j = 1; j < 5; j++)
                    {
                        op.SpawnformPool("ODeadCube", new Vector3(player.position.x + 1.25f - 0.5f * i, player.position.y + 0.5f, player.position.z + 1.25f - 0.5f * j), Quaternion.identity);
                    }
                }
                for (int i = 1; i < 5; i++)
                {
                    for (int j = 1; j < 5; j++)
                    {
                        op.SpawnformPool("YDeadCube", new Vector3(player.position.x + 1.25f - 0.5f * i, player.position.y, player.position.z + 1.25f - 0.5f * j), Quaternion.identity);
                    }
                }
                for (int i = 1; i < 5; i++)
                {
                    for (int j = 1; j < 5; j++)
                    {
                        op.SpawnformPool("GDeadCube", new Vector3(player.position.x + 1.25f - 0.5f * i, player.position.y - 0.5f, player.position.z + 1.25f - 0.5f * j), Quaternion.identity);
                    }
                }
                break;
        }
    }
    #endregion

    #region UpTo matnum 8
    void SpawnBuyedDeadCubes(float c)
    {
        switch ((int)c)
        {
            case 1:
                for (int i = 1; i < 5; i++)
                {
                    for (int j = 1; j < 5; j++)
                    {
                        Instantiate(deadCubes[matnum - 1], new Vector3(player.position.x + 1.25f - 0.5f * i, player.position.y - 0.5f, player.position.z + 1.25f - 0.5f * j), Quaternion.identity);
                    }
                }
                break;
            case 2:
                for (int i = 1; i < 5; i++)
                {
                    for (int j = 1; j < 5; j++)
                    {
                        Instantiate(deadCubes[matnum - 1], new Vector3(player.position.x + 1.25f - 0.5f * i, player.position.y, player.position.z + 1.25f - 0.5f * j), Quaternion.identity);
                    }
                }
                for (int i = 1; i < 5; i++)
                {
                    for (int j = 1; j < 5; j++)
                    {
                        Instantiate(deadCubes[matnum - 1], new Vector3(player.position.x + 1.25f - 0.5f * i, player.position.y - 0.5f, player.position.z + 1.25f - 0.5f * j), Quaternion.identity);
                    }
                }
                break;
            case 3:
                for (int i = 1; i < 5; i++)
                {
                    for (int j = 1; j < 5; j++)
                    {
                        Instantiate(deadCubes[matnum - 1], new Vector3(player.position.x + 1.25f - 0.5f * i, player.position.y + 0.5f, player.position.z + 1.25f - 0.5f * j), Quaternion.identity);
                    }
                }
                for (int i = 1; i < 5; i++)
                {
                    for (int j = 1; j < 5; j++)
                    {
                        Instantiate(deadCubes[matnum - 1], new Vector3(player.position.x + 1.25f - 0.5f * i, player.position.y, player.position.z + 1.25f - 0.5f * j), Quaternion.identity);
                    }
                }
                for (int i = 1; i < 5; i++)
                {
                    for (int j = 1; j < 5; j++)
                    {
                        Instantiate(deadCubes[matnum - 1], new Vector3(player.position.x + 1.25f - 0.5f * i, player.position.y - 0.5f, player.position.z + 1.25f - 0.5f * j), Quaternion.identity);
                    }
                }
                break;
            case 4:
                for (int i = 1; i < 5; i++)
                {
                    for (int j = 1; j < 5; j++)
                    {
                        Instantiate(deadCubes[matnum - 1], new Vector3(player.position.x + 1.25f - 0.5f * i, player.position.y + 1, player.position.z + 1.25f - 0.5f * j), Quaternion.identity);
                    }
                }
                for (int i = 1; i < 5; i++)
                {
                    for (int j = 1; j < 5; j++)
                    {
                        Instantiate(deadCubes[matnum - 1], new Vector3(player.position.x + 1.25f - 0.5f * i, player.position.y + 0.5f, player.position.z + 1.25f - 0.5f * j), Quaternion.identity);
                    }
                }
                for (int i = 1; i < 5; i++)
                {
                    for (int j = 1; j < 5; j++)
                    {
                        Instantiate(deadCubes[matnum - 1], new Vector3(player.position.x + 1.25f - 0.5f * i, player.position.y, player.position.z + 1.25f - 0.5f * j), Quaternion.identity);
                    }
                }
                for (int i = 1; i < 5; i++)
                {
                    for (int j = 1; j < 5; j++)
                    {
                        Instantiate(deadCubes[matnum - 1], new Vector3(player.position.x + 1.25f - 0.5f * i, player.position.y - 0.5f, player.position.z + 1.25f - 0.5f * j), Quaternion.identity);
                    }
                }
                break;
        }
    }
    #endregion

    #region For Matnum 9(Chech Layer)
    void SpawnCheckBox(float c)
    {
        bool white = true;
        switch ((int)c)
        {
            case 1:
                for (int i = 1; i < 5; i++)
                {
                    for (int j = 1; j < 5; j++)
                    {
                        if (white == false)
                        {
                            white = true;
                            Instantiate(deadCubes[matnum - 1], new Vector3(player.position.x + 1.25f - 0.5f * i, player.position.y - 0.5f, player.position.z + 1.25f - 0.5f * j), Quaternion.identity);
                        }
                        else if (white == true)
                        {
                            white = false;
                            Instantiate(WhiteCubes, new Vector3(player.position.x + 1.25f - 0.5f * i, player.position.y - 0.5f, player.position.z + 1.25f - 0.5f * j), Quaternion.identity);
                        }
                    }
                }
                break;
            case 2:
                for (int i = 1; i < 5; i++)
                {
                    for (int j = 1; j < 5; j++)
                    {
                        if (white == false)
                        {
                            white = true;
                            Instantiate(deadCubes[matnum - 1], new Vector3(player.position.x + 1.25f - 0.5f * i, player.position.y - 0.5f, player.position.z + 1.25f - 0.5f * j), Quaternion.identity);
                        }
                        else if (white == true)
                        {
                            white = false;
                            Instantiate(WhiteCubes, new Vector3(player.position.x + 1.25f - 0.5f * i, player.position.y - 0.5f, player.position.z + 1.25f - 0.5f * j), Quaternion.identity);
                        }
                    }
                }
                for (int i = 1; i < 5; i++)
                {
                    for (int j = 1; j < 5; j++)
                    {
                        if (white == false)
                        {
                            white = true;
                            Instantiate(deadCubes[matnum - 1], new Vector3(player.position.x + 1.25f - 0.5f * i, player.position.y - 0.5f, player.position.z + 1.25f - 0.5f * j), Quaternion.identity);
                        }
                        else if (white == true)
                        {
                            white = false;
                            Instantiate(WhiteCubes, new Vector3(player.position.x + 1.25f - 0.5f * i, player.position.y - 0.5f, player.position.z + 1.25f - 0.5f * j), Quaternion.identity);
                        }
                    }
                }
                break;
            case 3:
                for (int i = 1; i < 5; i++)
                {
                    for (int j = 1; j < 5; j++)
                    {
                        if (white == false)
                        {
                            white = true;
                            Instantiate(deadCubes[matnum - 1], new Vector3(player.position.x + 1.25f - 0.5f * i, player.position.y - 0.5f, player.position.z + 1.25f - 0.5f * j), Quaternion.identity);
                        }
                        else if (white == true)
                        {
                            white = false;
                            Instantiate(WhiteCubes, new Vector3(player.position.x + 1.25f - 0.5f * i, player.position.y - 0.5f, player.position.z + 1.25f - 0.5f * j), Quaternion.identity);
                        }
                    }
                }
                for (int i = 1; i < 5; i++)
                {
                    for (int j = 1; j < 5; j++)
                    {
                        if (white == false)
                        {
                            white = true;
                            Instantiate(deadCubes[matnum - 1], new Vector3(player.position.x + 1.25f - 0.5f * i, player.position.y - 0.5f, player.position.z + 1.25f - 0.5f * j), Quaternion.identity);
                        }
                        else if (white == true)
                        {
                            white = false;
                            Instantiate(WhiteCubes, new Vector3(player.position.x + 1.25f - 0.5f * i, player.position.y - 0.5f, player.position.z + 1.25f - 0.5f * j), Quaternion.identity);
                        }
                    }
                }
                for (int i = 1; i < 5; i++)
                {
                    for (int j = 1; j < 5; j++)
                    {
                        if (white == false)
                        {
                            white = true;
                            Instantiate(deadCubes[matnum - 1], new Vector3(player.position.x + 1.25f - 0.5f * i, player.position.y - 0.5f, player.position.z + 1.25f - 0.5f * j), Quaternion.identity);
                        }
                        else if (white == true)
                        {
                            white = false;
                            Instantiate(WhiteCubes, new Vector3(player.position.x + 1.25f - 0.5f * i, player.position.y - 0.5f, player.position.z + 1.25f - 0.5f * j), Quaternion.identity);
                        }
                    }
                }
                break;
            case 4:
                for (int i = 1; i < 5; i++)
                {
                    for (int j = 1; j < 5; j++)
                    {
                        if (white == false)
                        {
                            white = true;
                            Instantiate(deadCubes[matnum - 1], new Vector3(player.position.x + 1.25f - 0.5f * i, player.position.y - 0.5f, player.position.z + 1.25f - 0.5f * j), Quaternion.identity);
                        }
                        else if (white == true)
                        {
                            white = false;
                            Instantiate(WhiteCubes, new Vector3(player.position.x + 1.25f - 0.5f * i, player.position.y - 0.5f, player.position.z + 1.25f - 0.5f * j), Quaternion.identity);
                        }
                    }
                }
                for (int i = 1; i < 5; i++)
                {
                    for (int j = 1; j < 5; j++)
                    {
                        if (white == false)
                        {
                            white = true;
                            Instantiate(deadCubes[matnum - 1], new Vector3(player.position.x + 1.25f - 0.5f * i, player.position.y - 0.5f, player.position.z + 1.25f - 0.5f * j), Quaternion.identity);
                        }
                        else if (white == true)
                        {
                            white = false;
                            Instantiate(WhiteCubes, new Vector3(player.position.x + 1.25f - 0.5f * i, player.position.y - 0.5f, player.position.z + 1.25f - 0.5f * j), Quaternion.identity);
                        }
                    }
                }
                for (int i = 1; i < 5; i++)
                {
                    for (int j = 1; j < 5; j++)
                    {
                        if (white == false)
                        {
                            white = true;
                            Instantiate(deadCubes[matnum - 1], new Vector3(player.position.x + 1.25f - 0.5f * i, player.position.y - 0.5f, player.position.z + 1.25f - 0.5f * j), Quaternion.identity);
                        }
                        else if (white == true)
                        {
                            white = false;
                            Instantiate(WhiteCubes, new Vector3(player.position.x + 1.25f - 0.5f * i, player.position.y - 0.5f, player.position.z + 1.25f - 0.5f * j), Quaternion.identity);
                        }
                    }
                }
                for (int i = 1; i < 5; i++)
                {
                    for (int j = 1; j < 5; j++)
                    {
                        if (white == false)
                        {
                            white = true;
                            Instantiate(deadCubes[matnum - 1], new Vector3(player.position.x + 1.25f - 0.5f * i, player.position.y - 0.5f, player.position.z + 1.25f - 0.5f * j), Quaternion.identity);
                        }
                        else if (white == true)
                        {
                            white = false;
                            Instantiate(WhiteCubes, new Vector3(player.position.x + 1.25f - 0.5f * i, player.position.y - 0.5f, player.position.z + 1.25f - 0.5f * j), Quaternion.identity);
                        }
                    }
                }
                break;
        }
    }
    #endregion
}
