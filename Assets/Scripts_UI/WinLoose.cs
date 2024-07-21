using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoose : MonoBehaviour
{
    public UI_GameMenu gameMenu;
    int time;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            //gameLevel = GameLevel.tutorialLevel;
            gameMenu.OnWin(GameLevel.tutorialLevel);
        }

        if (collision.CompareTag("Finish_1"))
        {
            gameMenu.OnWin(GameLevel.levelOne);
        }

    }

}
