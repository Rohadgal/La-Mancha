using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickOnDoor : MonoBehaviour
{
    public RoomSpawner roomSpawner;

    void OnMouseDown()
    {
        StartCoroutine(esperate());
    }

    IEnumerator esperate()
    {
        roomSpawner.SpawnRoom(transform.parent.transform.parent.gameObject);
        yield return new WaitForSeconds(.2f);
        NavMeshBaker.Bake();
        PlayerMovementOnClick.TurnCameraOnOff(true);
        PlayerMovementOnClick.Move(roomSpawner.transform.position);
    }
}
