using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMovement : MonoBehaviour
{
    float bulletSpeed;
    public GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        bulletSpeed = -0.3f;
        manager = GameObject.Find("GameManager").GetComponent<GameManager>(); //Replaced with passing manager between EnemyController and EnemyBulletMovement
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0,bulletSpeed,0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") //If bullet hits a player
        {
            manager.LoseLife();
        }
    }
}
