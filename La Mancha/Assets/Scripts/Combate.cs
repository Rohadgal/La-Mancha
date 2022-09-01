using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combate : MonoBehaviour
{
    [SerializeField]
    Image[] targets;

    int randomTarget;
    int counterHit;
    int counterMiss;

    public GameObject canvasBackground;

    public float timeLimit = 1.3f;
    float timer;

    bool contando = false;

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
    }

    public void StartCombat()
    {
        PlayerMovementOnClick.TurnCameraOnOff(true);
        canvasBackground.SetActive(true);
        contando = true;
        counterHit = 0;
        counterMiss = 0;
        timer = 0;
        CombatMethod();
    }
    
}
