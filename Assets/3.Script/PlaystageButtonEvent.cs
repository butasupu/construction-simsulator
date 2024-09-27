using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaystageButtonEvent : MonoBehaviour
{
    public  void P_SetConstructionNum(int SCNum)
    {
        GameManager.Instance.SetConstructionNum(SCNum);
    }
    public void P_SceneLoad(int index)
    {
        GameManager.Instance.SceneLoad(index);
    }
    public void P_SceneRestart()
    {
        GameManager.Instance.SceneRestart();
    }
    public void P_ExitGame()
    {
        GameManager.Instance.ExitGame();
    }
    public void P_SetStageNum(int index)
    {
        GameManager.Instance.SetStageIndex(index);
    }


}
