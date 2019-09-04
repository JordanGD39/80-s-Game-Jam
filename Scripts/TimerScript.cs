using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TimerScript : MonoBehaviour
{
	public float time = 30;
	public GameObject rb;
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		time -= Time.deltaTime;
		if (time <= 5)
		{
			rb.transform.position += Vector3.left * 2 * Time.deltaTime;
		}
    }
}
