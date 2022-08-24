using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofres : MonoBehaviour
{
    [Range(0,1)]
    public float spawnProbability;

    enum CofreOpcion { Mancha, Enemigo, Item };

   
 

    private void Start()
    {
        Debug.Log("Existo");
        if (Random.value <= spawnProbability)
        {
            MadFix(false);
        }
        else
        {
            MadFix(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        var enumLength = CofreOpcion.GetNames(typeof(CofreOpcion)).Length;
        int azarNum = Random.Range(0, enumLength);
        switch (azarNum)
        {
            case 0: LaMancha(); break;
            case 1: Enemigo(); break;
            case 2: Item(); break;
        }
        MadFix(false);
    }

    void LaMancha()
    {
        Debug.Log("Llegó la Mancha!!!");
    }

    void Enemigo()
    {
        Debug.Log("Apareció enemigo");
    }

    void Item()
    {
        Debug.Log("Encontraste Item");
    }

    void MadFix(bool estado)
    {
        gameObject.GetComponent<MeshRenderer>().enabled = estado;
        gameObject.GetComponent<Collider>().enabled = estado;
    }
}
