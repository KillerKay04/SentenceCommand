using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    static Audio instance = null;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    public void toggleSound()
    {
        // if our current volumePref is 0, change to SaveVolume
        if (PlayerPrefs.GetFloat("PlayVolume") == 0f)
        {
            PlayerPrefs.SetFloat("PlayVolume", PlayerPrefs.GetFloat("SaveVolume", 1.0f));
        }
        // else, save currentVolume out, then set volume to 0
        else
        {
            PlayerPrefs.SetFloat("SaveVolume", PlayerPrefs.GetFloat("PlayVolume", 1.0f));
            PlayerPrefs.SetFloat("PlayVolume", 0f);
        }
    }
    public void updateSound(float volume)
    {
        // update our saved volume setting        
        // if our current volume setting isn't 0, update volume
        // this prevents a overflow bug when volume goes to 0
        if (volume != 0f)
        {
            PlayerPrefs.SetFloat("SaveVolume", volume);
            PlayerPrefs.SetFloat("PlayVolume", volume);
        }                
    }
}
