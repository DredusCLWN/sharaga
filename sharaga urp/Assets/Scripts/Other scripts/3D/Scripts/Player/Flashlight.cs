using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Flashlight : MonoBehaviour
{
    private Light flashlight;
    public float minTimeBetweenFlashes = 30f;
    public float maxTimeBetweenFlashes = 60f;

    private float timeSinceLastFlash = 0f;

    private int numFlashes = 5; 
    private float flashDuration = 0.05f;
    private bool isFlashing = false;

    public float batteryLevel = 100f; // Start with a full battery

    public float batteryDrainAmount = 0.1f; // Amount of battery drained every second
    public Slider slider;

    void Start()
    {
        flashlight = GetComponent<Light>();
        flashlight.enabled = false;
        if (slider == null)
            {
            slider = GetComponent<Slider>();
            }

    }

void Update()
{
    Debug.Log("Flashlight enabled: " + flashlight.enabled);
    Debug.Log("Battery level: " + batteryLevel);
    slider.value = batteryLevel;


    timeSinceLastFlash += Time.deltaTime;

    // Check if the battery is dead and toggle the flashlight accordingly
    if (batteryLevel <= 0f)
    {
        flashlight.intensity = 0.1f;
        isFlashing = false;
        timeSinceLastFlash = 0f;
    }
    else
    {
        if (!isFlashing && Input.GetKeyDown(KeyCode.F))
        {
            GetComponent<AudioSource>().Play();
            flashlight.enabled = !flashlight.enabled;
        }

        // Drain the battery only when the flashlight is turned on
        if (flashlight.enabled)
        {
            batteryLevel -= batteryDrainAmount * Time.deltaTime;

            if (batteryLevel <= 0f)
            {
                flashlight.intensity = 0.05f; // Set a low intensity when the battery is dead
                isFlashing = false; // Сброситьфлаг isFlashing, чтобы предотвратить бесконечное мигание фонарика
                timeSinceLastFlash = 0f; // Сбросить время с последнего мигания
            }
            else if (batteryLevel <= 20f)
            {
                flashlight.intensity = 0.5f; // Reduce the intensity when the battery is low
            }
            else
            {
                flashlight.intensity = 1f; // Set the intensity back to normal when the battery level is above 20   
            }
        }
    }

    if (!isFlashing && timeSinceLastFlash >= Random.Range(minTimeBetweenFlashes, maxTimeBetweenFlashes))
    {
        StartCoroutine(FlashlightRoutine());
    }
}

    IEnumerator FlashlightRoutine()
    {
        isFlashing = true;

        for (int i = 0; i < numFlashes; i++)
        {
            flashlight.enabled = !flashlight.enabled;
            yield return new WaitForSeconds(flashDuration);
        }

        isFlashing = false;
        timeSinceLastFlash = 0f;
    }
}