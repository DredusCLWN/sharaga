using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointlight : MonoBehaviour
{
    private Light flashlight;

    void Start()
    {
        flashlight = GetComponent<Light>();
        flashlight.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            flashlight.enabled = !flashlight.enabled;
        }
    }
}
