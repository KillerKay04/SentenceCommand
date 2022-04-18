using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private int currentScore = 0;

    [SerializeField]
    private GameObject userScoreText;

    public void updateScore(float scoreChange) {
        currentScore += (int)scoreChange;
        userScoreText.GetComponent<TMP_Text>().text = currentScore.ToString();
    }
}
