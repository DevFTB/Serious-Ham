using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreakUpdater : MonoBehaviour
{
    private StreakCalculator Calculator;
    void Start()
    {
        Calculator = GameObject.FindGameObjectWithTag("GameManager").GetComponent<StreakCalculator>();
    }

    public void IncrementStreak()
    {
        Calculator.IncrementStreak();
    }
}
