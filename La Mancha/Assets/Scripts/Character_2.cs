using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Character_2 : MonoBehaviour
{
    public static Image image;
    public TMP_Text textKeys;
    public TMP_Text textManchas;
    [SerializeField]
    Image s_image;
    public float life;
    public int keys;
    public static int mancha;

    private void Start()
    {
        image = s_image;
        image.fillAmount = 1;

        textKeys.text = "x " + keys.ToString();
        textManchas.text = "x " + mancha.ToString();
    }
    public static void TakeDamage()
    {
        image.fillAmount -= .333f;
        if(image.fillAmount < .1f)
        {
            image.fillAmount = 0;
        }
    }

    public static void Heal()
    {
        image.fillAmount += .333f/2;
    }
}