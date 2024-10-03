using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


[System.Serializable]
public class UserData
{
    public int[] stageNum;
    public int[] constructionNum;
    public bool[] constructionIsDone;
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public AudioMixer audioMixer;
    public AudioSource BGMaudioSource;
    public AudioSource SFXaudioSource;
    public AudioClip IntroBGM;
    public AudioClip StageBGM;
    public Animator ani;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public UserData userData;

    private void Start()
    {
        ani = GetComponent<Animator>();
        userData.stageNum = new int[1];
        userData.constructionNum = new int[1];

        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    //private void FixedUpdate()
    //{
    //    if(Input.GetKey(KeyCode.O))
    //    {
    //        FadeIn();
    //    }
    //    if (Input.GetKey(KeyCode.P))
    //    {
    //        FadeOut();
    //    }
    //}

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GetBoolIsDone();
        ChangeBGM();
    }

    public void SetStageIndex(int index)
    {
        GameManager.Instance.userData.stageNum[0] = index;
    }

    public void SetConstructionNum(int SCNum)
    {
        GameManager.Instance.userData.constructionNum[0] = SCNum;
        Debug.Log($"{GameManager.Instance.userData.constructionNum[0]}");
    }

    public void SceneLoad(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void SceneRestart()
    {
        int sceneNum = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(sceneNum);
    }


    private void GetBoolIsDone()
    {
        int stageNum = userData.stageNum[0];

        if (stageNum == 1)
        {
            userData.constructionIsDone = new bool[16];
            Debug.Log("1Ω∫≈◊¿Ã¡ˆø° 16∞≥¿« bool πËø≠¿Ã ª˝º∫µ«æ˙Ω¿¥œ¥Ÿ.");
            /*
           0 = 1√˛ ±‚µ’ √∂±Ÿ
           1 = 2√˛ ∫£¿ÃΩ∫ √∂±Ÿ
           2 = 1√˛ ∫Ò∞Ë
          //
           3 = 1√˛ ±‚µ’ ∞≈«™¡˝
           4 = 2√˛ ∫£¿ÃΩ∫ ∞≈«™¡˝
           5 = 2√˛ ∫Ò∞Ë
          //
           6 = 1√˛ ±‚µ’ fin
           7 = 2√˛ ∫£¿ÃΩ∫ fin
           8 = 3√˛ ∫Ò∞Ë
          //
           9 = 2√˛ ±‚µ’ √∂±Ÿ
          10 = 2√˛ ±‚µ’ ∞≈«™¡˝
          11 = 2√˛ ±‚µ’ fin
          12 = 3√˛ ¡ˆ∫ÿ fin
          //
          13 = √¢πÆ
          14 = ∫Æ∏∂∞®
          14 = ¡ˆ∫ÿ∏∂∞®
          15 = decoration

       */
        }
        else if (stageNum == 2)
        {
            userData.constructionIsDone = new bool[52];
            Debug.Log("2Ω∫≈◊¿Ã¡ˆø° 52∞≥¿« bool πËø≠¿Ã ª˝º∫µ«æ˙Ω¿¥œ¥Ÿ.");
            /*
          * 0 = 1√˛ ±‚µ’ √∂±Ÿ
          * 1 = 2√˛ ∫£¿ÃΩ∫ √∂±Ÿ
          * 2 = 1√˛ ∫Ò∞Ë
          //
          * 3 = 1√˛ ±‚µ’ ∞≈«™¡˝
          * 4 = 2√˛ ∫£¿ÃΩ∫ ∞≈«™¡˝
          * 5 = 2√˛ ∫Ò∞Ë
          //
          * 6 = 1√˛ ±‚µ’ fin
          * 7 = 2√˛ ∫£¿ÃΩ∫ fin
          //
          * 8 = 2√˛ ±‚µ’ √∂±Ÿ
          * 9 = 3√˛ ∫£¿ÃΩ∫ √∂±Ÿ
          * 10 = 3√˛ ∫Ò∞Ë
          //
          * 11 = 2√˛ ±‚µ’ ∞≈«™¡˝
          * 12 = 3√˛ ∫£¿ÃΩ∫ ∞≈«™¡˝
          * 13 = 4√˛ ∫Ò∞Ë
          //
          * 14 = 2√˛ ±‚µ’ fin
          * 15 = 3√˛ ∫£¿ÃΩ∫ fin
          //
          * 16 = 3√˛ ±‚µ’ √∂±Ÿ
          * 17 = 4√˛ ∫£¿ÃΩ∫ √∂±Ÿ
          * 18 = 5√˛ ∫Ò∞Ë
          //
          * 19 = 3√˛ ±‚µ’ ∞≈«™¡˝
          * 20 = 4√˛ ∫£¿ÃΩ∫ ∞≈«™¡˝
          //
          * 21 = 3√˛ ±‚µ’ fin
          * 22 = 4√˛ ∫£¿ÃΩ∫ fin
          * 23 = 6√˛ ∫Ò∞Ë
          //
          * 24 = 4√˛ ±‚µ’ √∂±Ÿ
          * 25 = 5√˛ ∫£¿ÃΩ∫ fin
          //
          * 26 = 4√˛ ±‚µ’ ∞≈«™¡˝
          * 27 = 5√˛ ∫£¿ÃΩ∫ ∞≈«™¡˝
          //
          * 28 = 4√˛ ±‚µ’ fin
          * 29 = 5√˛ ∫£¿ÃΩ∫ fin
          * 30 = 7√˛ ∫Ò∞Ë
          //
          * 31 = 5√˛ ±‚µ’ √∂±Ÿ
          * 32 = 6√˛ ∫£¿ÃΩ∫ √∂±Ÿ
          //
          * 33 = 5√˛ ±‚µ’ ∞≈«™¡˝ 
          * 34 = 6√˛ ∫£¿ÃΩ∫ ∞≈«™¡˝
          //
          * 35 = 5√˛ ±‚µ’ fin
          * 36 = 6√˛ ∫£¿ÃΩ∫ fin
          * 37 = 8√˛ ∫Ò∞Ë
          //
          * 38 = 6√˛ ±‚µ’ √∂±Ÿ
          * 39 = 7√˛ ∫£¿ÃΩ∫ √∂±Ÿ
          //
          * 40 = 6√˛ ±‚µ’ ∞≈«™¡˝
          * 41 = 7√˛ ∫£¿ÃΩ∫ ∞≈«™¡˝
          //
          * 42 = 6√˛ ±‚µ’ fin
          * 43 = 7√˛ ∫£¿ÃΩ∫ fin
          * 44 = 9√˛ ∫Ò∞Ë
          //
          * 45 = 7√˛ ±‚µ’ √∂±Ÿ
          * 46 = 8√˛ ∫£¿ÃΩ∫ √∂±Ÿ
          //
          * 47 = 7√˛ ±‚µ’ ∞≈«™¡˝
          * 48 = 8√˛ ∫£¿ÃΩ∫ ∞≈«™¡˝(¡ˆ∫ÿ)
          // 
          * 49 = 7√˛ ±‚µ’ fin
          * 50 = 8√˛ ∫£¿ÃΩ∫ fin (¡ˆ∫ÿ)
          //
          * 51 = √¢πÆ
          * 52 = µ•ƒ⁄∑π¿Ãº«
         */
        }
        else
        {
            Debug.Log("æ∆π´∞Õµµ ª˝º∫ æ»µ∆Ω¿¥œ¥Ÿ.");
        }
        Debug.Log("ifπÆ π€¿∏∑Œ ≥™ø‘Ω¿¥œ¥Ÿ.");


    }
    public void PlayClip(AudioClip clip)
    {
       if(clip != null)
        {
            SFXaudioSource.PlayOneShot(clip);
            Debug.Log($"{clip}¿Ã ¿Áª˝µ«æ˙Ω¿¥œ¥Ÿ.");
        }
    }
    public void ChangeBGM()
    {
        if(userData.stageNum[0] == 0)
        {
            BGMaudioSource.clip = IntroBGM;
            BGMaudioSource.loop = true;
            BGMaudioSource.Play();
        }
        if(userData.stageNum[0] > 0)
        {
            BGMaudioSource.clip = StageBGM;
            BGMaudioSource.loop = true;
            BGMaudioSource.Play();
        }
    }
    public void MasterSetting(float val)
    {
        audioMixer.SetFloat("Master", Mathf.Log10(val) * 20);

    }
    public void BGMSetting(float val)
    {
        audioMixer.SetFloat("BGM", Mathf.Log10(val) * 20);
    }
    public void SFXSetting(float val)
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(val) * 20);
    }

    public void FadeIn()
    {
        ani.SetTrigger("FadeIn");
    }
    public void FadeOut()
    {
        ani.SetTrigger("FadeOut");
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // æÓ«√∏Æƒ…¿Ãº« ¡æ∑·
#endif
    }
}
