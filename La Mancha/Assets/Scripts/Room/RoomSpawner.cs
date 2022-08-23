using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public enum SpawnPos { Norte, Sur, Este, Oeste };
    public SpawnPos myPos;
    public GameObject[] rooms;

    public void SpawnRoom(GameObject lastRoom)
    {
        GameObject room = Instantiate(rooms[Random.Range(0, rooms.Length)], transform.position, Quaternion.identity);
        float[] dist = new float[room.transform.GetChild(1).childCount];

        int count = 0;
        foreach (Transform child in room.transform.GetChild(1))
        {
            dist[count] = Vector3.Distance(child.position, lastRoom.transform.position);
            Debug.Log(dist[count]);
            count++;
        }

        float minValue = Mathf.Min(dist);

        for (int i = 0; i < dist.Length; i++)
        {
            if(dist[i] == minValue)
            {
                Debug.Log("Valor minimo encontrado");
                //room.transform.GetChild(2).GetChild(i).position = lastRoom.transform.position;
                //room.transform.LookAt(room.transform.GetChild(2).GetChild(i));
                return;
            }
        }

        //room.transform.Rotate(new Vector3(0, room.transform.localRotation.y, 0));
    }
}
