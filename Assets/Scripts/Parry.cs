using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parry : MonoBehaviour
{
    public GameObject parryIndicator;
    public GameObject counterAttack;

    private bool parried;

    float parryWindow = 0.3f;
    float parryCooldown = 1f;
    float invulnDuration = 0.2f;

    float timerCooldown;
    float timerWindow;
    float timerInvuln;
    GameObject parry;
    CircleCollider2D hitbox;
    GameObject counter;

    private void Start()
    {
        timerCooldown = Time.time - 1f;
        timerWindow = Time.time - 1f;
        timerInvuln = Time.time - 1f;
        parried = false;
        hitbox = gameObject.GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        if (!parried)
        {
            if (Input.GetButtonDown("Fire3") && timerCooldown < Time.time)
            {
                timerCooldown = Time.time + parryCooldown;
                timerWindow = Time.time + parryWindow;
                parry = Instantiate(parryIndicator, transform);
                hitbox.enabled = false;
            }

            if (timerWindow < Time.time)
            {
                if (parry)
                {
                    Destroy(parry);
                    hitbox.enabled = true;

                }
            }
        }
        else
        {
            if (parry)
            {
                Destroy(parry);
                counter = Instantiate(counterAttack, transform);
                hitbox.enabled = false;
            }

            if (timerInvuln < Time.time)
            {
                if (counter)
                    Destroy(counter);
                hitbox.enabled = true;
                parried = false;
            }
        }
    }

    public void detectedParry()
    {
        parried = true;
        timerInvuln = Time.time + invulnDuration;
    }
}
