using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
 
public class ToggleGlobalVolume : MonoBehaviour
{
    public Volume globalVolume;
 
    // Эффекты, которые нужно включить
    private Vignette vignette;
    private FilmGrain filmGrain;
    private LensDistortion lensDistortion;
    private PaniniProjection paniniProjection;

    private ChromaticAberration chromaticAberration;

    public Canvas canvas;

    private bool effectsEnabled = false;

    public AudioClip soundEffect;
    public AudioClip soundOffEffect;


    private AudioSource audioSource;

    private void Start()
    {
        canvas.enabled = false;
        // Получаем компонент Volume из глобального объекта Volume
        globalVolume = FindObjectOfType<Volume>();
 
        // Находим нужные эффекты в VolumeProfile
        globalVolume.profile.TryGet(out vignette);
        globalVolume.profile.TryGet(out filmGrain);
        globalVolume.profile.TryGet(out lensDistortion);
        globalVolume.profile.TryGet(out paniniProjection);

        globalVolume.profile.TryGet(out chromaticAberration);

        // Получаем компонент AudioSource
        audioSource = GetComponent<AudioSource>();
    }
 
    private void Update()
    {
        // Включаем или выключаем эффекты при нажатии на кнопку F
        if (Input.GetKeyDown(KeyCode.X))
        {
            effectsEnabled = !effectsEnabled; // меняем значение флага при каждом нажатии кнопки
            vignette.active = effectsEnabled;
            filmGrain.active = effectsEnabled;
            lensDistortion.active = effectsEnabled;
            paniniProjection.active = effectsEnabled;

            chromaticAberration.active = effectsEnabled;

            // Если эффекты включены, проигрываем звуковой эффект
            if (effectsEnabled)
            {
                audioSource.PlayOneShot(soundEffect);
            }
            else
            {
                audioSource.PlayOneShot(soundOffEffect);
            }

            // Включаем или выключаем Canvas в зависимости от того, включены ли эффекты
            canvas.enabled = effectsEnabled;
        }
    }
}
