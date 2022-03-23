using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    public int lives;
    public Text livesText;
    public Text scoreText;

    public GameObject playerBullet;

    public void LoseLife()
    {
        lives--;
        livesText.text = lives.ToString();
        Debug.Log(lives);
        if (lives == 0)
        {
            //Save score to player preferences
            PlayerPrefs.SetInt("Score", score);

            SceneManager.LoadScene("EndScene");
        }
    }

    public void UpdateScoreUI()
    {
        scoreText.text = score.ToString(); //Update lives UI
    }

    public void EnemyDeath()
    {
        Destroy(playerBullet); //Destroy bullet
        Debug.Log("Shot");
    }
}
