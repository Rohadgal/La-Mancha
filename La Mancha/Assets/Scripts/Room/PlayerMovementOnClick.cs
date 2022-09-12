using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovementOnClick : MonoBehaviour
{
    static GameObject player;
    public GameObject followCamera, movementCamera;
    public Animator animator;
    static Animator anim;
    static GameObject s_followCamera, s_movementCamera;
    static bool moving = false;
    public static NavMeshAgent navMeshAgent;
    public static NavMeshSurface meshSurface;
    static Transform target;
    public static bool canMove;
    
    private void Start()
    {
        player = gameObject;
        s_followCamera = followCamera;
        s_movementCamera = movementCamera;
        navMeshAgent = GetComponent<NavMeshAgent>();
        meshSurface = GetComponent<NavMeshSurface>();
        anim = animator;
        canMove = true;
    }

    private void Update()
    {
        if (moving)
        {
            Debug.Log(Vector3.Distance(gameObject.transform.position, navMeshAgent.destination));
            if (Vector3.Distance(gameObject.transform.position, navMeshAgent.destination)< 1f)
            {
                Debug.Log("Llego a destino");
                TurnCameraOnOff(false);
                s_movementCamera.transform.position = s_followCamera.transform.position;
                moving = false;
                anim.SetBool("IsWalking", false);
                canMove = true;
                if(target != null)
                    transform.LookAt(target);
            }// Checar si ya llego a su destino
        }// Checar si se esta moviendo
    }
    public static void Move(Vector3 position)
    {
        canMove = false;
        target = null;
        navMeshAgent.updatePosition = true;
        navMeshAgent.SetDestination(position);
        anim.SetBool("IsWalking", true);
        moving = true;
    }

    public static void Bake()
    {
        meshSurface.BuildNavMesh();
        Debug.Log("En destino");
    }

    public static void TurnCameraOnOff(bool apagarCamara)
    {
        Debug.Log("Apagando camaras");
        s_followCamera.SetActive(apagarCamara);
        s_movementCamera.SetActive(!apagarCamara);
    }

    public static void LookAtTarget(Transform _target)
    {
        target = _target;
        anim.SetTrigger("Find");
    }
}
