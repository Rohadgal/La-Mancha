using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickOnDoor : MonoBehaviour
{
    public RoomSpawner roomSpawner;
    public NavMeshSurface navMeshSurface;
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        // this object was clicked - do something
        //Destroy(this.gameObject);
        this.gameObject.transform.position = new Vector3(0, 100,0);
        StartCoroutine(esperate());
        roomSpawner.SpawnRoom();
        navMeshSurface.BuildNavMesh();
        PlayerMovementOnClick.Move(roomSpawner.transform.position);

    }

    IEnumerator esperate()
    {
        yield return new WaitForSeconds(0.5f);
        
    }
}
