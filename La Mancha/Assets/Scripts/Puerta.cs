using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Cuarto"))
        {
            Debug.Log(gameObject.name + "Choco con: " + collision.gameObject.name);
            StartCoroutine(esperate());
            //Destroy(gameObject, 2);
            //Destroy(collision.gameObject);
        }
    }

    IEnumerator esperate()
    {
        yield return new WaitForSeconds(5f);
        gameObject.transform.position = new Vector3(0, 100, 0);
    }
}

