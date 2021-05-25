using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotate : MonoBehaviour
{

    public float sensitivity = 100f;
    public Transform body;
    float xRotation = 0f;
    float x, y;
    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update() {
        x = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        y = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        body.Rotate(Vector3.up * x);

    }
}
