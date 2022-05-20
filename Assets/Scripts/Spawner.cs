using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;

    public float enemyInterval = 5f;
        
    private void Start()
    {
        InvokeRepeating("spawn", enemyInterval, enemyInterval);
    }

    void Update()
    {

    }

    void spawn()
    {
        Instantiate(enemy);
    }
}
