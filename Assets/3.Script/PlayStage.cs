using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayStage : MonoBehaviour
{
    [SerializeField] GameObject Finish_UI;
    [SerializeField] GameObject rebar, form, concrete, wall,window, decoration;//마우스에 띄울 오브젝트

    [SerializeField]
    GameObject
        pillar_rebar_1f, pillar_form_1f, pillar_concre_1f,
        pillar_rebar_2f, pillar_form_2f, pillar_concre_2f,
        base_rebar_2f, base_form_2f, base_concre_2f,
        scaffold_1f, scaffold_2f, scaffold_3f,wall_house,
        roofstructure, window_house, roofFin, decoration_house;

    int currentStep =0;

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
        currentStep = 0;
    }

    private void Update()
    {
        //ActiveObjectMousePosition();
        ClaerCheck();
    }
    private void FixedUpdate()
    {
        ActiveGuideObject();
        ActiveRealObject();
    }


    #region 마우스 위치에 임시 오브젝트 생성
    /*
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
                    rebar.SetActive(true);
                    transform.position = point;
                }
                break;
            case 2:
                {
                    form.SetActive(true);
                    transform.position = point;
                }
                break;
            case 3:
                {
                    concrete.SetActive(true);
                    transform.position = point;
                }
                break;
            case 4:
                {
                    wall.SetActive(true);
                    transform.position = point;
                }
                break;
            case 5:
                {
                    window.SetActive(true);
                    transform.position = point;
                }
                break;

            case 6:
                {
                    decoration.SetActive(true);
                    transform.position = point;
                }
                break;



        }
    }
    */
    #endregion
    #region 수정 전 0927.3.11
    /*
    private void ActiveGuideObject()
    {
        //지금 현재 constructionNum에 들어가 있는 숫자의 오브젝트를 활성화합니다.
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
    */
    #endregion

    private void ActiveGuideObject()
    {
        if (GameManager.Instance.userData.stageNum[0] != 1) return;
        if (GameManager.Instance.userData.constructionNum[0] == 0) return;

        switch(GameManager.Instance.userData.constructionNum[0])
        {
            case 1:
                ActiveConstructionStep(pillar_rebar_1f, base_rebar_2f, pillar_rebar_2f);
                break;
            case 2:
                ActiveConstructionStep(pillar_form_1f, base_form_2f, pillar_form_2f);
                break;
            case 3:
                ActiveConstructionStep(pillar_concre_1f, base_concre_2f, pillar_concre_2f);
                break;

            case 4:
                ActiveConstructionStep(scaffold_1f, scaffold_2f, scaffold_3f);
                break;
            case 5:
                window_house.SetActive(true);
                break;
            case 6:
                wall_house.SetActive(true);
                break;
            case 7:
                roofFin.SetActive(true);
                break;
            case 8:
                decoration_house.SetActive(true);
                break;

        }
    }

    private void ActiveConstructionStep(GameObject firstObj, GameObject secondObj = null,GameObject thirdObj = null, GameObject fourthObj = null)
    {
        if(!firstObj.activeSelf&& currentStep ==0)
        {
            firstObj.SetActive(true);
            if(secondObj != null)
            {
                currentStep++;
                Debug.Log($"step{currentStep}");
            }
            else
            {
                currentStep = 0;
                Debug.Log($"step{currentStep}");
            }
            GameManager.Instance.userData.constructionNum[0] = 0;
            return;
        }
        if(secondObj != null && !secondObj.activeSelf && firstObj.activeSelf && currentStep == 1)
        {
            secondObj.SetActive(true);
            if (thirdObj != null)
            {
                currentStep++;
                Debug.Log($"step{currentStep}");
            }
            else
            {
                currentStep = 0;
                Debug.Log($"step{currentStep}");
            }
            GameManager.Instance.userData.constructionNum[0] = 0;
            return;
        }
        if (thirdObj != null && !thirdObj.activeSelf && secondObj.activeSelf && currentStep == 2)
        {
            thirdObj.SetActive(true);
            if (fourthObj != null)
            {
                currentStep++;
                Debug.Log($"step{currentStep}");
            }
            else
            {
                currentStep = 0;
                Debug.Log($"step{currentStep}");
            }
            GameManager.Instance.userData.constructionNum[0] = 0;
            return;
        }
        if (fourthObj != null && !fourthObj.activeSelf && thirdObj.activeSelf && currentStep == 3)
        {
            fourthObj.SetActive(true);
            currentStep = 0;
            Debug.Log($"step{currentStep}");
            GameManager.Instance.userData.constructionNum[0] = 0;
            return;

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
        if (!decoration_house.activeSelf) return;
        if(decoration_house.activeSelf)
        {
            Finish_UI.SetActive(true);
            audioSource.Stop();
            audioSource.clip = audioClip;
            audioSource.Play();
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

}
