using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickOnDoor : MonoBehaviour
{
    public RoomSpawner roomSpawner;

    void OnMouseDown()
    {
        if (!Combate.enCombate && PlayerMovementOnClick.canMove)
        {
            FindObjectOfType<AudioManager>().Play("Door");
            StartCoroutine(esperate());
        }
    }

    IEnumerator esperate()
    {
        roomSpawner.SpawnRoom(transform.parent.transform.parent.gameObject);
        yield return new WaitForSeconds(.2f);
        NavMeshBaker.Bake();

        yield return new WaitForSeconds(.2f);

        PlayerMovementOnClick.Move(roomSpawner.transform.position);
        PlayerMovementOnClick.TurnCameraOnOff(true);
    }
}
