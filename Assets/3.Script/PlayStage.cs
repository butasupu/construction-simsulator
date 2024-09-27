using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayStage : MonoBehaviour
{
    private GameObject FinishUI;
    [SerializeField] GameObject rebar, form, concrete, wall,window, decoration;//마우스에 띄울 오브젝트

    [SerializeField]
    GameObject
        pillar_rebar_1f, pillar_form_1f, pillar_concre_1f,
        pillar_rebar_2f, pillar_form_2f, pillar_concre_2f,
        base_rebar_2f, base_form_2f, base_concre_2f,
        scaffold_1f, scaffold_2f, scaffold_3f,wall_house,
        roofstructure, window_house, roofFin, decoration_house;

    //stage1
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] AudioClip audioClip;
    private AudioSource audioSource;
    

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        ActiveObjectMousePosition();
        ClaerCheck();
    }
    private void FixedUpdate()
    {
        ActiveGuideObject();
        ActiveRealObject();
    }



    private void ActiveObjectMousePosition()
    {
        //stickode.tistory.com/499
        //마우스 위치에 임시 오브젝트를 생성
        Vector3 point =
            Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y - Camera.main.transform.position.z));
            //마우스 위치 받아오기
            
        switch(GameManager.Instance.userData.constructionNum[0])
        {
            //전부 Shader 변경
            case 0:
                return;
            case 1:
                { 
                    transform.position = point;
                    rebar.SetActive(true);
                }
                break;
            case 2:
                {
                    transform.position = point;
                    form.SetActive(true);
                }
                break;
            case 3:
                {
                    transform.position = point;
                    concrete.SetActive(true);
                }
                break;
            case 4:
                {
                    transform.position = point;
                    wall.SetActive(true);
                }
                break;
            case 5:
                {
                    transform.position = point;
                    window.SetActive(true);
                }
                break;

            case 6:
                {
                    transform.position = point;
                    decoration.SetActive(true);
                }
                break;



        }
    }

    private void ActiveGuideObject()
    {
        //지금 현재 constructionNum에 들어가 있는 숫자의 오브젝트를 활성화합니다.
        //Shader 색은 빨간색 ActiveObjectMousePosition의 오브젝드와 곂쳐질 시 녹색으로 변경
        //만약 마우스의 클릭 시 아무것도 이루어 지지 않았을 경우 다시 오브젝트를 비활성화.
        if(GameManager.Instance.userData.stageNum[0] ==1)
        {
            if (GameManager.Instance.userData.constructionNum[0] == 0) return;
            if(GameManager.Instance.userData.constructionNum[0] ==1)
            {
                //철근
                if (!pillar_rebar_1f.activeSelf)
                {
                    //+Shader 변경
                    pillar_rebar_1f.SetActive(true);
                    
                }
                else if (pillar_rebar_1f.activeSelf)
                {
                    //+Shader 변경
                    base_rebar_2f.SetActive(true);
                    
                }
                else if (pillar_rebar_1f.activeSelf&& base_rebar_2f.activeSelf)
                {
                    //+Shader 변경
                    pillar_rebar_2f.SetActive(true);
                    
                }
               
            }
            if(GameManager.Instance.userData.constructionNum[0] == 2)
            {
                //거푸집
                if(!pillar_form_1f.activeSelf)
                {
                    pillar_form_1f.SetActive(true);
                }
                else if (pillar_form_1f.activeSelf)
                {
                    base_form_2f.SetActive(true);
                }
                else if (pillar_form_1f.activeSelf&& base_form_2f.activeSelf)
                {
                    pillar_form_2f.SetActive(true);
                }
            }
            if (GameManager.Instance.userData.constructionNum[0] == 3)
            {
                //콘크리트
                if (!pillar_concre_1f.activeSelf)
                {
                    pillar_concre_1f.SetActive(true);

                }
                else if (pillar_concre_1f.activeSelf)
                {
                    base_concre_2f.SetActive(true);
                }
                else if (pillar_concre_1f.activeSelf && base_concre_2f.activeSelf)
                {
                    pillar_concre_2f.SetActive(true);
                }
                else if (pillar_concre_1f.activeSelf && base_concre_2f.activeSelf&& pillar_concre_2f.activeSelf)
                {
                    roofstructure.SetActive(true);
                }
            }
            if (GameManager.Instance.userData.constructionNum[0] == 4)
            {
                //발판
                if (!scaffold_1f.activeSelf)
                {
                    scaffold_1f.SetActive(true);
                }
                else if (scaffold_1f.activeSelf)
                {
                    scaffold_2f.SetActive(true);
                }
                else if (scaffold_1f.activeSelf && scaffold_2f.activeSelf)
                {
                    scaffold_3f.SetActive(true);
                }

            }
            if (GameManager.Instance.userData.constructionNum[0] == 5)
            {
                wall_house.SetActive(true);
            }
            if (GameManager.Instance.userData.constructionNum[0] == 6)
            {
                window_house.SetActive(true);
            }
            if (GameManager.Instance.userData.constructionNum[0] == 7)
            {
                decoration_house.SetActive(true);
            }
        }
        if (GameManager.Instance.userData.stageNum[0] == 2)
        {
            //스테이지 2 아파트
        }
    }

    private void ActiveRealObject()
    {
        //int layerMask = ~(1 << LayerMask.NameToLayer("Ignore Raycast"));
        //nicotina04.tistory.com /271
        //ActiveGuideObject가 곂쳐져 녹색으로 변경 상태로 마우스 클릭 시 Shader값 원래대로 바꿔줌
        //ray ray
        if (GameManager.Instance.userData.constructionNum[0] == 0) return;
        if (Input.GetMouseButton(0))
        {
            Debug.Log("마우스 클릭");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.Log("레이쏨");
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("레이 if문임");
                hit.transform.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
                Debug.Log($"{ hit.transform.name} + 입니다.");
            }
        }
    }


    private void ClaerCheck()
    {
        if (!decoration.activeSelf) return;
        FinishUI.SetActive(true);
        audioSource.Stop();
        audioSource.clip = audioClip;
        audioSource.Play();
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

}
