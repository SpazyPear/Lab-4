using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speed = 3f;

    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    BulletMovement bulletMovement;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position += Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * speed;

        if (Input.GetKeyDown(KeyCode.X))
        {
            bulletMovement.activeBullets.Add(Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), Quaternion.identity));

        }
        
    }
}
