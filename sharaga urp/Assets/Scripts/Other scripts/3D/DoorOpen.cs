using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
public GameObject door;
public GameObject key;

private void OnTriggerEnter(Collider collision)
    {   
        if(collision.tag == "Key")
        {
            door.SetActive(false);
            key.SetActive(false);
        }
    }
}

