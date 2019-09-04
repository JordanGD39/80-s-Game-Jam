using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointScript : MonoBehaviour
{
    public Text scoreTxt;

    public float points;
    // Start is called before the first frame update
    void Start()
    {
        points = GameManager.instance.score;
    }

    // Update is called once per frame
    void Update()
    {
        if (points < 0)
        {
            points = 0;
        }
        points += 5 * Time.fixedDeltaTime;
        GameManager.instance.score = points;
        scoreTxt.text = points.ToString("F0");
    }
}
