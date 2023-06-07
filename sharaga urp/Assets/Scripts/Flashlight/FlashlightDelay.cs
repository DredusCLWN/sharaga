using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightDelay : MonoBehaviour
{
    public Transform flashlight;
    public float maxDistance = 10f; // максимальное расстояние, на которое может переместиться фонарик
    public float minDistance = 2f; // минимальное расстояние, на которое может переместиться фонарик
    private Vector3 previousPosition;
    private Vector3 currentVelocity;

    void Start()
    {
        previousPosition = flashlight.position;
    }

    void Update()
    {
        // Получить новую позицию камеры
        Vector3 cameraPosition = Camera.main.transform.position;

        // Ограничить перемещение фонарика по осям Z и X
        Vector3 targetPosition = cameraPosition + Camera.main.transform.forward * maxDistance;
        targetPosition.x = Mathf.Clamp(targetPosition.x, cameraPosition.x - maxDistance, cameraPosition.x + maxDistance);
        targetPosition.z = Mathf.Clamp(targetPosition.z, cameraPosition.z - maxDistance, cameraPosition.z + maxDistance);

        // Ограничить расстояние до фонарика
        Vector3 direction = targetPosition - cameraPosition;
        float distance = Mathf.Clamp(direction.magnitude, minDistance, maxDistance);
        Vector3 targetPositionClamped = cameraPosition + direction.normalized * distance;

        // Вычислить новую позицию фонарика с задержкой
        Vector3 delayedPosition = Vector3.SmoothDamp(previousPosition, targetPositionClamped, ref currentVelocity, 0.02f);

        // Обновить позицию фонарика
        flashlight.position = delayedPosition;

        // Сохранить текущую позицию фонарика как предыдущую для следующего кадра
        previousPosition = flashlight.position;
    }
}
