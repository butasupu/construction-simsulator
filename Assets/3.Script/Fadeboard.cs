using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fadeboard : MonoBehaviour
{
    [SerializeField] private GameObject fadeInBoard, fadeOutBoard;

    private void Awake()
    {
        SceneManager.activeSceneChanged += OnActiveSceneChanged;
    }

    private void OnDestroy()
    {
        SceneManager.activeSceneChanged -= OnActiveSceneChanged;
    }

    private void OnActiveSceneChanged(Scene oldScene, Scene newScene)
    {
        // 새로운 씬으로 변경되었을 때 페이드 인 실행
        fadeInBoard.SetActive(true);
    }

    public void TriggerFadeOutAndLoadScene()
    {
        // 페이드 아웃 실행
        fadeOutBoard.SetActive(true);

        // 페이드 아웃이 완료된 후 씬을 로드
        StartCoroutine(LoadNewSceneAfterFadeOut());
    }

    private IEnumerator LoadNewSceneAfterFadeOut()
    {
        // 페이드 아웃 애니메이션 완료까지 대기
        yield return new WaitForSeconds(1f);

        // 씬 전환 (새로운 씬 로드)
        SceneManager.LoadScene("NextSceneName");
    }
}
