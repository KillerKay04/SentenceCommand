using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private Audio myAudio;
    public Button musicToggleButton;
    public Sprite musicOnSprite;
    public Sprite musicOffSprite;

    private void Start()
    {
        myAudio = GameObject.FindObjectOfType<Audio>();
       // PlayerPrefs.SetFloat("PlayVolume", 1.0f);
        //PlayerPrefs.SetFloat("SaveVolume", 1.0f);
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

    void updateVolume()
    {
        // if our volumePref is set to 0 set volume to 0 and update sprite
        if(PlayerPrefs.GetFloat("PlayVolume", 1.0f) == 0f)
        {
            AudioListener.volume = 0.0f;
            musicToggleButton.GetComponent<Image>().sprite = musicOffSprite;
        }
        // else, update volume to volumePref and update sprite
        else
        {
            AudioListener.volume = PlayerPrefs.GetFloat("PlayVolume");
            musicToggleButton.GetComponent<Image>().sprite = musicOnSprite;
        }
    }
}
