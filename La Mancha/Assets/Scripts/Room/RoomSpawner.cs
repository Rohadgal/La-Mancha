using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public GameObject[] rooms;

    // Start is called before the first frame update
    void Start()
    {
        SpawnRoom();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnRoom()
    {
        GameObject room = Instantiate(rooms[Random.Range(0, rooms.Length)], transform.position, Quaternion.identity);
    }
}
