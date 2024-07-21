using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_GameMenu : MonoBehaviour
{
    public EnumClassGM gameState;
    public List<GameObject> panels = new List<GameObject>();
    void Start()
    {
        panels[0].SetActive(false);
        gameState = EnumClassGM.toPaused;
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
}
