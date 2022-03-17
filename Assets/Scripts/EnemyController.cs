using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject bullet;
    bool moveLeft;
    bool moveRight;
    float enemySpeed;

    float shootingInterval;
    // Start is called before the first frame update
    void Start()
    {
        shootingInterval = 1.5f;
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
        GameObject.Instantiate(bullet, transform.localPosition, Quaternion.identity);
        Invoke("EnemyShoot", shootingInterval);
    }
}
