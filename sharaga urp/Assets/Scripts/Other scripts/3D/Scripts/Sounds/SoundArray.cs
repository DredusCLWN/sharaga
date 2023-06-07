using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundArray : MonoBehaviour
{
    public AudioClip[] sounds;
    public float minTimeBetweenSounds = 10f;
    public float maxTimeBetweenSounds = 20f;

    private AudioSource audioSource;
    private float timeUntilNextSound = 0f;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        timeUntilNextSound = Random.Range(minTimeBetweenSounds, maxTimeBetweenSounds);
    }

    private void Update()
    {
        timeUntilNextSound -= Time.deltaTime;

        if (timeUntilNextSound <= 0f)
        {
            PlayRandomSound();
            timeUntilNextSound = Random.Range(minTimeBetweenSounds, maxTimeBetweenSounds);
        }
    }

    private void PlayRandomSound()
    {
        int randomIndex = Random.Range(0, sounds.Length);
        audioSource.PlayOneShot(sounds[randomIndex]);
    }
}
