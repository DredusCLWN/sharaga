using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PortalEnter : MonoBehaviour
{ 
        private void OnTriggerEnter(Collider other) 
        {
            SceneManager.LoadScene(4);
        }
}
