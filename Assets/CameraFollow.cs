using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    private Vector3 Offset;
    private Vector3 OriginalRotation;

    public float Smoothing;

    void Start()
    {
        Offset = transform.position - Target.position;
        OriginalRotation = transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Position = Vector3.Lerp(Target.position + Offset, transform.position, Smoothing * Time.deltaTime);

        Vector3 lookPos = Target.position - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Smoothing);

        transform.position = Position;
    }
}
