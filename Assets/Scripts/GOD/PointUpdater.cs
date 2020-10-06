using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointUpdater : MonoBehaviour
{
    public int PointValue;
    private PointCalculator Calculator;
    // Start is called before the first frame update
    void Start()
    {
        Calculator = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PointCalculator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementPoints()
    {
        Calculator.IncrementPoints(PointValue);
    }
}
