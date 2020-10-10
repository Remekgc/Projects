using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private bool trakTime = false;
    [SerializeField] private float time;
    public float Time => time;

    public void StartTimer()
    {
        trakTime = true;
    }

    public void StopTimer()
    {
        trakTime = false;
    }

    public void ResetTime()
    {
        time = 0;
    }

    private void Update()
    {
        if (trakTime)
        {
            time += UnityEngine.Time.deltaTime;
        }
    }
}
