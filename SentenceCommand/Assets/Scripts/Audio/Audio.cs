using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{
    public static Audio instance = null;
    public AudioSource music;
    public Sprite musicButtonOn;
    public Sprite musicButtonOff;

    private void Start()
    {
        // Set default prefs
        if (!PlayerPrefs.HasKey("MusicVolume") || !PlayerPrefs.HasKey("MusicMute"))
        {
            PlayerPrefs.SetFloat("MusicVolume", 50.0f);
            PlayerPrefs.SetInt("MusicMute", 0);
        }

        // set volume according to prefs
        music.volume = PlayerPrefs.GetFloat("MusicVolume") / 100.0f;
        if (PlayerPrefs.GetInt("MusicMute") == 1)
        {
            music.mute = true;
        }
        else
        {
            music.mute = false;
        }
        
    }

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

    public void MuteMusic()
    {
        int mute = PlayerPrefs.GetInt("MusicMute");
        if (mute == 1)
        {
            mute = 0;
            music.mute = false;
        }
        else
        {
            mute = 1;
            music.mute = true;
        }        
        PlayerPrefs.SetInt("MusicMute", mute);
    }

    public void UpdateVolume(float newVol)
    {
        PlayerPrefs.SetFloat("MusicVolume", newVol);
        music.volume = newVol / 100.0f;        
    }
}
