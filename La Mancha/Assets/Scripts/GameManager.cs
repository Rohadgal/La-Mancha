using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Character_2 timmy;
    public int maxKeys = 3;
    public int maxMancha = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timmy.keys >= maxKeys)
        {
            YouWin();
        }
        if(Character_2.mancha >= maxMancha)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        Debug.Log("GAME OVER");
    }

    public void YouWin()
    {
        Debug.Log("YOU WIN");
    }
}
