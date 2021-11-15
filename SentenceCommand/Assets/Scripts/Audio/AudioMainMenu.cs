using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioMainMenu : MonoBehaviour
{
    public Sprite musicMuteSprite;
    public Sprite musicOnSprite;
    private int muted = 0;

    void Start()
    {
        // get existing values
        muted = PlayerPrefs.GetInt("MusicMute");
        UpdateSprites();
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("MusicMute") != muted)
        {
            UpdateSprites();
        }
    }

    public void MuteMusic()
    {
        Audio.instance.MuteMusic();
    }

    public void PlayUIBlip()
    {
        Audio.instance.PlayUIBlip();
    }

    private void UpdateSprites()
    {
        muted = PlayerPrefs.GetInt("MusicMute");
        // check player prefs
        if (muted == 1)
        {
            // set sprite to muted
            this.gameObject.transform.Find("Sound").GetComponent<Image>().sprite = musicMuteSprite;         
        }
        else
        {
            // set sprite to notMuted
            this.gameObject.transform.Find("Sound").GetComponent<Image>().sprite = musicOnSprite;
        }
    }
}
