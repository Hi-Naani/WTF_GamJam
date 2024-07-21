using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_GameMenu : MonoBehaviour
{
    public EnumClassGM gameState;
    public GameLevel gameLevel;
    public List<GameObject> panels = new List<GameObject>();
    public SpawningStars spawningStars;
    public Timer timer;

    private void Awake()
    {
        gameLevel = GameLevel.tutorialLevel;
    }
    void Start()
    {
        Time.timeScale = 1.0f;
        foreach (var i in panels)
        {
            i.SetActive(false);
        }

        gameState = EnumClassGM.toPaused;
        GameObject.Find("Vehicle_Final").GetComponent<DriveCar>().enabled = true;
        spawningStars = this.GetComponent<SpawningStars>();
        timer = this.GetComponent<Timer>();
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
        Debug.Log(gameObject.scene.name);

    }

    public void OnMainMenuButtonPressed()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }
    public void OnNextLevelButtonPressed()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(2);
        gameLevel = GameLevel.levelOne;
        Debug.Log(gameLevel);
        
    }

    public void OnWin()
    {
        GameObject.Find("Vehicle_Final").GetComponent<DriveCar>().enabled = false;
        timer.restrictTimer = true;
        panels[2].SetActive(true);
        spawningStars.CallinMethodForStars();
    }

    public void OnLoose()
    {
        Time.timeScale = 0;
        gameState = EnumClassGM.lost;
        panels[1].SetActive(true);
        
    }
}
