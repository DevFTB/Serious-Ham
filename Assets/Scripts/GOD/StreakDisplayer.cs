using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StreakDisplayer : MonoBehaviour
{
    public StreakCalculator Calculator;

    public Text StreakNumberText;
    public Text StreakNameText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Calculator.HasStreak())
        {
            StreakNumberText.text = "x " + Calculator.Streak.ToString();
            StreakNameText.text = Calculator.CurrentStreakTier.Name;
        }
        else
        {
            StreakNumberText.text = "";
            StreakNameText.text = "";
        }

        
    }
}
