using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Camera camera1;
    public Transform faller;
    public Transform tapPS;
    public Transform holeFall;
    public Transform[] OutBlock;

    //For PS
    public Transform TapOutsidePS;
    public Transform TapWrongPS;
    public Transform thunderPS;

	
	// Update is called once per frame
	void Update ()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0) && GameManager.dead == false && GameManager.startGame == true)
        {
            Ray ray = camera1.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag =="Hole")
                {
                    AudioManager.instance.Play("WrongTap");
                    Instantiate(TapWrongPS, hit.transform.position, TapWrongPS.rotation);
                    hit.transform.gameObject.SetActive(false);
                    Instantiate(holeFall, hit.transform.position, hit.transform.rotation);
                    Instantiate(faller, hit.transform.position, hit.transform.rotation);
                }
                if(hit.transform.tag == "Blocks")
                {
                    if (FillBar.superPower == false)
                    {
                        Instantiate(TapOutsidePS, hit.transform.position, TapOutsidePS.rotation);
                        AudioManager.instance.Play("Laser" + hit.transform.localScale.y * 2);
                        Vector3 outBlockPOS1 = new Vector3(hit.transform.position.x - 0.5f, hit.transform.localScale.y, hit.transform.position.z - 0.5f);
                        Vector3 outBlockPOS2 = new Vector3(hit.transform.position.x + 0.5f, hit.transform.localScale.y, hit.transform.position.z - 0.5f);
                        Vector3 outBlockPOS3 = new Vector3(hit.transform.position.x + 0.5f, hit.transform.localScale.y, hit.transform.position.z + 0.5f);
                        Vector3 outBlockPOS4 = new Vector3(hit.transform.position.x - 0.5f, hit.transform.localScale.y, hit.transform.position.z + 0.5f);
                        Vector3[] all = { outBlockPOS1, outBlockPOS2, outBlockPOS3, outBlockPOS4 };
                        for (int i = 0; i < OutBlock.Length; i++)
                        {
                            Transform t = Instantiate(OutBlock[i], all[i], Quaternion.identity);
                            t.gameObject.GetComponent<Renderer>().material.color = hit.transform.gameObject.GetComponent<Renderer>().material.color;
                            t.gameObject.GetComponent<TrailRenderer>().startColor = hit.transform.gameObject.GetComponent<Renderer>().material.color;
                            t.gameObject.GetComponent<TrailRenderer>().endColor = hit.transform.gameObject.GetComponent<Renderer>().material.color;
                        }
                        if (hit.transform.localScale.y != 0.5f)
                        {
                            hit.transform.localScale = new Vector3(hit.transform.localScale.x, hit.transform.localScale.y - 0.5f, hit.transform.localScale.z);
                            hit.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y - 0.25f, hit.transform.position.z);
                            Transform psTap = Instantiate(tapPS, new Vector3(hit.transform.position.x, hit.transform.position.y + 0.25f, hit.transform.position.z), Quaternion.identity);
                            var main = psTap.gameObject.GetComponent<ParticleSystem>().main;
                            main.startColor = hit.transform.gameObject.GetComponent<Renderer>().material.color;
                            KeyValues.scoreCount += 1;
                        }
                        else if (hit.transform.localScale.y == 0.5f)
                        {
                            hit.transform.gameObject.SetActive(false);
                            Instantiate(tapPS, new Vector3(hit.transform.position.x, hit.transform.position.y - 0.25f, hit.transform.position.z), Quaternion.identity);
                            KeyValues.scoreCount += 1;
                        }
                    }
                    else
                    {
                        AudioManager.instance.Play("Thunder");
                        Instantiate(TapOutsidePS, hit.transform.position, TapOutsidePS.rotation);
                        Instantiate(thunderPS, new Vector3(hit.transform.position.x, 10, 0), thunderPS.rotation);
                        Vector3 outBlockPOS1 = new Vector3(hit.transform.position.x - 0.5f, hit.transform.localScale.y, hit.transform.position.z - 0.5f);
                        Vector3 outBlockPOS2 = new Vector3(hit.transform.position.x + 0.5f, hit.transform.localScale.y, hit.transform.position.z - 0.5f);
                        Vector3 outBlockPOS3 = new Vector3(hit.transform.position.x + 0.5f, hit.transform.localScale.y, hit.transform.position.z + 0.5f);
                        Vector3 outBlockPOS4 = new Vector3(hit.transform.position.x - 0.5f, hit.transform.localScale.y, hit.transform.position.z + 0.5f);
                        Vector3[] all = { outBlockPOS1, outBlockPOS2, outBlockPOS3, outBlockPOS4 };
                        for (int i = 0; i < OutBlock.Length; i++)
                        {
                            for (float j = 0; j < hit.transform.localScale.y * 2; j++)
                            {
                                Transform t = Instantiate(OutBlock[i], new Vector3(all[i].x,all[i].y - 0.5f*j,all[i].z), Quaternion.identity);
                                t.gameObject.GetComponent<Renderer>().material.color = hit.transform.gameObject.GetComponent<Renderer>().material.color;
                                t.gameObject.GetComponent<TrailRenderer>().startColor = hit.transform.gameObject.GetComponent<Renderer>().material.color;
                                t.gameObject.GetComponent<TrailRenderer>().endColor = hit.transform.gameObject.GetComponent<Renderer>().material.color;
                            }
                        }
                        hit.transform.gameObject.SetActive(false);
                        Instantiate(tapPS, new Vector3(hit.transform.position.x, hit.transform.position.y - 0.25f, hit.transform.position.z), Quaternion.identity);
                        float scoretoIncrease = hit.transform.localScale.y * 2;
                        KeyValues.scoreCount += (int)scoretoIncrease;
                    }
                }
            }
        }
#endif
#if UNITY_ANDROID
        if (Input.touchCount > 0 && GameManager.dead == false && GameManager.startGame == true)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = camera1.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.tag == "Hole")
                    {
                        AudioManager.instance.Play("WrongTap");
                        Instantiate(TapWrongPS, hit.transform.position, TapWrongPS.rotation);
                        hit.transform.gameObject.SetActive(false);
                        Instantiate(holeFall, hit.transform.position, hit.transform.rotation);
                        Instantiate(faller, hit.transform.position, hit.transform.rotation);
                    }
                    if (hit.transform.tag == "Blocks")
                    {
                        if (FillBar.superPower == false)
                        {
                            Instantiate(TapOutsidePS, hit.transform.position, TapOutsidePS.rotation);
                            AudioManager.instance.Play("Laser" + hit.transform.localScale.y * 2);
                            Vector3 outBlockPOS1 = new Vector3(hit.transform.position.x - 0.5f, hit.transform.localScale.y, hit.transform.position.z - 0.5f);
                            Vector3 outBlockPOS2 = new Vector3(hit.transform.position.x + 0.5f, hit.transform.localScale.y, hit.transform.position.z - 0.5f);
                            Vector3 outBlockPOS3 = new Vector3(hit.transform.position.x + 0.5f, hit.transform.localScale.y, hit.transform.position.z + 0.5f);
                            Vector3 outBlockPOS4 = new Vector3(hit.transform.position.x - 0.5f, hit.transform.localScale.y, hit.transform.position.z + 0.5f);
                            Vector3[] all = { outBlockPOS1, outBlockPOS2, outBlockPOS3, outBlockPOS4 };
                            for (int i = 0; i < OutBlock.Length; i++)
                            {
                                Transform t = Instantiate(OutBlock[i], all[i], Quaternion.identity);
                                t.gameObject.GetComponent<Renderer>().material.color = hit.transform.gameObject.GetComponent<Renderer>().material.color;
                                t.gameObject.GetComponent<TrailRenderer>().startColor = hit.transform.gameObject.GetComponent<Renderer>().material.color;
                                t.gameObject.GetComponent<TrailRenderer>().endColor = hit.transform.gameObject.GetComponent<Renderer>().material.color;
                            }
                            if (hit.transform.localScale.y != 0.5f)
                            {
                                hit.transform.localScale = new Vector3(hit.transform.localScale.x, hit.transform.localScale.y - 0.5f, hit.transform.localScale.z);
                                hit.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y - 0.25f, hit.transform.position.z);
                                Transform psTap = Instantiate(tapPS, new Vector3(hit.transform.position.x, hit.transform.position.y + 0.25f, hit.transform.position.z), Quaternion.identity);
                                var main = psTap.gameObject.GetComponent<ParticleSystem>().main;
                                main.startColor = hit.transform.gameObject.GetComponent<Renderer>().material.color;
                                KeyValues.scoreCount += 1;
                            }
                            else if (hit.transform.localScale.y == 0.5f)
                            {
                                hit.transform.gameObject.SetActive(false);
                                Instantiate(tapPS, new Vector3(hit.transform.position.x, hit.transform.position.y - 0.25f, hit.transform.position.z), Quaternion.identity);
                                KeyValues.scoreCount += 1;
                            }
                        }
                        else
                        {
                            AudioManager.instance.Play("Thunder");
                            Instantiate(TapOutsidePS, hit.transform.position, TapOutsidePS.rotation);
                            Instantiate(thunderPS, new Vector3(hit.transform.position.x, 10, 0), thunderPS.rotation);
                            Vector3 outBlockPOS1 = new Vector3(hit.transform.position.x - 0.5f, hit.transform.localScale.y, hit.transform.position.z - 0.5f);
                            Vector3 outBlockPOS2 = new Vector3(hit.transform.position.x + 0.5f, hit.transform.localScale.y, hit.transform.position.z - 0.5f);
                            Vector3 outBlockPOS3 = new Vector3(hit.transform.position.x + 0.5f, hit.transform.localScale.y, hit.transform.position.z + 0.5f);
                            Vector3 outBlockPOS4 = new Vector3(hit.transform.position.x - 0.5f, hit.transform.localScale.y, hit.transform.position.z + 0.5f);
                            Vector3[] all = { outBlockPOS1, outBlockPOS2, outBlockPOS3, outBlockPOS4 };
                            for (int i = 0; i < OutBlock.Length; i++)
                            {
                                for (float j = 0; j < hit.transform.localScale.y * 2; j++)
                                {
                                    Transform t = Instantiate(OutBlock[i], new Vector3(all[i].x, all[i].y - 0.5f * j, all[i].z), Quaternion.identity);
                                    t.gameObject.GetComponent<Renderer>().material.color = hit.transform.gameObject.GetComponent<Renderer>().material.color;
                                    t.gameObject.GetComponent<TrailRenderer>().startColor = hit.transform.gameObject.GetComponent<Renderer>().material.color;
                                    t.gameObject.GetComponent<TrailRenderer>().endColor = hit.transform.gameObject.GetComponent<Renderer>().material.color;
                                }
                            }
                            hit.transform.gameObject.SetActive(false);
                            Instantiate(tapPS, new Vector3(hit.transform.position.x, hit.transform.position.y - 0.25f, hit.transform.position.z), Quaternion.identity);
                            float scoretoIncrease = hit.transform.localScale.y * 2;
                            KeyValues.scoreCount += (int)scoretoIncrease;
                        }
                    }
                }
            }
        }
#endif
    }
}
