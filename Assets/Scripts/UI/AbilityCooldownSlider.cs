using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class AbilityCooldownSlider : MonoBehaviour
{
    public Ability Ability;

    private Slider Slider;

    void Start()
    {
        Slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Ability.IsCooledDown) 
        {
            Slider.value = 1; 
        }
        else
        {
            Slider.value = Ability.GetCooldown();

        }
    }
}
