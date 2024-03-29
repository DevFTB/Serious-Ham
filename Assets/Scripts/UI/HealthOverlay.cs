﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthOverlay : MonoBehaviour
{
    private float Health = 1f;
    private CanvasGroup Canvas;
    private bool Healing = false;
    private float Offset;
    public float OffsetMultiplier;
    public float PulsePeriod;
    private float HealingTimer;
    // Start is called before the first frame update
    void Start()
    {
        HealingTimer = 0.0f;
        Offset = 0;
        Canvas = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Healing)
        {
            HealingTimer += Time.deltaTime;
            Offset = Mathf.Sin(2 * Mathf.PI * HealingTimer/ (PulsePeriod))/100;
            Canvas.alpha = 1 - (Health + Offset * OffsetMultiplier);
        }
        
    }

    public void UpdateHealth(float HealthPercentage, bool IsHealing)
    {
        Health = HealthPercentage;
        Canvas.alpha = 1 - Health;
        Healing = IsHealing;
    }
}
