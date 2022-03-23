using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public GameManager manager;
    public int enemyPointsWorth;

    public GameObject enemyBullet;
    private GameObject mostRecentlyFired;
    bool moveLeft;
    bool moveRight;
    float enemySpeed;

    float shootingInterval;

    // Start is called before the first frame update
    void Start()
    {
        shootingInterval = Random.Range(0.0f, 5.0f);
        Invoke("EnemyShoot", shootingInterval);
        enemySpeed = 0.07f;
        moveLeft = true;
        moveRight = false;
    }

    // Update is called once per frame
    void Update()
    {
         if(moveLeft && !moveRight)
        {
           transform.Translate(new Vector3(enemySpeed, 0, 0)); //move left
        if(transform.position.x>8)
        {
            moveLeft = false;
            moveRight = true;
        }
        }
        if(moveRight && !moveLeft)
        {
        transform.Translate(new Vector3(-enemySpeed, 0, 0)); //move right
        if(transform.position.x<-8)
        {
            moveRight = false;
            moveLeft = true;
        }
        }
    }

    void EnemyShoot()
    {
        mostRecentlyFired = GameObject.Instantiate(enemyBullet, transform.localPosition, Quaternion.identity);
        mostRecentlyFired.GetComponent<EnemyBulletMovement>().manager = manager;
        Invoke("EnemyShoot", shootingInterval);
    }

    private int Special;
 private void OnTriggerEnter2D(Collider2D other) 
    {  
        if(other.tag == "PlayerBullet") //If enemy shot by player
        {
           manager.EnemyDeath();
           manager.score += enemyPointsWorth; //Add to player score how many points this enemy is worth
           manager.UpdateScoreUI();
            if (gameObject.tag == "SpecialEnemy")
            {
                manager.EnemyDeath();
                manager.score += Special;//special point value
                manager.UpdateScoreUI();
            }
        }
    }
}
