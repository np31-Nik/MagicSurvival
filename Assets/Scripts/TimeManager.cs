using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float scale = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = scale;
    }

    public void changeScale(float s)
    {
        scale = s;
    }
}
