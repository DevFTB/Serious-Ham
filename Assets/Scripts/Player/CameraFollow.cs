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

        Vector3 forward = Vector3.Cross(Vector3.up, Target.right);

        // Quaternion rotation = Quaternion.FromToRotation(transform.forward, Cross * -1);
        // Vector3 FallOverAmount = Vector3.Cross(Vector3.up, transform.right);
        //     if (FallOverAmount.magnitude < 0.40)
        //     {
        //         rb.AddForce(Vector3.up * CorrectionFactor, ForceMode.VelocityChange);
        //     }
        transform.position = Target.transform.position + (Vector3.Project(Offset,forward) + Vector3.Project(Offset, Vector3.up));

        var lookPos = Target.position - transform.position;

        transform.rotation = Quaternion.LookRotation(lookPos);
    }
}
