using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 10);
    }
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
            if (GameManager.instance.form == 0)
            {
                SceneManager.LoadScene("DK");
            }

            if (GameManager.instance.form == 1)
            {
                SceneManager.LoadScene("Sacrifice");
            }			
		}
	}
}
