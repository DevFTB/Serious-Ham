using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    private Vector3 Offset;

    public float Smoothing;

    void Start()
    {
        Offset = transform.position - Target.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Target.position + Offset;

        //Vector3 Cross = Vector3.Cross(Vector3.up, Target.right);

        //Quaternion rotation = Quaternion.FromToRotation(transform.forward, Cross * -1);

        //transform.position = Target.transform.position + Offset;

        //transform.rotation = rotation;
    }



}
