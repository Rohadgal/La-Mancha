using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Combate : MonoBehaviour
{
    [SerializeField]
    Image[] targets;

    int randomTarget;
    int counterHit;
    int counterMiss;

    public GameObject canvasBackground;
    public TMP_Text contadorTexto;
    public float cuentaRegresiva = 3;
    float cuentaRegresivaContador;
    bool contandoRegresivamente;

    public float timeLimit = 1.3f;
    float timer;

    bool contando = false;

    public static bool enCombate;

    private void Start()
    {
        enCombate = false;
    }

    private void Update()
    {
        if(contando)
        {
            timer += Time.deltaTime;
            if(timer > timeLimit)
            {
                counterMiss++;
                timer = 0;
                CombatMethod();
            }
        }

        if (contandoRegresivamente)
        {
            cuentaRegresivaContador -= Time.deltaTime;
            contadorTexto.text = Mathf.FloorToInt(cuentaRegresivaContador).ToString();
            if(cuentaRegresivaContador < 0)
            {
                contandoRegresivamente = false;
                contando = true;
                contadorTexto.gameObject.SetActive(false);
                CombatMethod();
            }
        }
    }

    void CombatMethod()
    {
        if(counterMiss < 3)
        {
            Debug.Log("Missed target" + "counter missed: " + counterMiss); 

            foreach (Image target in targets)
            {
                target.gameObject.SetActive(false);
            }
            randomTarget = Random.Range(0, targets.Length);

            targets[randomTarget].gameObject.SetActive(true);
        }
        else
        {
            // hacer daño al player
            FinishCombat();
        }
    }

    public void DestroyTarget()
    {
        timer = 0;
        Debug.Log("Función Destroy Target");
        if (counterHit < 3)
        {
            targets[randomTarget].gameObject.SetActive(false);
            counterHit++;
            CombatMethod();
        }
        else FinishCombat();
    }

    public void FinishCombat()
    {
        PlayerMovementOnClick.TurnCameraOnOff(false);
        canvasBackground.SetActive(false);
        contando = false;
        enCombate = false;
        CheckWinner();
    }

    public void StartCombat()
    {
        enCombate = true;
        PlayerMovementOnClick.TurnCameraOnOff(true);
        canvasBackground.SetActive(true);

        foreach (Image target in targets)
        {
            target.gameObject.SetActive(false);
        }

        contadorTexto.gameObject.SetActive(true);
        contandoRegresivamente = true;
        cuentaRegresivaContador = cuentaRegresiva;
        counterHit = 0;
        counterMiss = 0;
        timer = 0;        
    }

    public void CheckWinner()
    {
        if(counterMiss>counterHit)
        {
            Character_2.TakeDamage();
        }
    }
}
