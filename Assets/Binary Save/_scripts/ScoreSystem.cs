using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public bool isRolling;

    public int score = 0;
    public int highScore = 0;

    public Text scoreText;
    public Text highScoreText;

    void Update()
    {
        int randomNumber = Random.Range(0, 500);
        if(isRolling)
        {
            score = randomNumber;
            scoreText.text = randomNumber.ToString();
        }
        else
        {
            scoreText.text = score.ToString();
            if (score > highScore) highScore = score;
        }
        highScoreText.text = "High Score: " + highScore.ToString();

        if (score >= highScore) scoreText.color = Color.green;
        else                   scoreText.color = Color.red;
    }

    public void RollNumber()
    {
        if (!isRolling) isRolling = true;
        else            isRolling = false;
    }

    public void SaveScore()
    {
        SaveSystem.SaveGame(this);
    }
    public void LoadScore()
    {
        highScore = SaveSystem.LoadGame().HighScore;
    }
}
