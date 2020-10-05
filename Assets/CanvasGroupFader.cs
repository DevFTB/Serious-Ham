using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class CanvasGroupFader : MonoBehaviour
{
    public float FadeDuration;

    private CanvasGroup CG;
    private Timer FadeTimer;
    // Start is called before the first frame update
    void Start()
    {
        CG = GetComponent<CanvasGroup>();
        FadeTimer = new Timer(FadeDuration);

        FadeTimer.Start();
    }

    // Update is called once per frame
    void Update()
    {
        FadeTimer.Update();

        CG.alpha = FadeTimer.GetPercentageCompletion();
    }
}
