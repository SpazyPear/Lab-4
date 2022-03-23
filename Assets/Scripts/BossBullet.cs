using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;
    [SerializeField]
    public string test;

    public AudioClip EnemyShoot;
    public AudioClip Explode;

    public GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.rotation.z == -0.5f)
        {
            moveBull(1);
        }
        if (test == "midLeft")
        {
            moveBull(2);
        }
        if (test == "midRight")
        {
            moveBull(3);
        }
        if (transform.rotation.z == 0.5f)
        {
            moveBull(4);
        }
        if (transform.position.x > 10)
        {
            Destroy(gameObject);
        }
        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
        if (transform.position.y < -7)
        {
            Destroy(gameObject);
        }
    }
    private void moveBull(int dir)
    {
        switch (dir)
        {
            case 1:
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x-10, transform.position.y-5, 0), speed * Time.deltaTime);
                break;
            case 2:
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x-5, transform.position.y-10, 0), speed * Time.deltaTime);
                break;
            case 3:
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x+5, transform.position.y-10, 0), speed * Time.deltaTime);
                break;
            case 4:
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x+10, transform.position.y-5, 0), speed * Time.deltaTime);
                break;

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") //If bullet hits a player
        {
            AudioSource.PlayClipAtPoint(Explode, transform.position, 1f);
            manager.LoseLife();

        }
    }
}
