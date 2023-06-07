using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    public float fadeTime = 1f; // время на затухание и появление панели
    public float delayTime = 5f; // время задержки между затуханием и появлением панели

    private CanvasGroup canvasGroup;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        // Запускаем корутину, которая будет затухать и появляться каждые delayTime секунд
        StartCoroutine(FadeInOut(delayTime));
    }

    IEnumerator FadeInOut(float delay)
    {
        while (true)
        {
            // Затухание панели
            yield return StartCoroutine(FadeCanvasGroup(canvasGroup, canvasGroup.alpha, 0f, fadeTime));

            // Задержка перед появлением панели
            yield return new WaitForSeconds(delay);

            // Появление панели
            yield return StartCoroutine(FadeCanvasGroup(canvasGroup, canvasGroup.alpha, 1f, fadeTime));

            // Задержка перед следующим затуханием
            yield return new WaitForSeconds(delay);
        }
    }

    IEnumerator FadeCanvasGroup(CanvasGroup canvasGroup, float startAlpha, float endAlpha, float duration)
    {
        float startTime = Time.time;
        float endTime = startTime + duration;

        while (Time.time < endTime)
        {
            float timeRatio = (Time.time - startTime) / duration;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, timeRatio);

            yield return null;
        }

        canvasGroup.alpha = endAlpha;
    }
}
