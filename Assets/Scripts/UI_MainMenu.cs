using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_MainMenu : MonoBehaviour
{
    public List<GameObject> buttons = new List<GameObject>();
    //public GameObject[] buttons;
    public GameObject howToPlayPanel;
    void Start()
    {
        foreach(var i in buttons)
        {
            i.SetActive(true);
        }

        howToPlayPanel.SetActive(false);
    }

    void OnPlayButtonPressed()
    {
        SceneManager.LoadScene(1);
    }

    void OnHowToPlayButtonPressed() 
    {
        foreach (var i in buttons)
        {
            i.SetActive(false);
        }

        howToPlayPanel.SetActive(true);
    }

    void OnExitButtonPressed()
    {
        Application.Quit();
    }

    void OnBackButtonPressed()
    {
        foreach (var i in buttons)
        {
            i.SetActive(true);
        }

        howToPlayPanel.SetActive(false);
    }
}
