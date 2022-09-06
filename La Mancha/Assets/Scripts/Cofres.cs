using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofres : MonoBehaviour
{
    [Range(0,1)]
    public float spawnProbability;

    public enum CofreOpcion { Mancha, Enemigo, Item, Llave };
    public CofreOpcion[] opciones;

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
            int azarNum = Random.Range(0, opciones.Length);

            switch (opciones[azarNum])
            {
                case CofreOpcion.Mancha: LaMancha(); break;
                case CofreOpcion.Enemigo: Enemigo(); break;
                case CofreOpcion.Item: Item(); break;
                case CofreOpcion.Llave: Debug.Log("Llave"); break;
            }
            MadFix(false);
        }
    }

    void LaMancha()
    {
        Debug.Log("Llegó la Mancha!!!");
    }

    void Enemigo()
    {
        Debug.Log("Apareció enemigo");
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
