using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame ()   //Loads GameScene scene
    {
        SceneManager.LoadScene("GameScene");
    }

    public void LoadOptions()   //Loads OptionsMenu scene
    {
        SceneManager.LoadScene("OptionsMenu");
    }

    public void QuitGame ()  //Quits application
    {
        Application.Quit();
    }
}
