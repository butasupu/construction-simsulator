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
        
        userData.stageNum = new int[1];
        userData.constructionNum = new int[1];

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GetBoolIsDone();
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
            Debug.Log("1½ºÅ×ÀÌÁö¿¡ 16°³ÀÇ bool ¹è¿­ÀÌ »ý¼ºµÇ¾ú½À´Ï´Ù.");
            /*
           0 = 1Ãþ ±âµÕ Ã¶±Ù
           1 = 2Ãþ º£ÀÌ½º Ã¶±Ù
           2 = 1Ãþ ºñ°è
          //
           3 = 1Ãþ ±âµÕ °ÅÇªÁý
           4 = 2Ãþ º£ÀÌ½º °ÅÇªÁý
           5 = 2Ãþ ºñ°è
          //
           6 = 1Ãþ ±âµÕ fin
           7 = 2Ãþ º£ÀÌ½º fin
           8 = 3Ãþ ºñ°è
          //
           9 = 2Ãþ ±âµÕ Ã¶±Ù
          10 = 2Ãþ ±âµÕ °ÅÇªÁý
          11 = 2Ãþ ±âµÕ fin
          12 = 3Ãþ ÁöºØ fin
          //
          13 = Ã¢¹®
          14 = º®¸¶°¨
          14 = ÁöºØ¸¶°¨
          15 = decoration

       */
        }
        else if (stageNum == 2)
        {
            userData.constructionIsDone = new bool[52];
            Debug.Log("2½ºÅ×ÀÌÁö¿¡ 52°³ÀÇ bool ¹è¿­ÀÌ »ý¼ºµÇ¾ú½À´Ï´Ù.");
            /*
          * 0 = 1Ãþ ±âµÕ Ã¶±Ù
          * 1 = 2Ãþ º£ÀÌ½º Ã¶±Ù
          * 2 = 1Ãþ ºñ°è
          //
          * 3 = 1Ãþ ±âµÕ °ÅÇªÁý
          * 4 = 2Ãþ º£ÀÌ½º °ÅÇªÁý
          * 5 = 2Ãþ ºñ°è
          //
          * 6 = 1Ãþ ±âµÕ fin
          * 7 = 2Ãþ º£ÀÌ½º fin
          //
          * 8 = 2Ãþ ±âµÕ Ã¶±Ù
          * 9 = 3Ãþ º£ÀÌ½º Ã¶±Ù
          * 10 = 3Ãþ ºñ°è
          //
          * 11 = 2Ãþ ±âµÕ °ÅÇªÁý
          * 12 = 3Ãþ º£ÀÌ½º °ÅÇªÁý
          * 13 = 4Ãþ ºñ°è
          //
          * 14 = 2Ãþ ±âµÕ fin
          * 15 = 3Ãþ º£ÀÌ½º fin
          //
          * 16 = 3Ãþ ±âµÕ Ã¶±Ù
          * 17 = 4Ãþ º£ÀÌ½º Ã¶±Ù
          * 18 = 5Ãþ ºñ°è
          //
          * 19 = 3Ãþ ±âµÕ °ÅÇªÁý
          * 20 = 4Ãþ º£ÀÌ½º °ÅÇªÁý
          //
          * 21 = 3Ãþ ±âµÕ fin
          * 22 = 4Ãþ º£ÀÌ½º fin
          * 23 = 6Ãþ ºñ°è
          //
          * 24 = 4Ãþ ±âµÕ Ã¶±Ù
          * 25 = 5Ãþ º£ÀÌ½º fin
          //
          * 26 = 4Ãþ ±âµÕ °ÅÇªÁý
          * 27 = 5Ãþ º£ÀÌ½º °ÅÇªÁý
          //
          * 28 = 4Ãþ ±âµÕ fin
          * 29 = 5Ãþ º£ÀÌ½º fin
          * 30 = 7Ãþ ºñ°è
          //
          * 31 = 5Ãþ ±âµÕ Ã¶±Ù
          * 32 = 6Ãþ º£ÀÌ½º Ã¶±Ù
          //
          * 33 = 5Ãþ ±âµÕ °ÅÇªÁý 
          * 34 = 6Ãþ º£ÀÌ½º °ÅÇªÁý
          //
          * 35 = 5Ãþ ±âµÕ fin
          * 36 = 6Ãþ º£ÀÌ½º fin
          * 37 = 8Ãþ ºñ°è
          //
          * 38 = 6Ãþ ±âµÕ Ã¶±Ù
          * 39 = 7Ãþ º£ÀÌ½º Ã¶±Ù
          //
          * 40 = 6Ãþ ±âµÕ °ÅÇªÁý
          * 41 = 7Ãþ º£ÀÌ½º °ÅÇªÁý
          //
          * 42 = 6Ãþ ±âµÕ fin
          * 43 = 7Ãþ º£ÀÌ½º fin
          * 44 = 9Ãþ ºñ°è
          //
          * 45 = 7Ãþ ±âµÕ Ã¶±Ù
          * 46 = 8Ãþ º£ÀÌ½º Ã¶±Ù
          //
          * 47 = 7Ãþ ±âµÕ °ÅÇªÁý
          * 48 = 8Ãþ º£ÀÌ½º °ÅÇªÁý(ÁöºØ)
          // 
          * 49 = 7Ãþ ±âµÕ fin
          * 50 = 8Ãþ º£ÀÌ½º fin (ÁöºØ)
          //
          * 51 = Ã¢¹®
          * 52 = µ¥ÄÚ·¹ÀÌ¼Ç
         */
        }
        else
        {
            Debug.Log("¾Æ¹«°Íµµ »ý¼º ¾ÈµÆ½À´Ï´Ù.");
        }
        Debug.Log("if¹® ¹ÛÀ¸·Î ³ª¿Ô½À´Ï´Ù.");


    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // ¾îÇÃ¸®ÄÉÀÌ¼Ç Á¾·á
#endif
    }
}
