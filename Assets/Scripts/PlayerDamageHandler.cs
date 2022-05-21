using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageHandler : MonoBehaviour
{

    public int maxHealth = 3;
    int health;


    public GameObject explosion;
    //public HealthBar healthBar;

    float invulnPeriod = 1.2f;
    float blinkPeriod = 0.2f;
    float invulnTimer = 0;
    float blinkTimer = 0;
    Color normalColor = new Color(1f, 1f, 1f, 1f);
    Color blinkColor = new Color(1f, 1f, 1f, .5f);
    CircleCollider2D hitbox;
    SpriteRenderer sprite;
    public GameObject gameover;
    Healthbar healthbar;

    void Awake()
    {
        healthbar = GameObject.Find("Healthbar").GetComponent<Healthbar>();
        healthbar.ChangeDmgHandler(this);
        healthbar.set(maxHealth, maxHealth);
        sprite = GetComponent<SpriteRenderer>();
        hitbox = GetComponent<CircleCollider2D>();
        health = maxHealth;
        //GameObject Salud = GameObject.Find("Salud");
        //HealthBar SaludScript = Salud.GetComponent<HealthBar>();
        //SaludScript.ChangeDmgHandler(this);
    }

    public void setGameOver(GameObject g)
    {
        gameover = g;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            health--;
            healthbar.damage(1);
            if (health <= 0)
            {
                //Instantiate(explosion, transform.position, transform.rotation);
                gameover.SetActive(true);
                GameObject.Find("TimeManager").GetComponent<TimeManager>().changeScale(0f);
                GameObject.Find("Spawner").GetComponent<Spawner>().stopSpawn();
                Destroy(gameObject);
            }
            invulnTimer = invulnPeriod;
            blinkTimer = blinkPeriod;
        }
    }

    void Update()
    {
        if (invulnTimer > 0)
        {
            hitbox.enabled = false;
            invulnTimer -= Time.deltaTime;
            blinkTimer -= Time.deltaTime;

            if (blinkTimer <= 0)
            {
                if (sprite.color == normalColor)
                {
                    sprite.color = blinkColor;
                }
                else if (sprite.color == blinkColor)
                {
                    sprite.color = normalColor;
                }
                blinkTimer = blinkPeriod;
            }
            if (invulnTimer <= 0)
            {
                sprite.color = normalColor;
                hitbox.enabled = true;
            }
        }
    }

    public void repair(int hp)
    {
        if (health+hp > maxHealth)
        {
            health = maxHealth;
        }
        else
        {
            health += hp;
        }
    }
}
