// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.AI;
// using UnityEngine.SceneManagement;

// public class AI_Monster : MonoBehaviour
// {
//    private NavMeshAgent AI_Agent;
//     private GameObject Player;
//     public Transform[] WayPoints;
//     public int Current_Patch; 
//     public enum AI_State { Patrol, Stay, Chase };
//     public AI_State AI_Enemy;

//     private Transform Last_point;
//     public bool Check_LastPoint;
//     float i_stay;
//     void Start()
//     {
//         AI_Agent = gameObject.GetComponent<NavMeshAgent>();
//         Player = GameObject.FindGameObjectWithTag("Player");
//     }
    
//     void FixedUpdate()
//     {
//         if (Check_LastPoint == false)
//         {
//         if(AI_Enemy == AI_State.Patrol)
//         {
//             AI_Agent.Resume();
//             gameObject.GetComponent<Animator>().SetBool("Move", true);
//             // параметр move из аниматора для проверки движения(запуск анимации ходьбы)
            
//             // монстр будет бежать к заданому списку точек
//             AI_Agent.SetDestination(WayPoints[Current_Patch].transform.position);
//             float Patch_Dist = Vector3.Distance(WayPoints[Current_Patch].transform.position, gameObject.transform.position);
//                 if (Patch_Dist < 2)//проверка на точки, для того чтобы монстр не стоял на одной точке
//                 {
//                 Current_Patch++;
//                 Current_Patch = Current_Patch % WayPoints.Length;//при конечной точке монстр начинает движение с 1 точки
//                 }
//         }
//         if(AI_Enemy == AI_State.Stay)
//         {   
//             //при состоянии покоя, анимация ходьбы останавливается
//             gameObject.GetComponent<Animator>().SetBool("Move", false);
//             AI_Agent.Stop();
//         }
//         if (AI_Enemy == AI_State.Chase)
//         {//при видимости игрока, монстр начинает с ним сближаться
//             gameObject.GetComponent<Animator>().SetBool("Move", true);
//             AI_Agent.SetDestination(Player.transform.position);
//             //если монстр потерял из виду игрока, то проверяет последнюю точку, где его видел
//             if (gameObject.GetComponent<FieldOfView>().canSeePlayer == false)
//                 {
//                     Last_point = Player.transform;
//                     Check_LastPoint = true;
//                 }
//                 else
//                 {
//                     AI_Agent.SetDestination(Player.transform.position);
//                 }
//             } 
//         }
//         else
//         {
//             AI_Agent.Resume();
//             i_stay += 2 * Time.deltaTime;
//             float Point_Dist = Vector3.Distance(Last_point.transform.position, gameObject.transform.position);
//             //если после проверки точки прошло 7 секунд, то монстр идет по своим делам
//             if (Point_Dist <2 || i_stay >= 5)
//             {
//                 Check_LastPoint = false;
//                 AI_Enemy = AI_State.Patrol;
//                 i_stay = 0;
//             }
//             else
//             {
//                 gameObject.GetComponent<Animator>().SetBool("Move", true);

//             }
//         }
//         //сближение между игроком и врагом
//         float Dist_Player = Vector3.Distance(Player.transform.position, gameObject.transform.position); 
//         //при смерти игрока выскакивает меню проигрыша

//         if(Dist_Player < 2)
//         {
//             Player.SetActive(false);
//             SceneManager.LoadScene(3);
//         }
//     }
// }

