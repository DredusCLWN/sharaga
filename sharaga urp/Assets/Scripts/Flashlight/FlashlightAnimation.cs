using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class FlashlightAnimation : MonoBehaviour
// {
//     public Animator animator;
//     private bool isAnimating = false;

//     private void OnTriggerEnter(Collider other)
//     {
//         if (other.CompareTag("Player"))
//         {
//             return;
//         }

//         if (!isAnimating)
//         {
//             animator.SetTrigger("Wall");
//             isAnimating = true;
//         }
//     }

//     private void OnTriggerExit(Collider other)
//     {
//         if (other.CompareTag("Player"))
//         {
//             return;
//         }

//         isAnimating = false;
//     }
// }
