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

    bool isRolling = false;
    float rollTimerDuration = 3f;
    float rollTimer;
    bool canRoll = true;

    public float bulletTimerDuration = 0.5f;
    bool canShoot = true;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isRolling)
            transform.position += Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * speed;

        if (Input.GetKeyDown(KeyCode.X) && canShoot)
        {
            if (bulletMovement.activeBullets.Count > 1)
                return;
            bulletMovement.activeBullets.Add(Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), Quaternion.identity));
            //canShoot = false;
            // StartCoroutine(bulletTimer());

        }
        if (Input.GetKeyDown(KeyCode.Space) && !isRolling && canRoll)
            StartCoroutine(barrellRoll());
        
    }

    IEnumerator barrellRoll()
    {
        canRoll = false;
        const float duration = 0.2f;
        float timer = 0;
        isRolling = true;
        Vector3 startPos = transform.position;
        const float radius = 1f;
        float direction = Input.GetAxis("Horizontal") > 0 ? 1 : -1;
        float angleDirection = direction == -1 ? 0 : duration;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            Vector3 pos = new Vector3(radius * Mathf.Cos(((timer - angleDirection) / duration) * Mathf.PI), radius * Mathf.Sin((timer/duration) * Mathf.PI) * 0.5f);
            transform.position = startPos + (pos) + (new Vector3(radius, 0) * direction);
            yield return null;
        }
        isRolling = false;
        StartCoroutine(rollIntervalTimer());
    }

    IEnumerator rollIntervalTimer()
    {
        rollTimer = 0;
        while (rollTimer < rollTimerDuration)
        {
            rollTimer += Time.deltaTime;
            yield return null;
        }
        canRoll = true;
    }

    IEnumerator bulletTimer()
    {
        float bulletTimer = 0;
        while (bulletTimer < bulletTimerDuration)
        {
            bulletTimer += Time.deltaTime;
            yield return null;
        }
        canShoot = true;
    }
}
