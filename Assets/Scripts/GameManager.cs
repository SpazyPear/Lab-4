using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    public int lives;
    public Text livesText;
    public Text scoreText;

    public void LoseLife()
    {
        lives--;
        livesText.text = lives.ToString();
        Debug.Log(lives);
        if (lives == 0)
        {
            //Game over logic
        }
    }

    public void UpdateScoreUI()
    {
        scoreText.text = score.ToString(); //Update lives UI
    }
}
