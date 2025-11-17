using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{

    //어디서나 접근할 수 있는 정적 변수
    private static SoundManager instance;

    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SoundManager>();
                
            }

            return instance;
        }

    }

    private int flags = 0;
    private AudioSource bgmPlayer;
    private AudioSource sfxPlayer;

    public float masterVolumeBgm = 1f;
    public float masterVolumeSfx = 1f;

    //여러가지 배경음악클립
    /*
    public AudioClip titleBgmClip;
    public AudioClip mainBgmClip;
    public AudioClip miniBgmClip;

     */
    [SerializeField] private AudioClip[] BgmSounds;
    [SerializeField] private AudioClip[] sfxAudioSounds; //효과음들

    Dictionary<string, AudioClip> audioClipsDic = new Dictionary<string, AudioClip>();
    //오디오 클립을 key와 value형태로 관리하기 위해 딕셔너리 사용

    private void Awake()//초기화
    {
        if (Instance != this) //오디오 인스턴스가 없을 경우 자신을 인스턴스화 한다
        {
           Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject); //여러씬에 사용할 것이기 때문에 삭제하면 안된다.

        bgmPlayer = GameObject.Find("BgmSoundPlayer").GetComponent<AudioSource>();
        sfxPlayer = GameObject.Find("SfxSoundPlayer").GetComponent<AudioSource>();

        foreach (AudioClip audioCilp in sfxAudioSounds)
        {
            audioClipsDic.Add(audioCilp.name, audioCilp);
        }
    }

    //배경 사운드 재생 : 볼륨을 선택적 매개변수로
    public void PlayerBgmSound()
    {
        bgmPlayer.loop = true;
        bgmPlayer.volume = masterVolumeSfx * masterVolumeBgm;

        if(SceneManager.GetActiveScene().name == "TitleScene" )
        {
            Debug.Log("타이틀");
            bgmPlayer.clip = BgmSounds[1];
            bgmPlayer.Play();
        }

        else if (SceneManager.GetActiveScene().name == "Main")
        {
            Debug.Log("메인");
            bgmPlayer.clip = BgmSounds[0];
            bgmPlayer.Play();
        }

        else if (SceneManager.GetActiveScene().name == "MiniGame")
        {
            bgmPlayer.clip = BgmSounds[2];
            bgmPlayer.Play();
        }

        else if (SceneManager.GetActiveScene().name == "ScoreBoard")
        {
            Debug.Log("스킨화면");
            bgmPlayer.clip = BgmSounds[3];
            bgmPlayer.Play();
        }

        else
        {
            bgmPlayer.clip = BgmSounds[4];
            bgmPlayer.Play();
        }
    }

    //효과 사운드 재생 : 이름을 필수 볼륨을 선택적 매개변수로
    public void PlayerSfxSound(string name, float volume = 1f)
    {
        if(audioClipsDic.ContainsKey(name) == false)
        {
            return;
        }

        sfxPlayer.PlayOneShot(audioClipsDic[name], volume * masterVolumeSfx);
    }

    public void OptionSfxSound(string name, float volume = 1f)
    {
        if (audioClipsDic.ContainsKey(name) == false)
        {
            return;
        }

        StartCoroutine(SfxSoundOption());
        sfxPlayer.PlayOneShot(audioClipsDic[name], volume * masterVolumeSfx);
    }

    public IEnumerator SfxSoundOption()
    {
        yield return new WaitForSeconds(5.0f);

        StartCoroutine(SfxSoundOption());

    }

}
