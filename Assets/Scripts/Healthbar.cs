using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    int health;
    int maxHealth;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public PlayerDamageHandler player;

    void Update()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < maxHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void repair(int hp)
    {
        health += hp;
        player.repair(hp);
    }

    public void add(int hp)
    {
        maxHealth += hp;
        health += hp;
    }

    public void set(int hp, int maxhp)
    {
        health = hp;
        maxHealth = maxhp;
    }

    public void damage(int dmg)
    {
        health -= dmg;
    }

    public void ChangeDmgHandler(PlayerDamageHandler handler)
    {
        player = handler;
    }
}
