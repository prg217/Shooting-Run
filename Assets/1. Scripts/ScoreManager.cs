using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    static public bool chack = false; //스코어 게임 끝날 때 한 번씩만 호출하도록

    private int recentScore;
    static private int[] scores = new int[10];

    [SerializeField]
    private GameObject[] scoreText = new GameObject[10];
    private Text[] text = new Text[10];

    private void Start()
    {
        if (GameManager.CheckActive() == false && chack == true)
        {
            recentScore = GameManager.CheckScore();
            Debug.Log(recentScore);

            for (int i = 0; i < 10; i++)
            {
                text[i] = scoreText[i].GetComponent<Text>();
            }

            RecordScore();
            TextScore();
            chack = false;
        }
        else
        {
            recentScore = 0; //점수 중복 방지

            for (int i = 0; i < 10; i++)
            {
                text[i] = scoreText[i].GetComponent<Text>();
            }

            RecordScore();
            TextScore();
        }
    }

    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //ESC키를 눌렀을 때
        {
            SceneManager.LoadScene("TitleScene"); //타이틀 화면으로 가기
        }
    }

    void RecordScore()
    {
        if (recentScore > scores[0])
        {
            for (int i = 9; i > 0; i--)
            {
                scores[i] = scores[i - 1];
            }
            scores[0] = recentScore;
        }
        else if (recentScore > scores[9])
        {
            for (int i = 9; i > 0; i--)
            {
                scores[i] = recentScore;

                if (recentScore <= scores[i - 1])
                    break;
                scores[i] = scores[i - 1];
            }
        }
    }

    private void TextScore()
    {
        for (int i = 0; i < 10; i++)
        {
            text[i].text = scoreText[i].transform.parent.name + ".   " + scores[i];
        }
    }

    public void ResetScore()
    {
        for (int i = 0; i < 10; i++)
            scores[i] = 0;

        TextScore();
    }
}
