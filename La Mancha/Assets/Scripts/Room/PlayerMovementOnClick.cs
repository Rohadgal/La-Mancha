using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovementOnClick : MonoBehaviour
{
    static GameObject player;
    public static NavMeshAgent navMeshAgent;
    public static NavMeshSurface meshSurface;
    
    private void Start()
    {
        player = gameObject;
        navMeshAgent = GetComponent<NavMeshAgent>();
        meshSurface = GetComponent<NavMeshSurface>();
    }
    public static void Move(Vector3 position)
    {
        //player.transform.position = new Vector3(position.x, player.transform.position.y, position.z);
        navMeshAgent.destination = position;
    }


    public static void Bake()
    {
        meshSurface.BuildNavMesh();
    }
}
