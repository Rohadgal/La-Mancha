using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public GameObject[] rooms;

    public void SpawnRoom(GameObject lastRoom)
    {
        GameObject room = Instantiate(rooms[Random.Range(0, rooms.Length)], transform.position, Quaternion.identity);
        float[] dist = new float[room.transform.GetChild(1).childCount];

        int count = 0;
        foreach (Transform child in room.transform.GetChild(2))
        {
            dist[count] = Vector3.Distance(child.position, lastRoom.transform.position);
            count++;
        }

        float minValue = Mathf.Min(dist);

        for (int i = 0; i < dist.Length; i++)
        {
            if (dist[i] == minValue)
            {
                room.transform.LookAt(lastRoom.transform.position);
            }
        }
    }
}
