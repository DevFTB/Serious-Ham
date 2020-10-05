using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCalculator : MonoBehaviour
{
    public int Points;
    StreakCalculator StreakCalculator;
    // Start is called before the first frame update
    void Start()
    {
        StreakCalculator = GetComponent<StreakCalculator>();
        Points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementPoints(int Value)
    {
        Points += Value * StreakCalculator.GetPointMultiplier();
    }
}
