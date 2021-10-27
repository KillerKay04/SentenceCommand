using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = true;
    public GameObject PauseMenuUI;
    public GameObject MainUI;

    private void Awake()        //timescale set to 1f so game is running at start
    {
        Time.timeScale = 1.0f;
    }

    public void Resume()        //swaps the activiy of the PauseMenu and MainUI and returns timescale to 1f so game runs again
    {
        PauseMenuUI.SetActive(false);
        MainUI.SetActive(true);
        Time.timeScale = 1.0f;
    }

    public void Pause()     //swaps the activiy of the PauseMenu and MainUI and sets timescale to 0f so game is paused
    {
        MainUI.SetActive(false);
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void QuitGame()      //Quits application
    {
        Application.Quit();
    }

    public void LoadMenu()      //returns timescale to 1.0 for menu animations and loads main menu
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }
}
