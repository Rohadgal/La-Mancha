using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptParaBorrar : MonoBehaviour
{
    public GameObject[] puertas;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i<puertas.Length; i++)
        {
            //Debug.Log(puertas[i].name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
