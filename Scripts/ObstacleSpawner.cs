using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    public float speed = 3;
    public float timer = 0;
    public int damage = 5;

    private Transform Player;
    private PointScript PointScript;
    private TimerScript TimerScript;

    public void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Player"))
        {
            hitInfo.GetComponent<PlayerMovement>().Damage();
            PointScript.points -= 30;
            TimerScript.time += 5;
            GetComponent<Animator>().Play("MeteorExplode");
            Destroy(gameObject, 0.5f);
        } 
    }

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        PointScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PointScript>();
        TimerScript = GameObject.FindGameObjectWithTag("Timer").GetComponent<TimerScript>();

        Destroy(gameObject, 7);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        transform.position += Vector3.left * speed * Time.deltaTime;

        transform.Rotate(0, 0, 4);
    }
}
