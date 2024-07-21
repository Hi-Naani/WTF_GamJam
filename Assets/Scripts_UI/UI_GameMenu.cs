using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_GameMenu : MonoBehaviour
{
    public EnumClassGM gameState;
    public GameLevel gameLevel;
    public List<GameObject> panels = new List<GameObject>();
    void Start()
    {
        Time.timeScale = 1.0f;
        foreach (var i in panels)
        {
            i.SetActive(false);
        }
        //panels[0].SetActive(false);
        gameState = EnumClassGM.toPaused;
        gameLevel = GameLevel.tutorialLevel;
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseButtonFunctionality();
        }
    }

    private void PauseButtonFunctionality()
    {
        if(gameState == EnumClassGM.toPaused)
        {
            panels[0].SetActive(true);
            Time.timeScale = 0;
            gameState = EnumClassGM.toPlay;
        }
        else if(gameState == EnumClassGM.toPlay)
        {
            panels[0].SetActive(false);
            Time.timeScale = 1.0f;
            gameState = EnumClassGM.toPaused;
        }
    }

    public void OnRestartButtonPressed()
    {
        
        SceneManager.LoadScene(1);
    }

    public void OnMainMenuButtonPressed()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }
    public void OnNextLevelButtonPressed()
    {
        Time.timeScale = 1.0f;
        //SceneManager.LoadScene(2);
        Debug.Log("You will be directed to next level");
        gameLevel = GameLevel.levelOne;
    }

    public void OnWin(GameLevel gameLevel)
    {
        if (gameLevel.Equals(GameLevel.tutorialLevel))
        {
            Time.timeScale = 0;
            panels[2].SetActive(true);
        }

        if(gameLevel.Equals(GameLevel.levelOne)) 
        {
            Time.timeScale = 0;
            panels[3].SetActive(true);
        }
    }

    public void OnLoose()
    {
        Time.timeScale = 0;
        gameState = EnumClassGM.lost;
        panels[1].SetActive(true);
        
    }
}
