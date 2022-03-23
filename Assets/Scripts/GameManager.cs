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

    //all enemies die let go boss
    public GameObject bossPref;
    private GameObject boss;
    public bool bossStage;
    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Enemy") == null & GameObject.FindGameObjectWithTag("Boss") == null & bossStage)
        {
            //bossStage = true;
            //Should use an INVOKE here, for the boss to come out
            //Invoke("letsgoboss",3);
            boss = GameObject.Instantiate(bossPref, new Vector3(0, 0, 0), Quaternion.identity);
        }
        else
        {
            //bossStage = false;
        }
        if (bossStage)
        {
            //boss = GameObject.Instantiate(bossPref, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
    private void letsgoboss()
    {
        //boss = GameObject.Instantiate(bossPref, new Vector3(0, 0, 0), Quaternion.identity);
    }

}
