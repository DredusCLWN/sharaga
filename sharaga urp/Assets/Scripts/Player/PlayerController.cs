using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
public float walkSpeed = 2f;  // скорость ходьбы персонажа
public float runSpeed = 5f;  // скорость бега персонажа

public float gravity = 20.0f;   // гравитация
public AudioSource walkSound;
public AudioSource runSound;
public float volume = 0.5f;
public Vector3 moveDirection = Vector3.zero;
private CharacterController controller;
private bool isWalking;
public bool isRunning;
public bool isCrouching;
public bool isGrounded;




void Start()
{
    controller = GetComponent<CharacterController>();
}

void Update()
{

    if(Input.GetKey(KeyCode.LeftControl))
    {
        walkSpeed = 1f;
        volume = 0;
    }
    else
    {
        walkSpeed = 2f;
        volume = 0.2f;
    }
if (controller.isGrounded)
{
    float speed = isRunning ? runSpeed : walkSpeed;

    moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    moveDirection = transform.TransformDirection(moveDirection).normalized; // Normalize the vector
    moveDirection *= speed;

    // Звуки ходьбы и бега
    if (moveDirection.magnitude > 0.01f && controller.collisionFlags.HasFlag(CollisionFlags.Below))
    {
    if (isRunning && !runSound.isPlaying)
    {
        walkSound.Stop();
        runSound.Play();
        isWalking = false;
    }
    else if (!isRunning && !isWalking && !walkSound.isPlaying)
    {
        runSound.Stop();
        walkSound.Play();
        isWalking = true;
    }

    // Плавное изменение громкости звука
    if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
    {
        float targetVolume = isRunning ? (volume * speed / runSpeed) : (volume * speed / walkSpeed);
        walkSound.volume = Mathf.Lerp(walkSound.volume, targetVolume, Time.deltaTime * 8f);
        runSound.volume = Mathf.Lerp(runSound.volume, targetVolume, Time.deltaTime * 8f);
    }
    else
    {
        walkSound.volume = Mathf.Lerp(walkSound.volume, 0f, Time.deltaTime * 8f);
        runSound.volume = Mathf.Lerp(runSound.volume, 0f, Time.deltaTime * 8f);
    }
}
        // Переключение на бег
        isRunning = (Input.GetKey(KeyCode.LeftShift) && moveDirection.magnitude > 0.01f);
        isRunning = (!Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftShift) && moveDirection.magnitude > 0.01f);

    }
    else
    {
        runSound.Stop();
        walkSound.Stop();
        isWalking = false;
    }

    moveDirection.y -= gravity * Time.deltaTime;
    controller.Move(moveDirection * Time.deltaTime);
}
}
