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
            Debug.Log("1���������� 16���� bool �迭�� �����Ǿ����ϴ�.");
            /*
           0 = 1�� ��� ö��
           1 = 2�� ���̽� ö��
           2 = 1�� ���
          //
           3 = 1�� ��� ��Ǫ��
           4 = 2�� ���̽� ��Ǫ��
           5 = 2�� ���
          //
           6 = 1�� ��� fin
           7 = 2�� ���̽� fin
           8 = 3�� ���
          //
           9 = 2�� ��� ö��
          10 = 2�� ��� ��Ǫ��
          11 = 2�� ��� fin
          12 = 3�� ���� fin
          //
          13 = â��
          14 = ������
          14 = ���ظ���
          15 = decoration

       */
        }
        else if (stageNum == 2)
        {
            userData.constructionIsDone = new bool[52];
            Debug.Log("2���������� 52���� bool �迭�� �����Ǿ����ϴ�.");
            /*
          * 0 = 1�� ��� ö��
          * 1 = 2�� ���̽� ö��
          * 2 = 1�� ���
          //
          * 3 = 1�� ��� ��Ǫ��
          * 4 = 2�� ���̽� ��Ǫ��
          * 5 = 2�� ���
          //
          * 6 = 1�� ��� fin
          * 7 = 2�� ���̽� fin
          //
          * 8 = 2�� ��� ö��
          * 9 = 3�� ���̽� ö��
          * 10 = 3�� ���
          //
          * 11 = 2�� ��� ��Ǫ��
          * 12 = 3�� ���̽� ��Ǫ��
          * 13 = 4�� ���
          //
          * 14 = 2�� ��� fin
          * 15 = 3�� ���̽� fin
          //
          * 16 = 3�� ��� ö��
          * 17 = 4�� ���̽� ö��
          * 18 = 5�� ���
          //
          * 19 = 3�� ��� ��Ǫ��
          * 20 = 4�� ���̽� ��Ǫ��
          //
          * 21 = 3�� ��� fin
          * 22 = 4�� ���̽� fin
          * 23 = 6�� ���
          //
          * 24 = 4�� ��� ö��
          * 25 = 5�� ���̽� fin
          //
          * 26 = 4�� ��� ��Ǫ��
          * 27 = 5�� ���̽� ��Ǫ��
          //
          * 28 = 4�� ��� fin
          * 29 = 5�� ���̽� fin
          * 30 = 7�� ���
          //
          * 31 = 5�� ��� ö��
          * 32 = 6�� ���̽� ö��
          //
          * 33 = 5�� ��� ��Ǫ�� 
          * 34 = 6�� ���̽� ��Ǫ��
          //
          * 35 = 5�� ��� fin
          * 36 = 6�� ���̽� fin
          * 37 = 8�� ���
          //
          * 38 = 6�� ��� ö��
          * 39 = 7�� ���̽� ö��
          //
          * 40 = 6�� ��� ��Ǫ��
          * 41 = 7�� ���̽� ��Ǫ��
          //
          * 42 = 6�� ��� fin
          * 43 = 7�� ���̽� fin
          * 44 = 9�� ���
          //
          * 45 = 7�� ��� ö��
          * 46 = 8�� ���̽� ö��
          //
          * 47 = 7�� ��� ��Ǫ��
          * 48 = 8�� ���̽� ��Ǫ��(����)
          // 
          * 49 = 7�� ��� fin
          * 50 = 8�� ���̽� fin (����)
          //
          * 51 = â��
          * 52 = ���ڷ��̼�
         */
        }
        else
        {
            Debug.Log("�ƹ��͵� ���� �ȵƽ��ϴ�.");
        }
        Debug.Log("if�� ������ ���Խ��ϴ�.");


    }
    public void PlayClip(AudioClip clip)
    {
       if(clip != null)
        {
            SFXaudioSource.PlayOneShot(clip);
            Debug.Log($"{clip}�� ����Ǿ����ϴ�.");
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
        Application.Quit(); // ���ø����̼� ����
#endif
    }
}
