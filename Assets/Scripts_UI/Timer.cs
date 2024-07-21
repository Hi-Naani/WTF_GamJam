using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    string text;
    public int time = 301;
    [HideInInspector] public float timer;
    public UI_GameMenu gameMenu;
    public UI_LevelTwo levelTwo;
    public GameLevel gameLevel;
    public bool restrictTimer;

    void Start()
    {
        restrictTimer = false;
        timer = time;
        if (gameLevel == GameLevel.tutorialLevel)
        {
            gameMenu = GetComponent<UI_GameMenu>();
            levelTwo = null;
            Debug.Log("Hi");
        }
        else if(gameLevel == GameLevel.levelOne)
        {
            levelTwo = GetComponent<UI_LevelTwo>();
            gameMenu = null;
            Debug.Log("Hello");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!restrictTimer)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                int mins = (int)timer / 60;
                int secs = (int)timer % 60;
                DisplayTimer(mins, secs);
            }
            else
            {
                if (gameLevel == GameLevel.tutorialLevel)
                {
                    gameMenu.OnLoose();
                }
                else if (gameLevel == GameLevel.levelOne)
                {
                    levelTwo.OnLoose();
                }

            }
        }
        
        
    }

    void DisplayTimer(int mins, int secs)
    {
        text = string.Format("{0:D2}:{1:D2}", mins, secs);
        timerText.text = text;
    }

   


}
