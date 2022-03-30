using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool GameStarted;
    public int score = 0;
    public static int HS;
    public Text scoreText;
    public Text highScore;

    // Start is called before the first frame update
    public void Awake()
    {
        highScore.text = "Highscore: " + HS.ToString();
    }
    public void StartGame()
    {
        GameStarted = true;
        FindObjectOfType<RoadCreation>().StartBuilding();
    }
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
        if (score > HS)
        {
            HS = score;
            highScore.text = "Highscore: " + HS.ToString();
                }
    }
    public void EndGame()
    {
        SceneManager.LoadScene(0);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            StartGame();
    }
}
