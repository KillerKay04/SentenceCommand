using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public void LoadMenu()      //loads main menu
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void SetOneMinute() {
        GlobalVars.gameTime = 60;
    }

    public void SetTwoMinutes() {
        GlobalVars.gameTime = 120;
    }

    public void SetFiveMinutes() {
        GlobalVars.gameTime = 300;
    }
}
