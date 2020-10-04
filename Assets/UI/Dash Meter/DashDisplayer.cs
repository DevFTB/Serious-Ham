using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class DashDisplayer : MonoBehaviour
{
    public Dash Dash;
    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Dash.IsCooledDown) { slider.value = 1; }
        else
        {
            slider.value = Dash.GetCooldown();
        }
    }
}
