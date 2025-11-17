using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameManager : MonoBehaviour
{
    static public Transform gameOverUI;
    static public Transform pauseUI;
    // Start is called before the first frame update
    void Start()
    {
        gameOverUI = GameObject.Find("Canvas").transform.Find("GameOver"); //게임오버화면 비활성
        pauseUI = GameObject.Find("Canvas").transform.Find("Pause"); //정지화면 비활성

        gameOverUI.gameObject.SetActive(false);
        pauseUI.gameObject.SetActive(false);

       // SoundManager.Instance.PlayerBgmSound();
    }
    static public void GameOver()
    {
        Time.timeScale = 0;
        gameOverUI.gameObject.SetActive(true);
    }
}
