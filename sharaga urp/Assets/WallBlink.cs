using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBlink : MonoBehaviour
{
    // ссылка на источник света
    public Light flashlight;

    // параметры бликов
    public float minSize = 0.1f;
    public float maxSize = 1.0f;
    public float minBrightness = 0.1f;
    public float maxBrightness = 1.0f;

    // расстояние между игроком и объектом
    float distance;

    void Update()
    {
        // получаем все объекты в сцене
        GameObject[] objects = FindObjectsOfType<GameObject>();

        GameObject closestObject = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject obj in objects)
        {
            // определяем расстояние между игроком и объектом
            distance = Vector3.Distance(transform.position, obj.transform.position);

            // если расстояние меньше заданного значения
            if (distance < 2.0f)
            {
                // если объект ближе, чем предыдущий ближайший объект
                if (distance < closestDistance)
                {
                    closestObject = obj;
                    closestDistance = distance;
                }
            }
        }

        // если есть ближайший объект
        if (closestObject != null)
        {
            // задаем случайный размер и яркость блика
            float size = Random.Range(minSize, maxSize);
            float brightness = Random.Range(minBrightness, maxBrightness);

            // устанавливаем параметры блика
        flashlight.range = Mathf.Lerp(flashlight.range, size, Time.deltaTime);
        flashlight.intensity = Mathf.Lerp(flashlight.intensity, brightness, Time.deltaTime);
        }
        else
        {
            // если ближайший объект не найден, выключаем блик
            flashlight.range = 0;
            flashlight.intensity = 0;
        }
    }
}
