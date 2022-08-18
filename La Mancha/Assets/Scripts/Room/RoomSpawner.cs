using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public GameObject[] rooms;

    public void SpawnRoom()
    {
        GameObject room = Instantiate(rooms[Random.Range(0, rooms.Length)], transform.position, Quaternion.identity);
    }
}
