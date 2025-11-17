using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    //타이틀에서 시작하지 않고 다른 씬에서 시작하면 오류남
    //무조건 타이틀씬에서 시작할 것

    private void Start()
    {
        SoundManager.Instance.PlayerBgmSound();
    }


    public void OnClickResetButton()
    {
        GameObject.Find("Ranks").GetComponent<ScoreManager>().ResetScore();
        SoundManager.Instance.PlayerSfxSound("Shot_P");
    }
    static public void OnClickStartButton()
    {
       // Time.timeScale = 1;
        SoundManager.Instance.PlayerSfxSound("Shot_P");
        SceneManager.LoadScene("Main");

    }

    static public void OnClickScoreButton()
    {
        //Time.timeScale = 1;
        SoundManager.Instance.PlayerSfxSound("Shot_P");
        SceneManager.LoadScene("ScoreBoard");
    }
    public void OnClickMiniButton()
    {
        // Time.timeScale = 1;
        SoundManager.Instance.PlayerSfxSound("Shot_P");
        SceneManager.LoadScene("MiniGame");
    }
/*

    public void OnClickHomeButton()
    {
        SoundManager.Instance.PlayerSfxSound("Shot_P");
        Time.timeScale = 1;
    }

 */
    public void OnClickHomeButton()
    {
        Time.timeScale = 1;
        SoundManager.Instance.PlayerSfxSound("Shot_P");
        SceneManager.LoadScene("TitleScene");
        Debug.Log(Time.timeScale);
    }

    public void OnClickSkinButton()
    {
        // Time.timeScale = 1;
        SoundManager.Instance.PlayerSfxSound("Shot_P");
        SceneManager.LoadScene("Skin");
        //SoundManager.Instance.PlayerBgmSound();
    }


    public void OnClickOptionButton1()
    {
        //이 코드가 오류났을 시 필시 타이틀 씬의 하이어라키에 옵션캔버스를 꺼놓은 것이다 무조건 켜둘것
        SoundManager.Instance.PlayerSfxSound("Shot_P");
        TiltleOption.Instance.OnClickOptionButton();
    }

    public void OnClickGameExit()
    {      
        SoundManager.Instance.PlayerSfxSound("Shot_P");
        Application.Quit();
    }




}
