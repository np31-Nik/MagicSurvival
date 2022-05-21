using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParryDetect : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
        player = transform.parent.gameObject;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
        {
            Debug.Log("PARRY!");

            player.GetComponent<Parry>().detectedParry();
            
        }

    }
}
