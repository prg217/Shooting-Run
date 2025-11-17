using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScoreCode : MonoBehaviour
{
    public Text txtScore;
    private int recentScore;

    void Update()
    {
        recentScore = GameManager.CheckScore();
        Score();
    }

    public void Score()
    {
        txtScore.text = "SCORE <color=#ff0000>" + recentScore.ToString() + "</color>";
    }

    private void PlayerState()
    {

    }
}
