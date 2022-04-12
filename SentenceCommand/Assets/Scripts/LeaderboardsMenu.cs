using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaderboardsMenu : MonoBehaviour
{
    GameObject scores;
    GameObject noScores;

    public void Start()
    {
        // bind game objects
        scores = GameObject.Find("LeaderboardsUI").transform.Find("Scores").gameObject;
        noScores = GameObject.Find("LeaderboardsUI").transform.Find("NoScores").gameObject;


        // get leaderboard scores from playerPrefs
        string scoreString = PlayerPrefs.GetString("Scores");

        // check to see if score exists
        if (scoreString.Equals(""))
        {
            // score doesn't exist, display scores message         
            scores.SetActive(false);
            noScores.SetActive(true);
        }
        else
        {
            // hide no scores, and show scores
            scores.SetActive(true);
            noScores.SetActive(false);

            // split string into scores
            string[] scoresArray = scoreString.Split(',');

            // convert strings to ints
            List<int> iScores = new List<int>();
            foreach (string s in scoresArray)
            {
                iScores.Add(int.Parse(s));
            }

            // sort score list
            iScores.Sort();

            // trim to top ten
            if (iScores.Count > 10)
            {
                iScores.RemoveRange(10, iScores.Count - 10);
            }

            // update playerPrefs
            StringBuilder updatedScores = new StringBuilder();
            foreach (int s in iScores)
            {
                updatedScores.Append(s);
                updatedScores.Append(",");
            }
            updatedScores.Remove(updatedScores.Length - 1, 1);
            PlayerPrefs.SetString("Scores", updatedScores.ToString());

            // declare display string
            StringBuilder displayString = new StringBuilder();

            // build display string
            for (int i = 0; i < iScores.Count; i++)
            {
                // print i + 1 for rank
                displayString.Append(i + 1);

                // Append ST
                if (i == 0) { displayString.Append("ST"); }
                // Append ND
                else if (i == 1) { displayString.Append("ND"); }
                // Append RD
                else if (i == 2) { displayString.Append("RD"); }
                // Append TH
                else { displayString.Append("TH"); }

                // if 10th score only append 2x \t
                if (i == 9) { displayString.Append("\t\t"); }
                // else append 3x \t
                else { displayString.Append("\t\t\t"); }

                // append score
                displayString.Append(iScores[i]);

                // append \n
                displayString.Append("\n");
            }

            // set score string
            GameObject.Find("Scores").transform.GetComponent<TMP_Text>().text = displayString.ToString();            
        }      
    }


    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PlayUIBlip()
    {
        Audio.instance.PlayUIBlip();
    }
}
