using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBob : MonoBehaviour
{
    [Header("Bobbing Parameters")]

    public float bobFrequency = 2.5f;  // частота покачивания камеры
    public float bobHeight = 0.3f;  // амплитуда покачивания камеры
    public float walkBobFrequency = 1.5f;  // Частота покачивания камеры при ходьбе
    public float runBobFrequency = 3f;     // Частота покачивания камеры при беге
    public float bobSmoothness = 0.5f;
    public float walkSpeed = 5.0f;  // скорость ходьбы, для которой настроено покачивание
    public float runSpeed = 10.0f;  // скорость бега, для которой настроено покачивание

    private float bobTimer = 0.0f;  // таймер для расчета покачивания камеры
    private float bobAmount = 0.0f;  // текущая амплитуда покачивания камеры

    private Vector3 cameraLocalPosition;

    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponentInParent<CharacterController>();
        cameraLocalPosition = transform.localPosition;
    }

    void Update()
        {
            float speed = characterController.velocity.magnitude;
            if (speed > 0.1f && characterController.isGrounded)
            {
                if (speed < walkSpeed)
                {
                    bobAmount = bobHeight;
                }
                else if (speed < runSpeed)
                {
                    bobAmount = bobHeight * 2.0f;
                }
                else
                {
                    bobAmount = bobHeight * 3.0f;
                }
                if (speed < walkSpeed)
                {
                    bobFrequency = walkBobFrequency;
                }
                else
                {
                    bobFrequency = runBobFrequency;
                }

                bobTimer += Time.deltaTime * speed * bobFrequency;
                float sin = Mathf.Sin(bobTimer);
                Vector3 targetPosition = cameraLocalPosition + new Vector3(0.0f, sin * bobAmount, 0.0f);
                transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, bobSmoothness * Time.deltaTime);
            }
            else
            {
                bobTimer = 0.0f;
                transform.localPosition = Vector3.Lerp(transform.localPosition, cameraLocalPosition, bobSmoothness * Time.deltaTime);
            }
        }
}
