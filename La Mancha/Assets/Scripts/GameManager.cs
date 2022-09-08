using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Character_2 timmy;
    public int maxKeys = 3;
    public int maxMancha = 3;
    public TMP_Text finalText;
    bool ended;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!ended)
        {
            if(timmy.keys >= maxKeys)
            {
                YouWin();
                ended = true;
            }
            if(Character_2.mancha >= maxMancha)
            {
                GameOver();
                ended = true;
            }
            if (Character_2.image.fillAmount <= 0)
            {
                GameOver();
                ended = true;
            }
        }
    }

    public void GameOver()
    {
        finalText.gameObject.SetActive(true);
        finalText.text = "Perdiste";
        StartCoroutine(EndGameCountdown());
    }

    public void YouWin()
    {
        finalText.gameObject.SetActive(true);
        finalText.text = "Ganaste";
        StartCoroutine(EndGameCountdown());
    }

    //Mandar al menu
    void EndGame()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    IEnumerator EndGameCountdown()
    {
        yield return new WaitForSeconds(4);
        EndGame();
    }
}
