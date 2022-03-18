using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioGameScene : MonoBehaviour
{
    public AudioSource baseDamaged;
    public AudioSource baseDestroyed;
    public AudioSource UFOSpawn;
    public AudioSource UFOHit;
    public AudioSource answerCorrect;
    public AudioSource answerWrong;
    public AudioSource fireMissile;

    private void Start()
    {
        // set sound FX volumes
        float vol = PlayerPrefs.GetFloat("FXVolume");
        vol = vol / 100.0f;
        baseDamaged.volume = vol;
        baseDestroyed.volume = vol;
        UFOSpawn.volume = vol;
        UFOHit.volume = vol;
        answerCorrect.volume = vol;
        answerWrong.volume = vol;
        fireMissile.volume = vol;
    }

    public void PlayUIBlip()
    {
        Audio.instance.PlayUIBlip();
    }

    public void PlayBaseDamaged()
    {
        baseDamaged.Play();
    }

    public void PlayBaseDestroyed()
    {
        baseDestroyed.Play();
    }
    
    public void PlayUFOSpawn()
    {
        UFOSpawn.Play();
    }

    public void PlayUFOHit()
    {
        UFOHit.Play();
    }

    public void PlayAnswerCorrect()
    {
        answerCorrect.Play();
    }

    public void PlayAnswerWrong()
    {
        answerWrong.Play();
    }

    public void PlayFireMissile()
    {
        fireMissile.Play();
    }
}
