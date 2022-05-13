using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;

    public float fireDelay = 0.8f;
    float cooldownTimer = 0;

    private float pHeight;
    private float pWidth;

    void Start()
    {
        pWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        pHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer <= 0)
        {
            cooldownTimer = fireDelay;

            Vector3 offset = new Vector3(0, pHeight, 0);
            Instantiate(bulletPrefab, transform.position - offset, transform.rotation * Quaternion.Euler(0f, 180f, 0f));
        }
    }
}
