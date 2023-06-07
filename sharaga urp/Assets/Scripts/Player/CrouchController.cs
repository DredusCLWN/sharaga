using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchControler : MonoBehaviour
{
    public float crouchHeight = 0.5f;  // высота персонажа в приседе
    public float crouchSpeed = 6.0f;  // скорость изменения высоты при приседании
    public KeyCode crouchKey = KeyCode.LeftControl;  // клавиша для приседания

    private CharacterController controller;
    private float standingHeight;
    private bool isCrouching = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        standingHeight = controller.height;
    }

void Update()
{
    if (Input.GetKeyDown(crouchKey))
    {
        if (isCrouching)
        {
            // вставание из приседа
            StartCoroutine(StandUp());
            isCrouching = false;
        }
        else
        {
            // приседание
            StartCoroutine(Crouch());
            isCrouching = true;
        }
    }
}

IEnumerator Crouch()
{
    float t = 0;
    float startingHeight = controller.height;

    while (t < 1)
    {
        t += Time.deltaTime * crouchSpeed;
        controller.height = Mathf.Lerp(startingHeight, crouchHeight, t);
        yield return null;
    }
}

IEnumerator StandUp()
{
    float t = 0;
    float startingHeight = controller.height;

    while (t < 1)
    {
        t += Time.deltaTime * crouchSpeed;
        controller.height = Mathf.Lerp(startingHeight, standingHeight, t);
        yield return null;
    }
}
}