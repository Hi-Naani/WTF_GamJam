using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoose : MonoBehaviour
{
    public UI_GameMenu gameMenu;
    public UI_LevelTwo levelTwo;
    public GameLevel gameLevel;
    int time;

    private void Start()
    {
        if (gameLevel == GameLevel.tutorialLevel)
        {
            gameMenu = GameObject.Find("GameScene_UI/UIManagerGS").GetComponent<UI_GameMenu>();
            levelTwo = null;
        }
        else if (gameLevel == GameLevel.levelOne)
        {
            levelTwo = GameObject.Find("LevelTwo_UI/UIManagerLT").GetComponent<UI_LevelTwo>();
            gameMenu = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            gameMenu.OnWin();
        }

        if (collision.CompareTag("Finish_1"))
        {
            levelTwo.OnWin();
        }

    }

}
