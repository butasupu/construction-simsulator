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
        // ���ο� ������ ����Ǿ��� �� ���̵� �� ����
        fadeInBoard.SetActive(true);
    }

    public void TriggerFadeOutAndLoadScene()
    {
        // ���̵� �ƿ� ����
        fadeOutBoard.SetActive(true);

        // ���̵� �ƿ��� �Ϸ�� �� ���� �ε�
        StartCoroutine(LoadNewSceneAfterFadeOut());
    }

    private IEnumerator LoadNewSceneAfterFadeOut()
    {
        // ���̵� �ƿ� �ִϸ��̼� �Ϸ���� ���
        yield return new WaitForSeconds(1f);

        // �� ��ȯ (���ο� �� �ε�)
        SceneManager.LoadScene("NextSceneName");
    }
}
