using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer 
{
    public float Duration;

    public bool IsPaused { get; private set; }
    public bool IsComplete { get => TimeElapsed > Duration; }
    public bool IsActive { get => !IsPaused && !IsComplete; }

    private float TimeElapsed;

    public Timer(float duration)
    {
        IsPaused = true;
        Duration = duration;
    }

    public void Start()
    {
        IsPaused = false;
    }

    public void Update()
    {
        if(!IsPaused) TimeElapsed += Time.deltaTime;
    }

    public void Reset()
    {
        TimeElapsed = 0;
        IsPaused = true;
    }

    public float GetPercentageCompletion()
    {
        return TimeElapsed / Duration;
    }
}
