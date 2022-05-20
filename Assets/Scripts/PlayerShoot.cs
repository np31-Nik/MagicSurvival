using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject target;
    private Rigidbody2D rb;

    public float fireDelay = 0.8f;
    float cooldownTimer = 0;

    private float pHeight;
    private float pWidth;

    void Start()
    {
        pWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        pHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer <= 0)
        {
            cooldownTimer = fireDelay;

            Vector3 offset = new Vector3(0, pHeight, 0);
            GameObject closest = findNearestEnemy();
            if (closest)
            {
                Quaternion q = aimNearest(closest.transform);
                Instantiate(bulletPrefab, transform.position, transform.rotation);
            }
        }
    }

    Quaternion aimNearest(Transform enemy)
    {
        Vector3 direction = enemy.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg -90f;
        //rb.rotation = angle;
        transform.rotation = Quaternion.Euler(Vector3.forward * angle) ;
        Quaternion q = Quaternion.Euler(0f, 0f, angle);

        //direction.Normalize();
        return q;
    }

    GameObject findNearestEnemy()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        GameObject closestEnemy = null;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach(GameObject currentEnemy in enemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
            }
        }
        if (closestEnemy)
        {
            Debug.DrawLine(transform.position, closestEnemy.transform.position);
            Instantiate(target, closestEnemy.transform);

        }
        return closestEnemy;












        //GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //GameObject closest;

        //if (enemies.Length == 0)
        //{
        //    return null;
        //}else if (enemies.Length == 1)
        //{
        //    closest = enemies[0];
        //    Instantiate(target, closest.transform);
        //}
        //else
        //{
        //    closest = enemies.OrderBy(go => (transform.position - go.transform.position)).First();
        //    Instantiate(target, closest.transform);

        //}

        //return closest;
    }
}
