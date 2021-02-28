using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatinBall : MonoBehaviour
{
    public PublicParams Params;

    void FixedUpdate()
    {
        Quaternion rotationX = Quaternion.AngleAxis(Params.ballRotationSpeed, Vector3.right);
        transform.rotation *= rotationX;
    }
}
