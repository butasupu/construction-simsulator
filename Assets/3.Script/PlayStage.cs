using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayStage : MonoBehaviour
{
    private GameObject FinishUI;
    [SerializeField] GameObject rebar, form, concrete, wall,window, decoration;//���콺�� ��� ������Ʈ

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
        //���� ���� constructionNum�� �� �ִ� ������ ������Ʈ�� Ȱ��ȭ�մϴ�.
        //Shader ���� ������ ActiveObjectMousePosition�� ��������� ������ �� ������� ����
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
