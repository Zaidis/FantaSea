using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed; //player speed
    [SerializeField] private float gravity = -9.81f; //player gravity amount
    [SerializeField] private Transform origin;
    [SerializeField] private float jumpHeight = 3f;
    public bool canMove = true;
    Vector3 velocity;
    public CharacterController controller;
    private float groundDistance = 0.4f;
    [SerializeField]bool isGrounded;
    public LayerMask groundMask;
    private void Awake() {
        controller = GetComponent<CharacterController>();
    }

    private void Update() {
        if (canMove) {
            isGrounded = Physics.CheckSphere(origin.position, groundDistance, groundMask);

            if (isGrounded && velocity.y <= 0) {
                velocity.y = -2f;
            }
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            Vector3 move = transform.right * x + transform.forward * z;
            controller.Move(move * Time.deltaTime * speed);

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
                //jump
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
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
        if (other.gameObject.CompareTag("NPC")) {
            Debug.Log("I hit an NPC");
            other.gameObject.GetComponent<NPC>().StartInteraction();
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("NPC")) {
            other.gameObject.GetComponent<NPC>().StopInteraction();
        }
    }
}
