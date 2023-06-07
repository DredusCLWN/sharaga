using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JumpSound : MonoBehaviour
{
    public AudioClip jumpSound;
    public AudioClip[] landingSounds;
    public CharacterController characterController;

    private AudioSource audioSource;
    private bool isJumping = false;
    private bool hasLanded = false;
    private AudioClip landSound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Check if the space key is pressed and the character is on the ground
        if (Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded)
        {
            // Start the jump
            isJumping = true;
            audioSource.PlayOneShot(jumpSound);
            hasLanded = false; // reset landing flag on jump
        }
    }

    void FixedUpdate()
    {
        // Check if the character touches the ground
        if (!isJumping && characterController.isGrounded && !hasLanded)
        {
            PlayRandomLandingSound();
            hasLanded = true;
        }

        // End the jump if the character has reached the maximum jump height
        if (isJumping && characterController.velocity.y < 0)
        {
            isJumping = false;
        }
    }

    private void PlayRandomLandingSound()
    {
        AudioClip newSound = landingSounds[Random.Range(0, landingSounds.Length)];
        if (newSound != landSound)
        {
            landSound = newSound;
            audioSource.PlayOneShot(landSound);
        }
        else
        {
            // If the new sound is the same as the previous one, try again
            PlayRandomLandingSound();
        }
    }
}



