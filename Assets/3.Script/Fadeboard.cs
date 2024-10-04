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
        AlphaColor = 1;  // 완전 불투명에서 시작
        while (AlphaColor > 0)
        {
            AlphaColor -= Time.deltaTime / fadeTime;  // fadeTime에 맞춰 AlphaColor 감소
            panel.color = new Color(0, 0, 0, AlphaColor);  // 패널의 알파 값 적용
            yield return null;  // 매 프레임마다 반복
        }
        panel.color = new Color(0, 0, 0, 0);  // 완전 투명 상태로 설정
        fadeboard.SetActive(false);  // 페이드가 완료되면 비활성화
    }

    private IEnumerator FadeOut_Co(int sceneNum)
    {
        AlphaColor = 0;  // 완전 투명에서 시작
        while (AlphaColor < 1.0f)
        {
            AlphaColor += Time.deltaTime / fadeTime;  // fadeTime에 맞춰 AlphaColor 증가
            panel.color = new Color(0, 0, 0, AlphaColor);  // 패널의 알파 값 적용
            yield return null;  // 매 프레임마다 반복
        }
        panel.color = new Color(0, 0, 0, 1);  // 완전 불투명 상태로 설정
        SceneManager.LoadScene(sceneNum);  // 새로운 씬 로드
    }
}
