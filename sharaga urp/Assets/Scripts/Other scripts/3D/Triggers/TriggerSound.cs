using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSound : MonoBehaviour
{
    public AudioClip triggerSound;
    private AudioSource audioSource;
    private bool isTriggered = false;
    private void OntriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {// проверка на касание игроком зоны тригера
            if(isTriggered==false)
            {// при касании воспроизводится звук
                isTriggered = true;
                GetComponent<AudioSource>().PlayOneShot(triggerSound);
            }
        }     
    }
}
