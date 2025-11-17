using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniPause : MonoBehaviour
{
    private bool isPause;

    private void Start()
    {
        isPause = false;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //ESC키를 눌렀을 때
        {
            if (!isPause) //일시정지 활성화
            {
                MiniGameManager.pauseUI.gameObject.SetActive(true);
                Time.timeScale = 0;
                isPause = true;
                return;
            }

            if (isPause) //일시정지 비활성화
            {
                MiniGameManager.pauseUI.gameObject.SetActive(false);
                Time.timeScale = 1;
                isPause = false;
                return;
            }
        }
    }

    public void OnClickBackButton() //Pause의뒤로가기 버튼
    {
        if (isPause) //일시정지 비활성화
        {
            SoundManager.Instance.PlayerSfxSound("Shot_P");
            MiniGameManager.pauseUI.gameObject.SetActive(false);
            Time.timeScale = 1;
            isPause = false;
            //return;
        }
    }
}
