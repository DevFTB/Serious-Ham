using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    public float OffsetMagnitude;
    public float OffsetAngle;
    private Vector3 OriginalRotation;

    public float Smoothing;
    public float FallOverMargin;

    void Start()
    {
        OriginalRotation = transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 forward = Vector3.Cross(Vector3.up, Target.right);

        Vector3 FallOverAmount = forward;
        if(forward.magnitude > FallOverMargin)
        {
            float OffsetRad = Mathf.Deg2Rad * OffsetAngle;
            Vector3 Pos = Target.transform.position + (forward * OffsetMagnitude * Mathf.Cos(OffsetRad)) + (OffsetAngle * Vector3.up * Mathf.Sin(OffsetRad));
            transform.position = Vector3.Lerp(transform.position, Pos, Smoothing);
        }


        var lookPos = Target.position - transform.position;

        transform.rotation = Quaternion.LookRotation(lookPos);
    }
}
