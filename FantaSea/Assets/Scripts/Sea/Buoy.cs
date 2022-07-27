using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buoy : MonoBehaviour
{
    public Rigidbody rb;
    public float floatHeight = 1f;
    public float displacement = 3f;
    //use engine location to check what body of water player is in and get height of water
    public float steeringAngle;
    public float force;
    public float drag, angularDrag, underwaterDrag, underwaterAngularDrag;
    public float waveHeight;
    



    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Euler(transform.localRotation.x, transform.localRotation.y + steeringAngle, transform.localRotation.z);
    }

    private void FixedUpdate()
    {
        waveHeight = SeaManager.instance.getWaveHeight(transform.position);
        //transform.SetPositionAndRotation(new Vector3(this.transform.position.x, waveHeight, this.transform.position.z), this.transform.rotation);
        //if (transform.position.y < waveHeight)
        //{
            
            //rb.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * buoyancyForce, 0f), this.transform.position , ForceMode.Acceleration);
        //}

        float diff = transform.position.y - waveHeight;
        //float buoyancyForce = Mathf.Clamp01((waveHeight - transform.position.y) / floatHeight) * displacement;
        float buoyancyForce = Mathf.Abs(diff);
        if (diff < 0)
        {
            rb.AddForceAtPosition(Vector3.up * buoyancyForce * force, this.transform.position, ForceMode.Acceleration);
        }

    }
}
