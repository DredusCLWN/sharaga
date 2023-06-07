using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeAmount = 0.1f;
    public float shakeSpeed = 10f;
    public float shakeDuration = 0.2f;

    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private float shakeTime = 0f;

    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f)
        {
            // Calculate the amount of camera shake based on the player's movement
            float shakeX = Input.GetAxis("Horizontal") * shakeAmount;
            float shakeY = Input.GetAxis("Vertical") * shakeAmount;

            // Add the camera shake to the camera's position
            transform.position = new Vector3(transform.position.x + shakeX, transform.position.y + shakeY, transform.position.z);

            // Calculate the amount of camera rotation based on the player's movement
            float rotationAmount = Mathf.Sin(Time.time * shakeSpeed) * shakeAmount;
            Quaternion rotation = Quaternion.Euler(originalPosition + new Vector3(0f, 0f, rotationAmount));

            // Add the camera rotation to the camera's original rotation
            transform.rotation = originalRotation * rotation;

            // Update the shake time
            shakeTime += Time.deltaTime;

            // If the shake duration has elapsed, reset the camera position and rotation
            if (shakeTime >= shakeDuration)
            {
                transform.position = originalPosition;
                transform.rotation = originalRotation;
                shakeTime = 0f;
            }
        }
        else
        {
            // If the player is not moving, reset the camera position and rotation
            transform.position = originalPosition;
            transform.rotation = originalRotation;
            shakeTime = 0f;
        }
    }

    void Start()
    {
        // Store the camera's original position and rotation
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }
}
