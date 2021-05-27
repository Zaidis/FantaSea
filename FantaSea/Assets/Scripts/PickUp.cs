using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    //pick up script for picking things up when you want to pick things up so you can pick things up
    //btw this script is good for picking things up :)
    [SerializeField] private bool isHolding;
    [SerializeField] private float maxDistance; //max distance of how far you can pick up objects
    [SerializeField] private float force; //how much force / how hard you throw objects
    public List<GameObject> objects = new List<GameObject>();
    public Transform handLocation;
    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            //left click
            if (!isHolding) {
                //if you are NOT holding anything
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if(Physics.Raycast(ray, out hit, maxDistance)) {
                    if (hit.collider.gameObject.CompareTag("Pickup")) {
                        GameObject obj = hit.collider.gameObject;
                        objects.Add(obj);
                        obj.GetComponent<Rigidbody>().velocity = Vector3.zero;
                        obj.GetComponent<Rigidbody>().useGravity = false;
                        obj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                        obj.transform.parent = handLocation;
                        obj.GetComponent<Rigidbody>().drag = 100;
                        obj.transform.localPosition = Vector3.zero;

                        isHolding = true;
                    }
                }
            } else {
                //you are holding something. so you drop it
                GameObject obj = objects[0].gameObject;
                obj.GetComponent<Rigidbody>().useGravity = true;
                obj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                obj.GetComponent<Rigidbody>().drag = 0;
                obj.transform.parent = null;
                objects.Clear();
                isHolding = false;
            }
        } else if (Input.GetMouseButtonDown(1)) {
            //you chuck it
            if (isHolding) {
                GameObject obj = objects[0].gameObject;
                obj.GetComponent<Rigidbody>().useGravity = true;
                obj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                obj.GetComponent<Rigidbody>().drag = 0;
                obj.GetComponent<Rigidbody>().AddForce(handLocation.transform.forward * force, ForceMode.Impulse);

                obj.transform.parent = null;
                objects.Clear();
                isHolding = false;
            }
        }
    }



}
