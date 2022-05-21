using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;

    public float enemyInterval = 2f;
        
    private void Start()
    {
        InvokeRepeating("spawn", enemyInterval, enemyInterval);
    }

    void spawn()
    {
        if(Time.timeScale!=0.0)
        Instantiate(enemy);
    }

    public void stopSpawn()
    {
        CancelInvoke();
    }
}
