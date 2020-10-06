using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StreakDisplayer : MonoBehaviour
{
    public StreakCalculator Calculator;

    public Text StreakNumberText;
    public Image StreakNameImage;

    public Slider Slider;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Calculator.HasStreak())
        {
            GetComponent<CanvasGroup>().alpha = 1.0f;
            StreakNumberText.text = "x " + Calculator.Streak.ToString();
            StreakNameImage.sprite = Calculator.CurrentStreakTier.Image;
            Slider.value = Calculator.GetLossPercentage();
        }
        else
        {
            GetComponent<CanvasGroup>().alpha = 0.0f;
        }


    }
}
