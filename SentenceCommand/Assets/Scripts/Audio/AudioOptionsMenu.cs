using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioOptionsMenu : MonoBehaviour
{
    private int muted = 0;
    private float volume = 50f;

    private void Start()
    {
        // get existing values
        muted = PlayerPrefs.GetInt("MusicMute");
        volume = PlayerPrefs.GetFloat("MusicVolume");
        UpdateUI();
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("MusicMute") != muted || PlayerPrefs.GetFloat("MusicVolume") != volume)
        {
            UpdateUI();
        }
    }

    private void UpdateUI()
    {
        // update toggle
        muted = PlayerPrefs.GetInt("MusicMute");
        if (muted == 1)
        {
            this.gameObject.transform.Find("MusicToggle").GetComponent<Toggle>().SetIsOnWithoutNotify(false);
        }
        else
        {
            this.gameObject.transform.Find("MusicToggle").GetComponent<Toggle>().SetIsOnWithoutNotify(true);
        }

        // update slider
        volume = PlayerPrefs.GetFloat("MusicVolume");
        // test muted
        if (muted == 1)
        {
            // if muted set slider value to 0
            this.gameObject.transform.Find("MusicVolume").GetComponent<Slider>().SetValueWithoutNotify(0);
        }
        else
        {
            this.gameObject.transform.Find("MusicVolume").GetComponent<Slider>().SetValueWithoutNotify(volume);
        }
    }

    public void MuteMusic()
    {
        Audio.instance.MuteMusic();
    }

   
    public void UpdateVolume()
    {
        float newVol;
        newVol = this.gameObject.transform.Find("MusicVolume").GetComponent<Slider>().value;
        Audio.instance.UpdateVolume(newVol);
    }    
}
