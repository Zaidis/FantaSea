using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : Teleporter
{
    public override void Teleport(Transform oldPortal, Transform newPortal, Vector3 pos, Quaternion rot) {

        transform.position = pos;
        transform.rotation = rot;
        Vector3 newRotation = rot.eulerAngles;


        //velocity = newPortal.TransformVector(oldPortal.InverseTransformVector(velocity));
        Physics.SyncTransforms();

    }
}
