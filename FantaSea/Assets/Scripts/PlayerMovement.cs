using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : Teleporter
{

    public bool m_canMove = true;

    [SerializeField] private float speed; //player speed
    [SerializeField] private float gravity = -9.81f; //player gravity amount
    [SerializeField] private Transform origin;
    [SerializeField] private float jumpHeight = 3f;

    public Vector3 movement;
    private bool m_jumped;
    
    private Vector3 velocity;
    public CharacterController controller;
    private float groundDistance = 0.4f;
    [SerializeField] private bool isGrounded;
    public LayerMask groundMask;


    public List<Interactable> m_nearbyInteractables;

    private void Awake() {
        controller = GetComponent<CharacterController>();
        m_nearbyInteractables = new List<Interactable>();
    }
    private void Start() {
        
    }
    private void FixedUpdate() {
        isGrounded = controller.isGrounded;

        if(isGrounded && velocity.y < 0f) {
            velocity.y = 0;
        }

        Vector3 m = (transform.right * movement.x + transform.forward * movement.z) * speed;
        controller.Move(m * Time.deltaTime);

        if(m_jumped && isGrounded) {
            velocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }

    public void Move(InputAction.CallbackContext context) {
        movement = new Vector3(context.ReadValue<Vector2>().x, 0, context.ReadValue<Vector2>().y);
    }

    public void Jump(InputAction.CallbackContext context) {
        m_jumped = context.action.triggered;
    }

    public void InteractContext(InputAction.CallbackContext context) {
        if(context.performed) Interact();
    }

    private void Interact() {
        foreach(Interactable i in m_nearbyInteractables) {
            i.StartInteraction();
        }
    }

    private bool CheckInteractable(Interactable inter) {
        foreach(Interactable i in m_nearbyInteractables) {
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

    

    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.gameObject.CompareTag("NPC")) {
            //if you bumped into an NPC, interact
            collision.collider.gameObject.GetComponent<NPC>().StartInteraction();
        }
    }

    private void OnCollisionExit(Collision collision) {
        if (collision.collider.gameObject.CompareTag("NPC")) {
            //if you bumped into an NPC, interact
            collision.collider.gameObject.GetComponent<NPC>().StopInteraction();
        }
    }

    private void OnTriggerEnter(Collider other) {
        /*if (other.gameObject.CompareTag("NPC")) {
            Debug.Log("I hit an NPC");
            other.gameObject.GetComponent<NPC>().StartInteraction();
        } */
        if(other.gameObject.GetComponent<Interactable>() == true) {
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
