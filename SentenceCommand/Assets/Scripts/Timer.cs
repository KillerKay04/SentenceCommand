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

    // Update is called once per frame
    public void Update()
    {
        if (timerRunning)
        {
            if (timeRemaining > 0)
            {
                // Time.deltaTime measures the time between the last update() call and this one
                timeRemaining -= Time.deltaTime;
                // Debug.Log(timeRemaining);
            }
            else
            {
                // Stop timer, so that the end condition only occurs once
                timerRunning = false;                
                // set time to 0, because this timer format isn't perfect and will overrun into negatives
                timeRemaining = 0;
                endGame();
            }

            timerText.GetComponent<TMP_Text>().text = UpdateTime();
        }        
    }

    // Returns a string representation of the timer in the format: MM:SS
    public string UpdateTime()
    {
        float minutes = Mathf.FloorToInt(timeRemaining / 60);
        float seconds = Mathf.FloorToInt(timeRemaining % 60);
        return minutes.ToString() + ":" + seconds.ToString();
    }

    // This method is called when the timer runs down to 0
    public void endGame()
    {        
        EndGameUI.GetComponent<EndGameMenu>().endGame();        
    }
}
