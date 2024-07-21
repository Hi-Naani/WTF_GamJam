using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_MainMenu : MonoBehaviour
{
    public List<GameObject> buttons = new List<GameObject>();
    public GameObject howToPlayPanel;
    public bool enteredHowToPlayMenu;
    void Start()
    {
        foreach(var i in buttons)
        {
            i.SetActive(true);
        }

        howToPlayPanel.SetActive(false);
        enteredHowToPlayMenu = false;
    }

    void Update()
    {
        if(enteredHowToPlayMenu)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                foreach (var i in buttons)
                {
                    i.SetActive(true);
                }

                howToPlayPanel.SetActive(false);
                enteredHowToPlayMenu = false;
            }
        }   
    }

    public void OnPlayButtonPressed()
    {
        SceneManager.LoadScene(1);
    }

    public void OnHowToPlayButtonPressed() 
    {
        foreach (var i in buttons)
        {
            i.SetActive(false);
        }
        enteredHowToPlayMenu = true;

        howToPlayPanel.SetActive(true);
    }

    public void OnExitButtonPressed()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void OnBackButtonPressed()
    {
        foreach (var i in buttons)
        {
            i.SetActive(true);
        }

        howToPlayPanel.SetActive(false);
    }

}
