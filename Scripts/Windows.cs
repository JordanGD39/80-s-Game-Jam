using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windows : MonoBehaviour
{
    public Sprite darkWindow;
    public Sprite lightWindow;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            int rand = Random.Range(0, 2);
            Debug.Log(rand);
            if (rand == 0)
            {
                transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = darkWindow;
            }
            else if (rand == 1)
            {
                transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = lightWindow;
            }            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
