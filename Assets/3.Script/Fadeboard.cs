using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fadeboard : MonoBehaviour
{
    [SerializeField] private Image panel;
    [SerializeField] private GameObject fadeboard;
    private float fadeTime = 1.5f;
    private float AlphaColor;
    
    private void Start()
    {
        
    }

    public void FadeIn()
    {
        Debug.Log("fadein in");
        fadeboard.SetActive(true);
        StartCoroutine(FadeIn_Co());
        Debug.Log("fadein out");
    }
    public void FadeOut(int sceneNum)
    {
        Debug.Log("fadeout in");
        fadeboard.SetActive(true);
        StartCoroutine(FadeOut_Co(sceneNum));
        SceneManager.LoadScene(sceneNum);
        Debug.Log("fadeout out");

    }

    private IEnumerator FadeIn_Co()
    {
        AlphaColor = 1;  // ���� �������� ����
        while (AlphaColor > 0)
        {
            AlphaColor -= Time.deltaTime / fadeTime;  // fadeTime�� ���� AlphaColor ����
            panel.color = new Color(0, 0, 0, AlphaColor);  // �г��� ���� �� ����
            yield return null;  // �� �����Ӹ��� �ݺ�
        }
        panel.color = new Color(0, 0, 0, 0);  // ���� ���� ���·� ����
        fadeboard.SetActive(false);  // ���̵尡 �Ϸ�Ǹ� ��Ȱ��ȭ
    }

    private IEnumerator FadeOut_Co(int sceneNum)
    {
        AlphaColor = 0;  // ���� ������ ����
        while (AlphaColor < 1.0f)
        {
            AlphaColor += Time.deltaTime / fadeTime;  // fadeTime�� ���� AlphaColor ����
            panel.color = new Color(0, 0, 0, AlphaColor);  // �г��� ���� �� ����
            yield return null;  // �� �����Ӹ��� �ݺ�
        }
        panel.color = new Color(0, 0, 0, 1);  // ���� ������ ���·� ����
        SceneManager.LoadScene(sceneNum);  // ���ο� �� �ε�
    }
}
