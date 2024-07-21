using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    string text;
    public const int time = 301;
    float timer;

    void Start()
    {
        timer = time;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        int mins = (int)timer / 60;
        int secs = (int)timer % 60;
        DisplayTimer(mins, secs);
    }

    void DisplayTimer(int mins, int secs)
    {
        text = string.Format("{0:D2}:{1:D2}", mins, secs);
        timerText.text = text;
    }
}
