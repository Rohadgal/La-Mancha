using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{

    private void Awake()
    {
        SetDoorPosition();
        //Debug.Log("Nombre de puerta: " + gameObject.name + " Posicion: " + transform.localPosition);
    }

    private void OnTriggerStay(Collider collision)
    {
        
        if (collision.gameObject.CompareTag("Cuarto"))
        {
            //Debug.Log(gameObject.name + "Choco con: " + collision.gameObject.name);
            gameObject.transform.position = new Vector3(0, 100, 0);
            //StartCoroutine(esperate());
            //Destroy(gameObject, 2);
            //Destroy(collision.gameObject);
        }
    }

    IEnumerator esperate()
    {
        yield return new WaitForSeconds(.3f);
        gameObject.transform.position = new Vector3(0, 100, 0);
    }

    void SetDoorPosition()
    {
        if(gameObject.name == "PuertaNorte")
        {
            transform.localPosition = new Vector3(0, 0.487199992f, 0.564999998f);
        }
        else if(gameObject.name == "PuertaSur")
        {
            transform.localPosition = new Vector3(0, 0.487199992f, -0.564999998f);
        }
        else if(gameObject.name == "PuertaEste")
        {
            transform.localPosition = new Vector3(0.564999998f, 0.487199992f, 0);
        }
        else if(gameObject.name == "PuertaOeste")
        {
            transform.localPosition = new Vector3(-0.564999998f, 0.487199992f, 0);
        }
    }
}

