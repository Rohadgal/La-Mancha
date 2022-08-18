using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickOnDoor : MonoBehaviour
{
    public RoomSpawner roomSpawner;

    void OnMouseDown()
    {
        // this object was clicked - do something
        //Destroy(this.gameObject);
        //this.gameObject.transform.position = new Vector3(0, 100,0);
        StartCoroutine(esperate());

    }

    IEnumerator esperate()
    {
        roomSpawner.SpawnRoom();
        yield return new WaitForSeconds(.2f);
        NavMeshBaker.Bake();
        PlayerMovementOnClick.Move(roomSpawner.transform.position);
    }
}
