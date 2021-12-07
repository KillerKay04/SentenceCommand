using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioOptionsMenu : MonoBehaviour
{
    private int musicMuted = 0;
    private float musicVolume = 50f;
    private int FXMuted = 0;
    private float FXVolume = 50f;

    private void Start()
    {
        // get existing values
        musicMuted = PlayerPrefs.GetInt("MusicMute");
        musicVolume = PlayerPrefs.GetFloat("MusicVolume");
        FXMuted = PlayerPrefs.GetInt("FXMute");
        FXVolume = PlayerPrefs.GetFloat("FXVolume");
        UpdateUI();
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("MusicMute") != musicMuted || PlayerPrefs.GetFloat("MusicVolume") != musicVolume)
        {
            UpdateUI();
        }
        if (PlayerPrefs.GetInt("FXMute") != FXMuted || PlayerPrefs.GetFloat("FXVolume") != FXVolume)
        {
            UpdateUI();
        }
    }

    private void UpdateUI()
    {

        // Music Controls
        #region Music Controls
        // update toggle
        musicMuted = PlayerPrefs.GetInt("MusicMute");
        if (musicMuted == 1)
        {
            GameObject.Find("MusicToggle").GetComponent<Toggle>().SetIsOnWithoutNotify(false);
        }
        else
        {
            GameObject.Find("MusicToggle").GetComponent<Toggle>().SetIsOnWithoutNotify(true);
        }

        // update slider
        musicVolume = PlayerPrefs.GetFloat("MusicVolume");
        // test muted
        if (musicMuted == 1)
        {
            // if muted set slider value to 0
            GameObject.Find("MusicVolume").GetComponent<Slider>().SetValueWithoutNotify(0);
        }
        else
        {
            GameObject.Find("MusicVolume").GetComponent<Slider>().SetValueWithoutNotify(musicVolume);
        }
        #endregion

        // FX Controls
        #region FX Controls
        // update toggle
        FXMuted = PlayerPrefs.GetInt("FXMute");
        if (FXMuted == 1)
        {
            GameObject.Find("EffectsToggle").GetComponent<Toggle>().SetIsOnWithoutNotify(false);
        }
        else
        {
            GameObject.Find("EffectsToggle").GetComponent<Toggle>().SetIsOnWithoutNotify(true);
        }

        // update slider
        FXVolume = PlayerPrefs.GetFloat("FXVolume");
        // test muted
        if (FXMuted == 1)
        {
            // if muted set slider value to 0
            GameObject.Find("EffectsVolume").GetComponent<Slider>().SetValueWithoutNotify(0);
        }
        else
        {
            GameObject.Find("EffectsVolume").GetComponent<Slider>().SetValueWithoutNotify(FXVolume);
        }
        #endregion
    }

    public void MuteMusic()
    {
        Audio.instance.MuteMusic();
    }

   
    public void UpdateMusicVolume()
    {
        float newVol;
        newVol = this.gameObject.transform.Find("MusicVolume").GetComponent<Slider>().value;
        Audio.instance.UpdateMusicVolume(newVol);
    }    

    public void MuteFX()
    {
        Audio.instance.MuteFX();
    }

    public void UpdateFXVolume()
    {
        float newVol;
        newVol = this.gameObject.transform.Find("EffectsVolume").GetComponent<Slider>().value;
        Audio.instance.UpdateFXVolume(newVol);
    }

    public void PlayUIBlip()
    {
        Audio.instance.PlayUIBlip();
    }
}
