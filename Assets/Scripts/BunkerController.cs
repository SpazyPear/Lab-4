using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunkerController : MonoBehaviour
{
    private int health;
    SpriteRenderer m_SpriteRenderer;

    public AudioClip Explode;
    public AudioClip Hit;

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
            health--;
            AudioSource.PlayClipAtPoint(Hit, transform.position, 1f);
            // Change state for now using transparency instead of new sprite
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0.0f, 1.0f, 0.0f, health / 3.0f);
            if (health == 0)
            {
                gameObject.SetActive(false);
                AudioSource.PlayClipAtPoint(Explode, transform.position, 1f);
            }
            collision.gameObject.SetActive(false);
        }
    }
}