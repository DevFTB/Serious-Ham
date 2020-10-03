using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    private Vector3 Offset;
    private float OffSetMagnitude;
    private Vector3 OriginalRotation;

    public float Smoothing;
    public float FallOverMargin;

    void Start()
    {
        Offset = transform.position - Target.position;
        OffSetMagnitude = Offset.magnitude;
        OriginalRotation = transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 forward = Vector3.Cross(Vector3.up, Target.right);

        Vector3 FallOverAmount = forward;
        if(forward.magnitude > FallOverMargin)
        {
            Vector3 Pos = Target.transform.position + (Vector3.Project(Offset,forward) + Vector3.Project(Offset, Vector3.up)).normalized * OffSetMagnitude;
            transform.position = Vector3.Lerp(transform.position, Pos, Smoothing);
        }


        var lookPos = Target.position - transform.position;

        transform.rotation = Quaternion.LookRotation(lookPos);
    }
}
