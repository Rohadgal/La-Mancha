using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float panSpeed = 20;
    public float panBorderThickness = 10f; // Distancia en pixeles a la que te puedes acercar al borde de la pantalla para empezar el movimiento

    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey("w"))
        {
            pos.x += panSpeed * Time.deltaTime;
        }

        if (Input.GetKey("s"))
        {
            pos.x -= panSpeed * Time.deltaTime;
        }

        if (Input.GetKey("a")) 
        {
            pos.z += panSpeed * Time.deltaTime;
        }

        if (Input.GetKey("d"))
        {
            pos.z -= panSpeed * Time.deltaTime;
        }

        transform.position = pos;
    }
}
