using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMovement : MonoBehaviour
{
    float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        bulletSpeed = -0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0,bulletSpeed,0);
    }
}
