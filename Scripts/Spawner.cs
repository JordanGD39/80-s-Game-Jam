using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    float randY;
    Vector2 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;
    public float timer = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 3)
        {
            if (timer > nextSpawn)
            {
                nextSpawn = timer + spawnRate;
                randY = Random.Range(-5f, 5f);
                whereToSpawn = new Vector2(transform.position.x, randY);
                Instantiate(enemy, whereToSpawn, Quaternion.identity);

            }
        }
    }
}
