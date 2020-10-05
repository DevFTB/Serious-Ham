using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public List<ParticleSystem> Particles;
    public float Duration;
    private float Timer;
    private bool Exploded;
    // Start is called before the first frame update
    void Start()
    {
        Timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Exploded)
        {
            if (Timer < Duration)
            {
                Timer += Time.deltaTime;
            }
            else
            {
                StopExplode();
            }
        }
    }

    public void Explode()
    {
        foreach (ParticleSystem ps in Particles)
        {
            ps.Play();
            Exploded = true;
        }
    }

    void StopExplode()
    {
        foreach (ParticleSystem ps in Particles)
        {
            ps.Stop();
            Exploded = true;
        }
    }
}
