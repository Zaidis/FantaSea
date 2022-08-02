using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Boat_Base : MonoBehaviour
{
    public Buoy[] Buoys;
    public Engine engine;
    public Rigidbody rb;
    public float throttleInput, steeringInput, speed, maxSteerAngle;
    public SeaManager sm;

    [Header("General Specs")]
    public string boatName;
    public List<Interactable> m_nearbyInteractables;

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

    public void Move(InputAction.CallbackContext context) {

        throttleInput = context.ReadValue<Vector2>().y;
        steeringInput = context.ReadValue<Vector2>().x;

    }

 
    // Update is called once per frame
    void Update()
    {
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

    public void InteractContext(InputAction.CallbackContext context) {
        if (context.performed) Interact();
    }

    private void Interact() {
        foreach (Interactable i in m_nearbyInteractables) {
            i.StartInteraction();
        }
    }

    private bool CheckInteractable(Interactable inter) {
        foreach (Interactable i in m_nearbyInteractables) {
            if (i == inter) return true;
        }
        return false;
    }
    private void AddInteractable(Interactable inter) {
        m_nearbyInteractables.Add(inter);
    }
    private void RemoveInteractable(Interactable inter) {
        m_nearbyInteractables.Remove(inter);
    }

    private void OnTriggerEnter(Collider other) {
        /*if (other.gameObject.CompareTag("NPC")) {
            Debug.Log("I hit an NPC");
            other.gameObject.GetComponent<NPC>().StartInteraction();
        } */
        if (other.gameObject.GetComponent<Interactable>() == true) {
            //if this is an interactable
            Interactable i = other.gameObject.gameObject.GetComponent<Interactable>();
            if (!CheckInteractable(i)) AddInteractable(i);
        }

    }
    private void OnTriggerExit(Collider other) {
        /*if (other.gameObject.CompareTag("NPC")) {
            other.gameObject.GetComponent<NPC>().StopInteraction();
        } */

        if (other.gameObject.GetComponent<Interactable>() == true) {
            //if this is an interactable
            RemoveInteractable(other.gameObject.GetComponent<Interactable>());
        }
    }
}
