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

    void Start()
    {
        timer = time;
        gameMenu = GetComponent<UI_GameMenu>();
    }

    // Update is called once per frame
    void Update()
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
            gameMenu.OnLoose();
        }
        
    }

    void DisplayTimer(int mins, int secs)
    {
        text = string.Format("{0:D2}:{1:D2}", mins, secs);
        timerText.text = text;
    }

   


}
