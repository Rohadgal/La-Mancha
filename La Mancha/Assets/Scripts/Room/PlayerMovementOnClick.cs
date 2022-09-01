using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovementOnClick : MonoBehaviour
{
    static GameObject player;
    public GameObject followCamera, movementCamera;
    static GameObject s_followCamera, s_movementCamera;
    static bool moving = false;
    public static NavMeshAgent navMeshAgent;
    public static NavMeshSurface meshSurface;
    
    private void Start()
    {
        player = gameObject;
        s_followCamera = followCamera;
        s_movementCamera = movementCamera;
        navMeshAgent = GetComponent<NavMeshAgent>();
        meshSurface = GetComponent<NavMeshSurface>();
    }

    private void Update()
    {
        if (moving)
        {
            if (navMeshAgent.remainingDistance < 0.1)
            {
                s_followCamera.SetActive(false);
                s_movementCamera.SetActive(true);
                s_movementCamera.transform.position = s_followCamera.transform.position;
                moving = false;
            }// Checar si ya llego a su destino
        }// Checar si se esta moviendo
    }
    public static void Move(Vector3 position)
    {
        s_followCamera.SetActive(true);
        s_movementCamera.SetActive(false);
        moving = true;
        navMeshAgent.destination = position;
    }

    public static void Bake()
    {
        meshSurface.BuildNavMesh();
        Debug.Log("En destino");
    }

    public static void TurnCameraOnOff(bool apagarCamara)
    {
        s_followCamera.SetActive(apagarCamara);
        s_movementCamera.SetActive(!apagarCamara);
    }

}
