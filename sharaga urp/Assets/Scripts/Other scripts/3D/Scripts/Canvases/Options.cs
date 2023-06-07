using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    
    public GameObject options;
    public GameObject graphics;
    public GameObject sound;
    public GameObject control;
    void Start()
    {
        options.SetActive(false);
        graphics.SetActive(false);
        sound.SetActive(false);
        control.SetActive(false);
    }
    public void OptionsButton()
    {
        options.SetActive(!options.activeSelf);
    }
    public void GraphicsButton()
    {
        graphics.SetActive(true);
        sound.SetActive(false);
        control.SetActive(false);
    }
    public void SoundsButton()
    {
        graphics.SetActive(false);
        sound.SetActive(true);
        control.SetActive(false);
    }
    public void ControlButton()
    {
        graphics.SetActive(false);
        sound.SetActive(false);
        control.SetActive(true);
    }
}
