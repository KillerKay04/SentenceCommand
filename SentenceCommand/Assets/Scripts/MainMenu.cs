using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame () 
    {
        SceneManager.LoadScene("GameScene");
    }

    public void LoadOptions()
    {
        SceneManager.LoadScene("OptionsMenu");
    }

    public void QuitGame ()
    {
        Application.Quit();
    }
}
