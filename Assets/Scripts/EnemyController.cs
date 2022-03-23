using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public GameManager manager;
    public int enemyPointsWorth;
    public int enemyType;

    public GameObject enemyBullet;
    private GameObject mostRecentlyFired;
    bool moveLeft;
    bool moveRight;
    float enemySpeed;

    float shootingInterval;

    // Start is called before the first frame update
    void Start()
    {
        shootingInterval = Random.Range(3.0f, 5.0f);
        Invoke("EnemyShoot", shootingInterval);
        enemySpeed = 0.005f;
        moveLeft = true;
        moveRight = false;

        switch (enemyType)
        {
            case 0:
                break;
            case 1:
                enemySpeed = 0.01f;
                break;
            case 2:
                shootingInterval = Random.Range(1.5f, 3.0f);
                break;
        }
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
            // Move enemy down
            transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
        }
        }
        if(moveRight && !moveLeft)
        {
        transform.Translate(new Vector3(-enemySpeed, 0, 0)); //move right
        if(transform.position.x<-8)
        {
            moveRight = false;
            moveLeft = true;
            // Move enemy down
            transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
            }
        }

        if (enemyType == 1)
        {
            transform.Translate(new Vector3(0, transform.position.x / 1200, 0));
        }
    }

    void EnemyShoot()
    {
        mostRecentlyFired = GameObject.Instantiate(enemyBullet, transform.localPosition, Quaternion.identity);
        mostRecentlyFired.GetComponent<EnemyBulletMovement>().manager = manager;
        Invoke("EnemyShoot", shootingInterval);
    }

 private void OnTriggerEnter2D(Collider2D other) 
    {  
        if(other.tag == "PlayerBullet") //If enemy shot by player
        {
            manager.EnemyDeath();
            manager.score += enemyPointsWorth; //Add to player score how many points this enemy is worth
            manager.UpdateScoreUI();

            other.gameObject.SetActive(false);
        }
    }
}
