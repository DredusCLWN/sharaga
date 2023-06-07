using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused = false;
    public Flashlight flashlight;
    public Flashlight flashlight2;
    public PlayerController playerController;
    public AudioSource[] soundsToPause;


    public AudioSource pauseMenuAudio;
    public AudioClip audioClip;

    void Start()
{
    pauseMenu.gameObject.SetActive(false);
}

void Update()
{
    if (Input.GetKeyDown(KeyCode.Escape))
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }
}

void PauseGame()
{
    Debug.Log("Game paused.");
    isPaused = true;
    Time.timeScale = 0f;

    foreach (AudioSource audioSource in soundsToPause)
    {
        audioSource.enabled = false;
    }
    
    pauseMenu.gameObject.SetActive(true);
    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;
    if (flashlight != null)
    {
        flashlight.enabled = false;
        flashlight2.enabled = false;
    }
    if(playerController != null)
    {
        playerController.enabled = false;
    }

    if (pauseMenuAudio != null)
    {
        pauseMenuAudio.PlayOneShot(audioClip);
    }
}

public void ResumeGame()
{
    Debug.Log("Game resumed.");
    isPaused = false;
    Time.timeScale = 1f;

    foreach (AudioSource audioSource in soundsToPause)
    {
        audioSource.enabled = true;
    }

    pauseMenu.gameObject.SetActive(false);
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
    if (flashlight != null)
    {
        flashlight.enabled = true;
        flashlight2.enabled = true;
    }
     if(playerController != null)
    {
        playerController.enabled = true;
    }
    if (pauseMenuAudio != null)
    {
        pauseMenuAudio.Stop();
    }
}
}





