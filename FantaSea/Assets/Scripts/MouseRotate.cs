using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class MouseRotate : MonoBehaviour
{

    public float sensitivity;
    public Transform body;
    float xRotation = 0f;
    float x, y;
    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate() {
        xRotation -= y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        body.Rotate(Vector3.up * x);
    }

    public void CamMove(InputAction.CallbackContext context) {
        x = context.ReadValue<float>() * (sensitivity / 2);
    }

    public void CamY(InputAction.CallbackContext context) {
        y = context.ReadValue<float>() * (sensitivity / 2);
    }

}
