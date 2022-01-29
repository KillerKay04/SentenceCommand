using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{
    public static Audio instance = null;
    public AudioSource music;
    public AudioSource UIBlip;

    private void Start()
    {
        // Set default prefs
        if (!PlayerPrefs.HasKey("MusicVolume"))
        {
            PlayerPrefs.SetFloat("MusicVolume", 50.0f);
            PlayerPrefs.SetInt("MusicMute", 0);
        }
        if (!PlayerPrefs.HasKey("FXVolume"))
        {
            PlayerPrefs.SetFloat("FXVolume", 50.0f);
            PlayerPrefs.SetInt("FXMute", 0);
        }

        // set music volume according to prefs
        music.volume = PlayerPrefs.GetFloat("MusicVolume") / 100.0f;
        if (PlayerPrefs.GetInt("MusicMute") == 1)
        {
            music.mute = true;
        }
        else
        {
            music.mute = false;
        }

        // set FX volume according to prefs
        UIBlip.volume = PlayerPrefs.GetFloat("FXVolume") / 100.0f;
        if (PlayerPrefs.GetInt("FXVolume") == 1)
        {
            UIBlip.mute = true;
        }
        else
        {
            UIBlip.mute = false;
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

    public void UpdateMusicVolume(float newVol)
    {
        PlayerPrefs.SetFloat("MusicVolume", newVol);
        music.volume = newVol / 100.0f;        
    }

    public void MuteFX()
    {
        int mute = PlayerPrefs.GetInt("FXMute");
        if (mute == 1)
        {
            mute = 0;
            UIBlip.mute = false;
        }
        else
        {
            mute = 1;
            UIBlip.mute = true;
        }
        PlayerPrefs.SetInt("FXMute", mute);
    }

    public void UpdateFXVolume(float newVol)
    {
        PlayerPrefs.SetFloat("FXVolume", newVol);
        UIBlip.volume = newVol / 100.0f;
    }

    public void PlayUIBlip()
    {
        UIBlip.Play();
    }
}
