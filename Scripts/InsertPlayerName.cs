using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InsertPlayerName : MonoBehaviour
{
    public InputField playerName;
    public Text score;
    public Text gameOver;
    public Text score2;
    public Text highScore;
    public Text highScoreName;
    public Text scoreName;

    public GameObject namePanel;
    public GameObject HGPanel;

    private float timer;
    private bool waitNow = false;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.instance.gameOver)
        {
            gameOver.text = "GAME OVER";
        }
        else
        {
            gameOver.text = "YOU WIN";
        }

        score.text = "Score:" + GameManager.instance.score.ToString("F0");        
        score2.text = "Score:" + GameManager.instance.score.ToString("F0");        
    }

    // Update is called once per frame
    void Update()
    {
        if (waitNow)
        {
            timer += Time.deltaTime;
        }        
        if (Input.GetButtonDown("Submit"))
        {
            waitNow = true;
            scoreName.text = playerName.text;
            namePanel.SetActive(false);
            HGPanel.SetActive(true);

            if (GameManager.instance.score >= PlayerPrefs.GetFloat("Highscore", 0))
            {
                PlayerPrefs.SetFloat("Highscore", GameManager.instance.score);
                PlayerPrefs.SetString("HighscoreName", playerName.text);
                highScore.text = "Highscore:" + GameManager.instance.score.ToString("F0");
                highScoreName.text = playerName.text;
            }
            else if (GameManager.instance.score < PlayerPrefs.GetFloat("Highscore", 0))
            {
                highScore.text = "Highscore:" + PlayerPrefs.GetFloat("Highscore", 0);
                highScoreName.text = PlayerPrefs.GetString("HighscoreName", "Empty");
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            PlayerPrefs.DeleteAll();
        }

        if (timer > 10)
        {
            GameManager.instance.form = 0;
            SceneManager.LoadScene("Credits");            
        }
    }
}
