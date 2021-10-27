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
}
