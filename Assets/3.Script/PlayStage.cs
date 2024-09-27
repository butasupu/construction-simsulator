using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayStage : MonoBehaviour
{
    [SerializeField] GameObject Finish_UI;
    [SerializeField] GameObject rebar, form, concrete, wall,window, decoration;//���콺�� ��� ������Ʈ

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


    #region ���콺 ��ġ�� �ӽ� ������Ʈ ����
    /*
    private void ActiveObjectMousePosition()
    {
        //stickode.tistory.com/499
        //���콺 ��ġ�� �ӽ� ������Ʈ�� ����
        Vector3 point =
            Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y - Camera.main.transform.position.z));
            //���콺 ��ġ �޾ƿ���
            
        switch(GameManager.Instance.userData.constructionNum[0])
        {
            //���� Shader ����
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
    #region ���� �� 0927.3.11
    /*
    private void ActiveGuideObject()
    {
        //���� ���� constructionNum�� �� �ִ� ������ ������Ʈ�� Ȱ��ȭ�մϴ�.
        //���� ���콺�� Ŭ�� �� �ƹ��͵� �̷�� ���� �ʾ��� ��� �ٽ� ������Ʈ�� ��Ȱ��ȭ.
        if(GameManager.Instance.userData.stageNum[0] ==1)
        {
            if (GameManager.Instance.userData.constructionNum[0] == 0) return;
            if(GameManager.Instance.userData.constructionNum[0] ==1)
            {
                //ö��
                if (!pillar_rebar_1f.activeSelf)
                {
                    //+Shader ����
                    pillar_rebar_1f.SetActive(true);
                    
                }
                else if (pillar_rebar_1f.activeSelf)
                {
                    //+Shader ����
                    base_rebar_2f.SetActive(true);
                    
                }
                else if (pillar_rebar_1f.activeSelf&& base_rebar_2f.activeSelf)
                {
                    //+Shader ����
                    pillar_rebar_2f.SetActive(true);
                    
                }
               
            }
            if(GameManager.Instance.userData.constructionNum[0] == 2)
            {
                //��Ǫ��
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
                //��ũ��Ʈ
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
                //����
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
            //�������� 2 ����Ʈ
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
        //ActiveGuideObject�� ������ ������� ���� ���·� ���콺 Ŭ�� �� Shader�� ������� �ٲ���
        //ray ray
        if (GameManager.Instance.userData.constructionNum[0] == 0) return;
        if (Input.GetMouseButton(0))
        {
            Debug.Log("���콺 Ŭ��");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.Log("���̽�");
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("���� if����");
                hit.transform.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
                Debug.Log($"{ hit.transform.name} + �Դϴ�.");
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
