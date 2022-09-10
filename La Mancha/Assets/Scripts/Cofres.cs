using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofres : MonoBehaviour
{
    [Range(0,1)]
    public float spawnProbability;
    public Character_2 timmy;

    public enum CofreOpcion { Mancha, Enemigo, Item, Llave };
    public CofreOpcion[] opciones;

    public GameObject blackTimmy;

    Combate combat;

    //public AudioSource timmyAudio;
    //public AudioClip timmyAudioClip;
 

    private void Start()
    {
        combat = GameObject.Find("CombatManager").GetComponent<Combate>();

        if (Random.value <= spawnProbability)
        {
            MadFix(false);
        }
        else
        {
            MadFix(true);
        }

        //timmyAudio = blackTimmy.GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            timmy = collision.gameObject.GetComponent<Character_2>();
            PlayerMovementOnClick.LookAtTarget(gameObject.transform);
            int azarNum = Random.Range(0, opciones.Length);

            switch (opciones[azarNum])
            {
                case CofreOpcion.Mancha: LaMancha(); break;
                case CofreOpcion.Enemigo: Enemigo(); break;
                case CofreOpcion.Item: Item(); break;
                case CofreOpcion.Llave: Llave(); break;
            }
            MadFix(false);
        }
    }

    void LaMancha()
    {
        Character_2.mancha++;
        ActualizarManchaTexto();
        StartCoroutine(TimeBlackTimmy());
    }

    void Enemigo()
    {
        FindObjectOfType<AudioManager>().Play("Enemy");
        combat.StartCombat();
    }

    void Item()
    {
        Character_2.Heal();
        FindObjectOfType<AudioManager>().Play("Item");
    }

    void MadFix(bool estado)
    {
        gameObject.GetComponent<MeshRenderer>().enabled = estado;
        gameObject.GetComponent<Collider>().enabled = estado;
    }

    IEnumerator TimeBlackTimmy()
    {
        yield return new WaitForSeconds(1f);
        GameObject tempTimmy = Instantiate(blackTimmy, gameObject.transform.position, Quaternion.identity);
        //timmyAudio.PlayOneShot(timmyAudioClip);
        yield return new WaitForSeconds(4f);
        Destroy(tempTimmy);
    }

    void ActualizarManchaTexto()
    {
        timmy.textManchas.text = Character_2.mancha.ToString();
    }

    void ActualizarLlaveTexto()
    {
        timmy.textKeys.text = timmy.keys.ToString();
    }

    void Llave()
    {
        timmy.keys++;
        ActualizarLlaveTexto();
        FindObjectOfType<AudioManager>().Play("Key");
    }
}
