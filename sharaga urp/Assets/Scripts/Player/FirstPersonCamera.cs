using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public float sensitivity = 100f;
    public float maxVerticalAngle = 800f;
    public float minVerticalAngle = -80f;

    float verticalRotation = 0f;
void Start() 
{
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;

    verticalRotation = transform.localRotation.eulerAngles.x; // Initialize verticalRotation to the current x rotation
}
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, minVerticalAngle, maxVerticalAngle);

        transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        transform.parent.Rotate(Vector3.up * mouseX);
    }
}
