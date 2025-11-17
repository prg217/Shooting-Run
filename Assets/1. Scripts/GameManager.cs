using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static public Transform gameOverUI;
    static public Transform pauseUI;

    static public bool gameActive;
    static public int score;

    private float timeCheck;

    [SerializeField] private Text playerScoreTxt;

    private void Start()
    {
        gameActive = true;
        score = 0;
        gameOverUI = GameObject.Find("Canvas").transform.Find("GameOver"); //게임오버화면 비활성
        pauseUI = GameObject.Find("Canvas").transform.Find("Pause"); //정지화면 비활성

        gameOverUI.gameObject.SetActive(false);
        pauseUI.gameObject.SetActive(false);

       // SoundManager.Instance.PlayerBgmSound();

    }

    // Update is called once per frame
    private void Update()
    {
        PlayerScoreTxt(score);
    }

    static public void GameOver()
    {
        gameOverUI.gameObject.SetActive(true);
        gameActive = false;
    }

    static public bool CheckActive()
    {
        return gameActive;
    }

    static public void GetScore(int num)
    {
        score += num;
        Debug.Log(score);
    }

    static public int CheckScore()
    {
        return score;
    }

    private void PlayerScoreTxt(int score)
    {
        playerScoreTxt.text = "SCORE <color=#00ffff>" + score.ToString("0000") + "</color>";
    }

}
