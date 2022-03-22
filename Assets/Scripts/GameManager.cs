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

    public GameObject playerBullet;
   
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

    public void EnemyDeath()
    {
        Destroy(playerBullet); //Destroy bullet
        Debug.Log("Shot");
    }
    bool letsgoboss = false;
    public GameObject bossPref;
    private GameObject boss;
    float timer;
    private void Update()
    {
        
        //all enemies die let go boss
        if (GameObject.FindGameObjectWithTag("Enemy") == null & GameObject.FindGameObjectWithTag("Boss") == null)
        {
            boss = GameObject.Instantiate(bossPref, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }

}
