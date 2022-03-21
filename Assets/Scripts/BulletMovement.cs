using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public List<GameObject> activeBullets = new List<GameObject>();

    [SerializeField]
    float bulletSpeed = 6f;

    [SerializeField]
    Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int x = activeBullets.Count - 1; x >= 0; x--)
        {
            try
            {
                activeBullets[x].transform.position += Vector3.up * Time.deltaTime * bulletSpeed;
                if (camera.WorldToViewportPoint(activeBullets[x].transform.position).y > 1.3f || camera.WorldToViewportPoint(activeBullets[x].transform.position).y < -0.5)
                {
                    Destroy(activeBullets[x], 1f);
                    activeBullets.RemoveAt(x);
                }
            }
            catch (MissingReferenceException e)
            {
                activeBullets.RemoveAt(x);
            }
        }
    }

     private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Enemy") //If bullet hits an enemy
        {
           Destroy(other.gameObject); //Destroy the enemy
           Debug.Log("Detected");
        }
    }
}
