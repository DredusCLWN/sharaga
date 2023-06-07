using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchController : MonoBehaviour
{
    public float crouchHeight = 0.5f;
    public float crouchSpeed = 6.0f;
    public float crouchMoveSpeedMultiplier = 0.5f;
    public KeyCode crouchKey = KeyCode.LeftControl;
    public AudioClip crouchSound;
    public AudioClip standSound;
    public PlayerController playerController;
    public CharacterController controller;
    private float standingHeight;
    private float targetHeight;
    private float heightVelocity;
    private AudioSource audioSource;

    public float crouchCooldown = 2f;
    private float lastCrouchTime;

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        controller = player.GetComponent<CharacterController>();
        standingHeight = controller.height;
        targetHeight = standingHeight;
        heightVelocity = 0f;
        audioSource = GetComponent<AudioSource>();
        lastCrouchTime = -crouchCooldown;
    }

    void Update()
    {  
        if (Input.GetKeyDown(crouchKey) && targetHeight != crouchHeight)
        {

            targetHeight = crouchHeight;
            audioSource.PlayOneShot(crouchSound);
            lastCrouchTime = Time.time;
        }
        else if (Input.GetKeyUp(crouchKey) && targetHeight == crouchHeight)
        {
            targetHeight = standingHeight;
            audioSource.PlayOneShot(standSound);

        }


        controller.height = Mathf.SmoothDamp(controller.height, targetHeight, ref heightVelocity, crouchSpeed * Time.deltaTime);
    }

    IEnumerator Crouch()
    {
        float t = 0;
        float startingHeight = controller.height;

        while (t < 1)
        {
            t += Time.deltaTime * crouchSpeed;
            controller.height = Mathf.Lerp(startingHeight, crouchHeight, t);
            yield return null;
        }
    }
}