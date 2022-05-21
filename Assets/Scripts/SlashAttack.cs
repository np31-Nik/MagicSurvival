using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashAttack : MonoBehaviour
{
    public GameObject slashAttack;

    bool slashing = false;
    float slashDuration = 0.2f;
    float slashCooldown = 0.8f;

    float durationTimer;
    float cooldownTimer;

    private void Start()
    {
        durationTimer = Time.time;
        cooldownTimer = Time.time;
    }

    void Update()
    {

        if (Input.GetButtonDown("Fire2") && cooldownTimer <= Time.time)
        {
            Debug.Log("SLASH");
            slashAttack.SetActive(true);
            durationTimer = Time.time + slashDuration;
            cooldownTimer = Time.time + + slashDuration + slashCooldown;
        }

        if(durationTimer <= Time.time)
        {
            slashAttack.SetActive(false);
        }
    }
}
