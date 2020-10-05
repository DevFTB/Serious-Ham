using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float ExplosionShakeIntensity;
    public float ExplosionShakeDuration;
    public CameraShake CameraShake;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExplodeShake()
    {
        CameraShake.AddShake(ExplosionShakeDuration, ExplosionShakeIntensity);
    }

}
