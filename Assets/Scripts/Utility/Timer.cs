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
    public void Update()
    {
        if (!IsPaused && !IsComplete) TimeElapsed += Time.deltaTime;
    }

    // Starts the Timer from whatever time elapsed it was at
    public void Start()
    {
        IsPaused = false;
    }

    // Pauses the timer ( doesn't increment)
    public void Pause()
    {
        IsPaused = true;
    }

    // Resets the time elapsed 
    public void Reset()
    {
        TimeElapsed = 0;
    }

    // Resets and sets paused
    public void Stop()
    {
        Reset();
        Pause();
    }

    public float GetPercentageCompletion()
    {
        return TimeElapsed / Duration;
    }
}
