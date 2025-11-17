using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TiltleOption : MonoBehaviour 
{   
    public AudioMixer masterMixer;
    public Slider[] audioSlider;

    private static TiltleOption instance;

    public static TiltleOption Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<TiltleOption>();

            }

            return instance;
        }

    }

    private void Awake()
    {
        if (Instance != this) //오디오 인스턴스가 없을 경우 자신을 인스턴스화 한다
        {
            Destroy(this.gameObject);
        }

        this.gameObject.SetActive(false);
        DontDestroyOnLoad(this.gameObject); //여러씬에 사용할 것이기 때문에 삭제하면 안된다.

        audioSlider[0].value = PlayerPrefs.GetFloat("Master", 0.75f);
        audioSlider[1].value = PlayerPrefs.GetFloat("BGM", 0.75f);
        audioSlider[2].value = PlayerPrefs.GetFloat("SFX", 0.75f);

    }


    public void OnClickOptionButton()
    {
        SoundManager.Instance.PlayerSfxSound("Shot_P");
        Time.timeScale = 0;
        this.gameObject.SetActive(true);

    }

    public void OnClickHomeButton_Option()
    {
        SoundManager.Instance.PlayerSfxSound("Shot_P");
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }

    #region 뮤트
   /* 
    public void SoundOnOff1()
    {
        Time.timeScale = 1;
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0; 

        if(AudioListener.volume == 0)
        {
            soundOff[0].SetActive(true);
            soundOn[0].SetActive(false);
        }

        else
        {
            soundOff[0].SetActive(false);
            soundOn[0].SetActive(true);
        }


    }
    public void SoundOnOff2()
    {
        Time.timeScale = 1;
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;

        if (AudioListener.volume == 0)
        {
            soundOff[1].SetActive(true);
            soundOn[1].SetActive(false);
        }

        else
        {
            soundOff[1].SetActive(false);
            soundOn[1].SetActive(true);
        }


    }
    public void SoundOnOff3()
    {
        Time.timeScale = 1;
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;

        if (AudioListener.volume == 0)
        {
            soundOff[2].SetActive(true);
            soundOn[2].SetActive(false);
        }

        else
        {
            soundOff[2].SetActive(false);
            soundOn[2].SetActive(true);
        }


    }

  */
    #endregion


    public void AudioControlMaster()
    {
        float sound = audioSlider[0].value;

        masterMixer.SetFloat("Master", Mathf.Log10(sound) * 20);
        PlayerPrefs.SetFloat("Master", sound);

    }

    public void AudioControlBGM()
    {
        float sound = audioSlider[1].value;

        masterMixer.SetFloat("BGM", Mathf.Log10(sound) * 20);
        PlayerPrefs.SetFloat("BGM", sound);

    }

    public void AudioControlSFX()
    {
        float sound = audioSlider[2].value;

        PlayerPrefs.SetFloat("SFX", sound);
        masterMixer.SetFloat("SFX", Mathf.Log10(sound) * 20);
        SoundManager.Instance.OptionSfxSound("Shot_P");

    }

}
