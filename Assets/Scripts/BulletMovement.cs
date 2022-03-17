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
        for (int x = activeBullets.Count; x > 0; x--)
        {
            activeBullets[x - 1].transform.position += Vector3.up * Time.deltaTime * bulletSpeed;
            if (camera.WorldToViewportPoint(activeBullets[x - 1].transform.position).y > 1.5 || camera.WorldToViewportPoint(activeBullets[x - 1].transform.position).y < -0.5)
            {
                Destroy(activeBullets[x - 1], 1f);
                activeBullets.RemoveAt(x - 1);
            } 
        }
    }
}
