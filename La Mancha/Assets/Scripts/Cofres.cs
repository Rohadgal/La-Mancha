using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofres : MonoBehaviour
{
    [Range(0,1)]
    public float spawnProbability;

    enum CofreOpcion { Mancha, Enemigo, Item, Llave }; 

    Combate combat;
 

    private void Start()
    {
        combat = GameObject.Find("CombatManager").GetComponent<Combate>();

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
        if(collision.gameObject.CompareTag("Player"))
        {
            var enumLength = CofreOpcion.GetNames(typeof(CofreOpcion)).Length;
            int azarNum = Random.Range(0, enumLength);
            switch (azarNum)
            {
                case 0: LaMancha(); break;
                case 1: Enemigo(); break;
                case 2: Item(); break;
                case 3: Debug.Log("Llave"); break;
            }
            MadFix(false);
        }
    }

    void LaMancha()
    {
        Debug.Log("Lleg� la Mancha!!!");
    }

    void Enemigo()
    {
        Debug.Log("Apareci� enemigo");
        combat.StartCombat();
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
