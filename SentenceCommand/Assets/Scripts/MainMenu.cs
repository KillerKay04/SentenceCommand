using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Start()
    {
        StartCoroutine(getRequest("https://mfpd1xxqx7.execute-api.us-east-2.amazonaws.com//QA/QA/Search?category=reading"));
    }

    IEnumerator getRequest(string uri)
    {
        UnityWebRequest uwr = UnityWebRequest.Get(uri);
        yield return uwr.SendWebRequest();

        if (uwr.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            // Debug.Log("Received: " + uwr.downloadHandler.text);
            GlobalVars.json = uwr.downloadHandler.text;
        }
    }

    public void PlayGame ()   //Loads GameScene scene
    {
        SceneManager.LoadScene("GameScene");
    }

    public void LoadOptions()   //Loads OptionsMenu scene
    {
        SceneManager.LoadScene("OptionsMenu");
    }

    public void LoadLeaderboards()   //Loads LeaderboardsScene scene
    {
        SceneManager.LoadScene("Leaderboards");
    }

    public void QuitGame ()  //Quits application
    {
        Application.Quit();
    }
}
