using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour
{
    public float steeringAngle;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Euler(transform.localRotation.x, transform.localRotation.y + steeringAngle, transform.localRotation.z);
    }
}
