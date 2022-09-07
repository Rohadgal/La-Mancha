using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character_2 : MonoBehaviour
{
    public static Image image;
    [SerializeField]
    Image s_image;
    public float life;

    private void Start()
    {
        image = s_image;
        image.fillAmount = 1;
    }
    public static void TakeDamage()
    {
        image.fillAmount -= .333f;
        if(image.fillAmount < .2f)
        {
            image.fillAmount = 0;
        }
    }
}