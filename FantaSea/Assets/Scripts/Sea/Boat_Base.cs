using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat_Base : MonoBehaviour
{
    public Buoy[] Buoys;
    public Engine engine;
    public Rigidbody rb;
    public float throttleInput, steeringInput, speed, maxSteerAngle;
    public SeaManager sm;

    [Header("General Specs")]
    public string boatName;

    // Start is called before the first frame update
    private void Awake()
    {
        foreach (Buoy b in Buoys)
        {
            rb = gameObject.GetComponent<Rigidbody>();
            b.rb = rb;
        }
    }

    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        throttleInput = Input.GetAxis("Vertical");
        steeringInput = Input.GetAxis("Horizontal");

        if (steeringInput != 0)
        {
            //engine.steeringAngle = -steeringInput * 45;
            Buoys[0].steeringAngle = steeringInput * maxSteerAngle;
            Buoys[1].steeringAngle = steeringInput * maxSteerAngle;
        }

    }

    private void FixedUpdate()
    {
        //rb.AddForceAtPosition(engine.transform.forward * throttleInput * speed, engine.transform.position ,ForceMode.Acceleration);
        rb.AddForce(transform.forward * throttleInput * speed, ForceMode.Acceleration);
        if (steeringInput < 0)
        {
            rb.AddForceAtPosition(Buoys[1].transform.forward * (throttleInput * speed)/2, Buoys[1].transform.position, ForceMode.Acceleration);

        }
        else if (steeringInput > 0)
        {
            rb.AddForceAtPosition(Buoys[0].transform.forward * (throttleInput * speed) / 2, Buoys[0].transform.position, ForceMode.Acceleration);
        }

    }
}
