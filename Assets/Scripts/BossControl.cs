using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControl : MonoBehaviour
{
    //Define Boss combat Stats
    [SerializeField]
    float speed;
    [SerializeField]
    public float health;
    [SerializeField]
    int currentstage;
    [SerializeField]
    float shootinginterval;

    //shooting system
    public GameObject bossBullet;
    private GameObject shoot1;
    private GameObject shoot2;
    private GameObject shoot3;
    private GameObject shoot4;
    public Vector3 bulletPos1;
    public Vector3 bulletPos2;
    public Vector3 bulletPos3;
    public Vector3 bulletPos4;

    //boss movement
    private float nextX;
    private float nextY;
    [SerializeField]
    Vector3 nextPos;

    // Start is called before the first frame update
    void Start()
    {
        currentstage = 1;
        speed = 2;
        health = 50;
        nextPos = getRamPos();
        shootinginterval = 1f;
        InvokeRepeating("BossShoot", 0.5f, shootinginterval);
    }
    void BossShoot()
    {
        shoot3 = GameObject.Instantiate(bossBullet, bulletPos3, transform.rotation * Quaternion.Euler(0, 0, 35));
        shoot4 = GameObject.Instantiate(bossBullet, bulletPos4, transform.rotation * Quaternion.Euler(0, 0, 60));
        shoot2 = GameObject.Instantiate(bossBullet, bulletPos2, transform.rotation * Quaternion.Euler(0, 0, -30));
        shoot1 = GameObject.Instantiate(bossBullet, bulletPos1, transform.rotation * Quaternion.Euler(0, 0, -60));
        shoot2.GetComponent<BossBullet>().test = "midLeft";
        shoot3.GetComponent<BossBullet>().test = "midRight";
        //Debug.Log("shoot");
    }
    // Update is called once per frame
    void Update()
    {
        bulletPos1 = new Vector3(transform.position.x - 1.5f, transform.position.y, 0);
        bulletPos2 = new Vector3(transform.position.x - 0.5f, transform.position.y, 0);
        bulletPos3 = new Vector3(transform.position.x + 0.5f, transform.position.y, 0);
        bulletPos4 = new Vector3(transform.position.x + 1.5f, transform.position.y, 0);
        // entry of angry stage
        if (health <= 20)
        {
            currentstage = 2;
        }
        if (currentstage == 2)
        {
            speed = 4;
            transform.localScale = new Vector3(2f, 2f, transform.localScale.z);
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,255);
        }
        // move Boss
        if(transform.position != nextPos)
        {
            MoveBoss();
        }
        else
        {
            nextPos = getRamPos();
        }
        if(health == 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "PlayerBullet")
        {
            health--;
        }
    }



    //boss are able to move randomly
    private Vector3 getRamPos()
    {
        nextX = Random.Range(-8,8);
        nextY = Random.Range(-2.5f, 4.5f);
        return new Vector3(nextX,nextY,0);
    }
    private void MoveBoss()
    {
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }
}
