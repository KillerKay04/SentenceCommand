using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsAudioManager : MonoBehaviour
{
    private Audio myAudio;
    public Toggle musicToggle;
    public Slider musicSlider;

    private void Start()
    {
        myAudio = GameObject.FindObjectOfType<Audio>();
        updateVolume();
    }

    private void Update()
    {

    }

    public void PauseMusic()
    {
        myAudio.toggleSound();
        updateVolume();
    }
    public void changeVolume()
    {       
        float vol = musicSlider.value / 100f;
        myAudio.updateSound(vol);
        updateVolume();
    }

    void updateVolume()
    {
        // update volume
        AudioListener.volume = PlayerPrefs.GetFloat("PlayVolume", 1.0f);

        // update slider
        musicSlider.SetValueWithoutNotify(PlayerPrefs.GetFloat("PlayVolume") * 100);

        // update toggle
        if (PlayerPrefs.GetFloat("PlayVolume") == 0f)
        {
            musicToggle.GetComponent<Toggle>().isOn = false;
        }
        // else, update volume to volumePref and update sprite
        else
        {            
            musicToggle.GetComponent<Toggle>().isOn = true;
        }
    }    
}
