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
}
