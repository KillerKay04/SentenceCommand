using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 120;
    public bool timerRunning = true;
    public GameObject EndGameUI;

    [SerializeField]
    private GameObject timerText;

    public void Start() {
        timeRemaining = GlobalVars.gameTime;
    }

    // Update is called once per frame
    public void Update()
    {
        if (timerRunning)
        {
            if (timeRemaining > 0)
            {
                // Time.deltaTime measures the time between the last update() call and this one
                timeRemaining -= Time.deltaTime;
                timerText.GetComponent<TMP_Text>().text = UpdateTime();
            }
            else
            {
                // Stop timer, so that the end condition only occurs once
                timerRunning = false;                
                // set time to 0, because this timer format isn't perfect and will overrun into negatives
                timeRemaining = 0;
                endGame();
            }
        }        
    }

    // Returns a string representation of the timer in the format: MM:SS
    public string UpdateTime()
    {
        float minutes = Mathf.FloorToInt(timeRemaining / 60);
        float seconds = Mathf.FloorToInt(timeRemaining % 60);
        string secondsFormatted = seconds.ToString();
        if (seconds < 10) {
            secondsFormatted = "0" + secondsFormatted;
        }
        return minutes.ToString() + ":" + secondsFormatted;
    }

    // This method is called when the timer runs down to 0
    public void endGame()
    {        
        EndGameUI.GetComponent<EndGameMenu>().endGame();        
    }
}
