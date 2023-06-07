// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PickUpKey : MonoBehaviour
// {

//     public GameObject camera;
//     public float distance = 15f;
//     GameObject key;
//     bool canPickUp = false;
   

    
//     void Update()
//     {
//         //при нажатии происходит подбор или выброс предмета
//         if (Input.GetKeyDown(KeyCode.E)) PickUp();
//         if (Input.GetKeyDown(KeyCode.Q)) Drop();
//     }

//     void PickUp()
//     {
//         RaycastHit hit;//переменная попадания луча

//         /*если мы будем смотреть прямо на предмет с тегом 
//         кей который будет от нас на растоянии на 15 
//         едениц и если мы уже взяли до этого какой то предмет то сработает метод дроп*/
//         if(Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, distance))
//         {
//             if(hit.transform.tag == "Key")
//             {
//                 if (canPickUp) Drop();

//                 key = hit.transform.gameObject;
//                 key.GetComponent<Rigidbody>().isKinematic = true;
//                 key.GetComponent<Collider>().isTrigger = true;
//                 key.transform.parent = transform;
//                 key.transform.localPosition = Vector3.zero;
//                 key.transform.localEulerAngles = new Vector3(10f, 0f, 0f);
//                 canPickUp = true;
//             }
//         }

        
//     }

//     void Drop()
//     {
//         key.transform.parent = null;
//         key.GetComponent<Rigidbody>().isKinematic = false;
//         key.GetComponent<Collider>().isTrigger = false;
//         canPickUp = false;
//         key = null;
//     }
// }
