using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public GameObject outlineMesh;

    private void Start()
    {
        outlineMesh.SetActive(false);
    }

    private void OnMouseOver()
    {
        //Debug.Log("mouse encima");
        outlineMesh.SetActive(true);   
    }

    private void OnMouseExit()
    {
        //Debug.Log("Mouse Fuera");
        outlineMesh.SetActive(false);
    }
}
