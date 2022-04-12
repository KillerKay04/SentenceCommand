using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameMenu : MonoBehaviour
{

    public GameObject EndGameUI;
    public GameObject MainUI;

    // Reference to the object that holds the current score
    public GameObject Score;

    // Restarts the game, by reloading the GameScene
    // sets time scale to 1 for normal time.
    public void RestartGame()
    {
        EndGameUI.SetActive(false);
        MainUI.SetActive(true);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("GameScene");
    }

    // Ends the game by pulling up the EndGameUI menu and hiding the main UI
    public void endGame()
    {

        // Retrieve Score
        string score = Score.GetComponent<TMP_Text>().text;

        // Update Score
        EndGameUI.transform
            .Find("UserScoreFinal")
            .Find("ScoreText")
            .GetComponent<TMP_Text>().text = score;

        // Update Right
        EndGameUI.transform
            .Find("QuestionsRight")
            .Find("QuestionsRightText")
            .GetComponent<TMP_Text>().text = GlobalVars.questionsRight.ToString();

        // Update Wrong
        EndGameUI.transform
            .Find("QuestionsWrong")
            .Find("QuestionsWrongText")
            .GetComponent<TMP_Text>().text = GlobalVars.questionsWrong.ToString();


        MainUI.SetActive(false);
        EndGameUI.SetActive(true);
        Time.timeScale = 0f;
        updateScores(score);
    }

    private void updateScores(string scoreToAdd)
    {
        // get leaderboard scores from playerPrefs
        string scoreString = PlayerPrefs.GetString("Scores");
       

        // check to see if scores exist
        if (scoreString.Equals(""))
        {
            // add current score to scoreString
            scoreString = scoreToAdd;
        }
        else
        {
            // add a comma delimiter between
            scoreString = scoreString + "," + scoreToAdd;
        }

        // set score back in playerprefs
        PlayerPrefs.SetString("Scores", scoreString);
    }
}
