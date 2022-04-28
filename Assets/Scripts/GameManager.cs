using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static bool gameIsOver = false;

    

   public GameObject gameOverUI;

   public GameObject LevelWonui;

   


    void Start ()
    {
        gameIsOver = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(gameIsOver)
        {
            PlayerStats.Lives = 0;
            return;
        }

        

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame ()
    {
        gameIsOver = true;
        gameOverUI.SetActive(true);

    }


   public void WinLevel ()
    {
LevelWonui.SetActive(true);
    }
}
