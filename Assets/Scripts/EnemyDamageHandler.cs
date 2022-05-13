using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageHandler : MonoBehaviour
{

    public int maxHealth = 1;
    int health;


    public GameObject explosion;
    //public HealthBar ;

    void Start()
    {
        health = maxHealth;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            health--;
            //healthBar.damage(1);
            if (health <= 0)
            {
                //Instantiate(explosion, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }

    void Update()
    {
    }

    public void repair(int hp)
    {
        if (health + hp > maxHealth)
        {
            health = maxHealth;
        }
        else
        {
            health += hp;
        }
    }
}
