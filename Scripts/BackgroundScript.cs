using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    public float speed = 2;

    private float timer;
    private int counter;

    public GameObject BG;
    public Transform spawnPos;
    public bool spawner;

    // Start is called before the first frame update
    void Start()
    {
        spawnPos = GameObject.FindGameObjectWithTag("Spawn").transform;        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        transform.position += Vector3.down * speed * Time.deltaTime;

        if (timer > 6 && spawner)
        {
            GameObject bg = Instantiate(BG, spawnPos.transform.position, transform.rotation);
            bg.GetComponent<SpriteRenderer>().sortingOrder -= counter;
            timer = 0;
            counter++;
        }

        if (!spawner && transform.position.y < -19.8f)
        {
            Destroy(gameObject);
        }
        else if (spawner && transform.position.y < -19.8f)
        {
            speed = 0;
        }
    }

}
