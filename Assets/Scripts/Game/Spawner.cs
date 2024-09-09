using UnityEngine;

public class Spawner : MonoBehaviour {

    public Transform obstacles;
    public GameObject Blocks;
    Transform player;
    int spawnDis = 20;
    objectPooler op;
    float[] sizes = { 0.5f, 1, 1.5f, 2 };

	void Start ()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        op = objectPooler.Instance;
		for(int i=1; i < 21; i++)
        {
            if (i != 10)
            {
                float playerXpos =  2 * i;
                op.SpawnformPool("Hole", new Vector3(playerXpos, 0, 0), Quaternion.identity);
                
            }
            else
            {
                float playerXpos =  2 * i;
                op.SpawnformPool("Hole", new Vector3(playerXpos, 0, 0), Quaternion.identity);
                int sizeChooser = Random.Range(0, 4);
                GameObject currentBlock = Instantiate(Blocks, new Vector3(playerXpos, sizes[sizeChooser] / 2 + 0.25f, 0), Quaternion.identity);
                currentBlock.transform.localScale = new Vector3(2, sizes[sizeChooser], 2);
                //Instantiate(obstacles, new Vector3(playerXpos, 0, 0), obstacles.rotation);
                //Instantiate(obstacles, new Vector3(playerXpos, 0.5f, 0), obstacles.rotation);
                //Instantiate(obstacles, new Vector3(playerXpos, 1, 0), obstacles.rotation);
            }

        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (KeyValues.scoreCount <= 10)
        {
            if (player.position.x > spawnDis && GameManager.dead == false)
            {
                int randomer = Random.Range(0, 2);
                if (randomer == 0)
                {
                    randomSpawn1();
                }
                else if (randomer == 1)
                {
                    randomSpawn2();
                }
                spawnDis += 40;
            }
        }
        else if(KeyValues.scoreCount > 10)
        {
            if (player.position.x > spawnDis && GameManager.dead == false)
            {
                int randomer = Random.Range(0, 3);
                if (randomer == 0)
                {
                    randomSpawn1();
                }
                else if (randomer == 1)
                {
                    randomSpawn2();
                }
                else if(randomer == 2)
                {
                    randomSpawn3();
                }
                spawnDis += 40;
            }
        }
		
	}
    void randomSpawn1()
    {
        for (int i = 1; i < 21; i++)
        {
            if (i != 10)
            {
                float playerXpos = spawnDis + 20 + 2 * i;
                op.SpawnformPool("Hole", new Vector3(playerXpos, 0, 0), obstacles.rotation);
            }
            else
            {
                float playerXpos = spawnDis + 20 + 2 * i;
                op.SpawnformPool("Hole", new Vector3(playerXpos, 0, 0), Quaternion.identity);
                int sizeChooser = Random.Range(0, 4);
                GameObject currentBlock = Instantiate(Blocks, new Vector3(playerXpos, sizes[sizeChooser] / 2 + 0.25f, 0), Quaternion.identity);
                currentBlock.transform.localScale = new Vector3(2, sizes[sizeChooser], 2);
                //Instantiate(obstacles, new Vector3(playerXpos, 0, 0), obstacles.rotation);
                //Instantiate(obstacles, new Vector3(playerXpos, 0.5f, 0), obstacles.rotation);
                //Instantiate(obstacles, new Vector3(playerXpos, 1, 0), obstacles.rotation);
            }
        }
    }
    void randomSpawn2()
    {
        int a = Random.Range(4, 10);
        int b = Random.Range(13, 18);
        for (int i = 1; i < 21; i++)
        {
            if (i != a && i != b )
            {
                float playerXpos = spawnDis + 20 + 2 * i;
                op.SpawnformPool("Hole", new Vector3(playerXpos, 0, 0), obstacles.rotation);
            }
            else
            {
                float playerXpos = spawnDis + 20 + 2 * i;
                op.SpawnformPool("Hole", new Vector3(playerXpos, 0, 0), Quaternion.identity);
                int sizeChooser = Random.Range(0, 4);
                GameObject currentBlock = Instantiate(Blocks, new Vector3(playerXpos, sizes[sizeChooser] / 2 + 0.25f, 0), Quaternion.identity);
                currentBlock.transform.localScale = new Vector3(2, sizes[sizeChooser], 2);
                //Instantiate(obstacles, new Vector3(playerXpos, 0, 0), obstacles.rotation);
                //Instantiate(obstacles, new Vector3(playerXpos, 0.5f, 0), obstacles.rotation);
                //Instantiate(obstacles, new Vector3(playerXpos, 1, 0), obstacles.rotation);
            }
        }
    }
    void randomSpawn3()
    {

        int a = Random.Range(4, 8);
        int b = Random.Range(9, 13);
        int c = Random.Range(14, 18);
        for (int i = 1; i < 21; i++)
        {
            if (i != a && i != b && i != c)
            {
                float playerXpos = spawnDis + 20 + 2 * i;
                op.SpawnformPool("Hole", new Vector3(playerXpos, 0, 0), obstacles.rotation);
            }
            else
            {
                float playerXpos = spawnDis + 20 + 2 * i;
                op.SpawnformPool("Hole", new Vector3(playerXpos, 0, 0), Quaternion.identity);
                int sizeChooser = Random.Range(0, 4);
                GameObject currentBlock = Instantiate(Blocks, new Vector3(playerXpos, sizes[sizeChooser] / 2 + 0.25f, 0), Quaternion.identity);
                currentBlock.transform.localScale = new Vector3(2, sizes[sizeChooser], 2);
                //Instantiate(obstacles, new Vector3(playerXpos, 0, 0), obstacles.rotation);
                //Instantiate(obstacles, new Vector3(playerXpos, 0.5f, 0), obstacles.rotation);
                //Instantiate(obstacles, new Vector3(playerXpos, 1, 0), obstacles.rotation);
            }
        }
    }
}
