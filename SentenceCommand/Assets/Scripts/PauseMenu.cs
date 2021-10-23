using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = true;
    public GameObject PauseMenuUI;
    public GameObject MainUI;

    private void Start()
    {
        Time.timeScale = 1.0f;
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        MainUI.SetActive(true);
        Time.timeScale = 1.0f;
    }

    public void Pause()
    {
        MainUI.SetActive(false);
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }
}
