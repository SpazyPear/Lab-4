using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunkerSpawner : MonoBehaviour
{
    public int numBunkers;
    public GameObject bunker;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < numBunkers + 1; i++)
        {
            SpawnBunker((20 * i) / (numBunkers + 1) - 10, -3.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnBunker(float x, float y)
    {
        Instantiate(bunker, new Vector3(x - 0.5f, y, 0), Quaternion.identity).transform.parent = gameObject.transform;
        Instantiate(bunker, new Vector3(x - 0.25f, y, 0), Quaternion.identity).transform.parent = gameObject.transform;
        Instantiate(bunker, new Vector3(x + 0.25f, y, 0), Quaternion.identity).transform.parent = gameObject.transform;
        Instantiate(bunker, new Vector3(x + 0.5f, y, 0), Quaternion.identity).transform.parent = gameObject.transform;

        Instantiate(bunker, new Vector3(x - 0.5f, y + 0.25f, 0), Quaternion.identity).transform.parent = gameObject.transform;
        Instantiate(bunker, new Vector3(x - 0.25f, y + 0.25f, 0), Quaternion.identity).transform.parent = gameObject.transform;
        Instantiate(bunker, new Vector3(x, y + 0.25f, 0), Quaternion.identity).transform.parent = gameObject.transform;
        Instantiate(bunker, new Vector3(x + 0.25f, y + 0.25f, 0), Quaternion.identity).transform.parent = gameObject.transform;
        Instantiate(bunker, new Vector3(x + 0.5f, y + 0.25f, 0), Quaternion.identity).transform.parent = gameObject.transform;

        Instantiate(bunker, new Vector3(x - 0.5f, y + 0.5f, 0), Quaternion.identity).transform.parent = gameObject.transform;
        Instantiate(bunker, new Vector3(x - 0.25f, y + 0.5f, 0), Quaternion.identity).transform.parent = gameObject.transform;
        Instantiate(bunker, new Vector3(x, y + 0.5f, 0), Quaternion.identity).transform.parent = gameObject.transform;
        Instantiate(bunker, new Vector3(x + 0.25f, y + 0.5f, 0), Quaternion.identity).transform.parent = gameObject.transform;
        Instantiate(bunker, new Vector3(x + 0.5f, y + 0.5f, 0), Quaternion.identity).transform.parent = gameObject.transform;

        Instantiate(bunker, new Vector3(x - 0.25f, y + 0.75f, 0), Quaternion.identity).transform.parent = gameObject.transform;
        Instantiate(bunker, new Vector3(x, y + 0.75f, 0), Quaternion.identity).transform.parent = gameObject.transform;
        Instantiate(bunker, new Vector3(x + 0.25f, y + 0.75f, 0), Quaternion.identity).transform.parent = gameObject.transform;
    }
}
