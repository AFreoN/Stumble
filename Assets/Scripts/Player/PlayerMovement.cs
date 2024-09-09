using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public static PlayerMovement instance;

    [SerializeField]
    private float playerSpeed;
    public float gravity;
    float gravStore;
    float Yscale = 2;
    Rigidbody rb;
    public Transform holeFill;
    public Transform FallTrigger;
    public Transform RemPlayer;

    //For Material
    public Material[] PlayerMaterial;
    int MatNum;

    public static bool moveFast = false;
    public static float SpeedMultiplier = 1;

    GameManager GM;
    Vector3 playerSize;
    public static float forHole =2;
    public static float forRemPlayer = 2;

    //For Checking Player Movement
    float prevPOS;
    float timer = 0;
    Quaternion playerRot;

    private void Awake()
    {
        instance = this;
        SpeedMultiplier = 1;
        forHole = 2;
        forRemPlayer = 2;
        moveFast = false;
        gravStore = gravity;
    }

    private void Start()
    {
        matChooser();
        playerSize = transform.localScale;
        this.GetComponent<Renderer>().sharedMaterial = PlayerMaterial[MatNum];
        rb = GetComponent<Rigidbody>();
        GM = GameManager.instance;
        transform.localScale = new Vector3(2, Yscale, 2);
        transform.position = new Vector3(0, 1.25f, 0);
        Yscale -= 0.5f;
        prevPOS = transform.position.x-1;
        playerRot = transform.rotation;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "FallTrigger")
        {
            Destroy(other.gameObject);
            if (transform.localScale.y > 0.5f)
            {
                AudioManager.instance.Play("SliceBlock");
                transform.localScale = new Vector3(2, transform.localScale.y - 0.5f, 2);
                transform.position = new Vector3(transform.position.x, transform.localScale.y / 2 + 0.25f, transform.position.z);
                Instantiate(holeFill, new Vector3(other.transform.position.x - 2, other.transform.position.y - 0.5f, 0), other.transform.rotation);
                Yscale -= 0.5f;
                forHole -= 0.5f;
                forRemPlayer -= 0.5f;
            }
            else if(GameManager.dead == false)
            {
                AudioManager.instance.Play("SliceBlock");
                transform.localScale = new Vector3(2, transform.localScale.y - 0.5f, 2);
                transform.position = new Vector3(transform.position.x, transform.localScale.y / 2 + 0.25f, transform.position.z);
                Instantiate(holeFill, new Vector3(other.transform.position.x - 2, other.transform.position.y - 0.5f, 0), other.transform.rotation);
                forHole -= 0.5f;
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
                gameObject.transform.GetChild(1).gameObject.SetActive(false);
                Renderer rend = GetComponent<MeshRenderer>();
                rend.enabled = false;
                GM.death();
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Fall")
        {
            Instantiate(FallTrigger, new Vector3(collision.transform.position.x + 2, collision.transform.position.y + 0.5f, 0), collision.transform.rotation);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Blocks" && BlockHitConrontroller.hitted == false)
        {
            float Yminus = transform.localScale.y - collision.transform.localScale.y;
            if (Yminus > 0)
            {
                AudioManager.instance.Play("SliceBlock");   
                transform.localScale = new Vector3(2, Yminus, 2);
                Vector3 RemPos = new Vector3(collision.transform.position.x - 2, collision.transform.position.y, 0);
                Transform T = Instantiate(RemPlayer, RemPos, RemPlayer.rotation);
                T.localScale = new Vector3(T.localScale.x, collision.transform.localScale.y, T.localScale.z);
            }
            else if(GameManager.dead == false)
            {
                //Transform T = Instantiate(RemPlayer, RemPos, RemPlayer.rotation);
                //T.localScale = new Vector3(T.localScale.x, transform.localScale.y, T.localScale.z);
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
                gameObject.transform.GetChild(1).gameObject.SetActive(false);
                Renderer rend = GetComponent<MeshRenderer>();
                rend.enabled = false;
                GM.death();
            }
            transform.position = new Vector3(transform.position.x, Yminus / 2 + collision.transform.localScale.y + 0.5f, 0);
            StartCoroutine(rem());
        }
    }

    IEnumerator rem()
    {
        yield return new WaitForSeconds(0.5f);
        forRemPlayer = transform.localScale.y;
    }

    private void Update()
    {
        if(GameManager.dead == false && GameManager.startGame == true)
        {
            if(transform.rotation != playerRot)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, playerRot, 0.5f);
            }
        }
        if(playerSize != transform.localScale)
        {
            matChooser();
            forHole = transform.localScale.y;
            if (transform.localScale.y <= 1)
            {
                gravity = 100;
            }
            else
            {
                gravity = gravStore;
            }
        }
        if(GameManager.startGame == true && timer < 1)
        {
            timer += Time.deltaTime;
        }
        else if(GameManager.startGame == true && timer >= 1)
        {
            timer = 0;
            if (prevPOS != transform.position.x)
            {
                prevPOS = transform.position.x;
            }
            else if(prevPOS == transform.position.x)
            {
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
                Renderer rend = GetComponent<MeshRenderer>();
                rend.enabled = false;
                GM.death();
            }
        }
    }
    private void matChooser()
    {
        MatNum = PlayerPrefs.GetInt("MatNum", 0);
        float scaleY = transform.localScale.y;
        if (scaleY == 2)
        {
            PlayerMaterial[MatNum].mainTextureScale = new Vector2(1, 1);
            PlayerMaterial[MatNum].SetTextureOffset("_MainTex", new Vector2(0, 0));
            playerSize = transform.localScale;
        }
        else if (scaleY == 1.5f)
        {
            PlayerMaterial[MatNum].mainTextureScale = new Vector2(1, 0.75f);
            PlayerMaterial[MatNum].SetTextureOffset("_MainTex" ,new Vector2(0, 0.25f));
            playerSize = transform.localScale;
        }
        else if (scaleY == 1)
        {
            PlayerMaterial[MatNum].mainTextureScale = new Vector2(1, 0.5f);
            PlayerMaterial[MatNum].SetTextureOffset("_MainTex", new Vector2(0, 0.5f));
            playerSize = transform.localScale;
        }
        else if (scaleY == 0.5f)
        {
            PlayerMaterial[MatNum].mainTextureScale = new Vector2(1, 0.25f);
            PlayerMaterial[MatNum].SetTextureOffset("_MainTex", new Vector2(0, 0.75f));
            playerSize = transform.localScale;
        }
    }


    private void FixedUpdate()
    {
        if (GameManager.startGame == true)
        {
            if (moveFast == false)
            {
                rb.velocity = new Vector3(playerSpeed * Time.deltaTime, -gravity * Time.deltaTime, 0);
            }
            else if(moveFast == true)
            {
                rb.velocity = new Vector3(playerSpeed * Time.deltaTime * SpeedMultiplier, -gravity * Time.deltaTime, 0);
            }
        }
    }
}
