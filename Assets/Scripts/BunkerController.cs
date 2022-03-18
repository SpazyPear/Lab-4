using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunkerController : MonoBehaviour
{
    private int health;
    // Start is called before the first frame update
    void Start()
    {
        health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet" || collision.tag == "PlayerBullet")
        {
            Debug.Log("A");
            health--;
            // Change state
            if (health == 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}