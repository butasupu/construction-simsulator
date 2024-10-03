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

    [SerializeField]
    GameObject
        A_1F_pillar_rebar, A_1F_pillar_form, A_1F_pillar_concre,
        A_2F_pillar_rebar, A_2F_pillar_form, A_2F_pillar_concre,
        A_3F_pillar_rebar, A_3F_pillar_form, A_3F_pillar_concre,
        A_4F_pillar_rebar, A_4F_pillar_form, A_4F_pillar_concre,
        A_5F_pillar_rebar, A_5F_pillar_form, A_5F_pillar_concre,
        A_6F_pillar_rebar, A_6F_pillar_form, A_6F_pillar_concre,
        A_7F_pillar_rebar, A_7F_pillar_form, A_7F_pillar_concre,


        A_2F_base_rebar, A_2F_base_form, A_2F_base_concre,
        A_3F_base_rebar, A_3F_base_form, A_3F_base_concre,
        A_4F_base_rebar, A_4F_base_form, A_4F_base_concre,
        A_5F_base_rebar, A_5F_base_form, A_5F_base_concre,
        A_6F_base_rebar, A_6F_base_form, A_6F_base_concre,
        A_7F_base_rebar, A_7F_base_form, A_7F_base_concre,
        A_8F_base_rebar, A_8F_base_form, A_8F_base_concre,

        A_scaffold_1F, A_scaffold_2F, A_scaffold_3F,
        A_scaffold_4F, A_scaffold_5F, A_scaffold_6F,
        A_scaffold_7F, A_scaffold_8F, A_scaffold_9F,

        A_wall, A_window, A_decoration;



    int currentStep =0;

    //stage1
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] AudioClip clearClip;
    private AudioSource audioSource;
    

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    private void Start()
    {
        int layerMask = ~(1 << LayerMask.NameToLayer("Ignore Raycast"));
        //currentStep = 0;
    }

    private void Update()
    {
        //ActiveObjectMousePosition();
       
    }
    private void FixedUpdate()
    {
        ClaerCheck();
        ActiveGuideObject();
        DestroyForm();
        //ActiveRealObject();
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
        if (GameManager.Instance.userData.constructionNum[0] == 0) return;
        if(GameManager.Instance.userData.stageNum[0] ==1)
        {
            switch (GameManager.Instance.userData.constructionNum[0])
            {
                case 1:
                    ActiveConstructionStep(pillar_rebar_1f, base_rebar_2f, pillar_rebar_2f);
                    break;
                case 2:
                    ActiveConstructionStep(pillar_form_1f, base_form_2f, pillar_form_2f);
                    break;
                case 3:
                    ActiveConstructionStep(pillar_concre_1f, base_concre_2f, pillar_concre_2f, roofstructure);
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

        if(GameManager.Instance.userData.stageNum[0] == 2)
        {
            switch(GameManager.Instance.userData.constructionNum[0])
            {
                case 1:
                    ActiveConstructionStep_2(A_1F_pillar_rebar, 
                        A_2F_base_rebar, A_2F_pillar_rebar,
                        A_3F_base_rebar, A_3F_pillar_rebar, 
                        A_4F_base_rebar, A_4F_pillar_rebar,
                        A_5F_base_rebar, A_5F_pillar_rebar,
                        A_6F_base_rebar, A_6F_pillar_rebar,
                        A_7F_base_rebar, A_7F_pillar_rebar,
                        A_8F_base_rebar
                        );
                    break;
                case 2:
                    ActiveConstructionStep_2(A_1F_pillar_form,
                        A_2F_base_form, A_2F_pillar_form,
                        A_3F_base_form, A_3F_pillar_form,
                        A_4F_base_form, A_4F_pillar_form,
                        A_5F_base_form, A_5F_pillar_form,
                        A_6F_base_form, A_6F_pillar_form,
                        A_7F_base_form, A_7F_pillar_form,
                        A_8F_base_form
                        );
                    break;
                case 3:
                    ActiveConstructionStep_2(A_1F_pillar_concre,
                        A_2F_base_concre, A_2F_pillar_concre,
                        A_3F_base_concre, A_3F_pillar_concre,
                        A_4F_base_concre, A_4F_pillar_concre,
                        A_5F_base_concre, A_5F_pillar_concre,
                        A_6F_base_concre, A_6F_pillar_concre,
                        A_7F_base_concre, A_7F_pillar_concre,
                        A_8F_base_concre
                        );
                    break;
                case 4:
                    ActiveConstructionStep_2(
                        A_scaffold_1F, A_scaffold_2F, A_scaffold_3F,
                        A_scaffold_4F, A_scaffold_5F, A_scaffold_6F,
                        A_scaffold_7F, A_scaffold_8F, A_scaffold_9F
                        );
                    break;
                case 5:
                    A_window.SetActive(true);
                    break;
                case 6:
                    A_wall.SetActive(true);
                    break;
                case 7:
                    roofFin.SetActive(true);
                    break;
                case 8:
                    A_decoration.SetActive(true);
                    break;

            }
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

    private void ActiveConstructionStep_2(GameObject firstOBJ, GameObject secondObj = null, GameObject thirdObj = null,
        GameObject fourthObj = null, GameObject fifthObj = null, GameObject sixthObj = null, GameObject SeventhObj = null,
        GameObject eighthObj = null, GameObject ninthObj = null, GameObject tenthObj = null, GameObject eleventh = null,
        GameObject twelfthObj = null, GameObject thirteenObj =null, GameObject fourteenObj = null)
    {
        if (!firstOBJ.activeSelf && currentStep == 0)
        {
            firstOBJ.SetActive(true);
            if (secondObj != null)
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
        if (firstOBJ.activeSelf && currentStep == 1)
        {
            secondObj.SetActive(true);
            if (secondObj != null)
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
        if (secondObj.activeSelf && currentStep == 2)
        {
            thirdObj.SetActive(true);
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
        if (thirdObj.activeSelf && currentStep == 3)
        {
            fourthObj.SetActive(true);
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
        if (fourthObj.activeSelf && currentStep == 4)
        {
            fifthObj.SetActive(true);
            if (fifthObj != null)
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
        if (fifthObj.activeSelf && currentStep == 5)
        {
            sixthObj.SetActive(true);
            if (sixthObj != null)
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
        if (sixthObj.activeSelf && currentStep == 6)
        {
            SeventhObj.SetActive(true);
            if (SeventhObj != null)
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
        if (SeventhObj.activeSelf && currentStep == 7)
        {
            eighthObj.SetActive(true);
            if (eighthObj != null)
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
        if (eighthObj.activeSelf && currentStep == 8)
        {
            ninthObj.SetActive(true);
            if (ninthObj != null)
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
        if (ninthObj.activeSelf && currentStep == 9)
        {
            tenthObj.SetActive(true);
            if (tenthObj != null)
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
        if (tenthObj.activeSelf && currentStep == 10)
        {
            eleventh.SetActive(true);
            if (eleventh != null)
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
        if (eleventh.activeSelf && currentStep == 11)
        {
            twelfthObj.SetActive(true);
            if (twelfthObj != null)
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
        if (twelfthObj.activeSelf && currentStep == 12)
        {
            thirteenObj.SetActive(true);
            if (thirteenObj != null)
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
        if (thirteenObj.activeSelf && currentStep == 13)
        {
            fourteenObj.SetActive(true);
            if (fourteenObj != null)
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
    }
    #region ���콺 ���̾��ũ ���� 
    /*

    private void ActiveRealObject()
    {
        int layerMask = ~(1 << LayerMask.NameToLayer("Ignore Raycast"));
        //nicotina04.tistory.com /271
        
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

     */
    #endregion

    private void ClaerCheck()
    {
        if (!decoration_house.activeSelf||!!A_decoration.activeSelf) return;
        if(decoration_house.activeSelf|| A_decoration.activeSelf)
        {
            Finish_UI.SetActive(true);
            GameManager.Instance.BGMaudioSource.Stop();
        }
        return;
    }

    public void DestroyForm()
    {
        if(GameManager.Instance.userData.stageNum[0] ==1)
        {
            if (pillar_concre_1f.activeSelf)
            {
                pillar_form_1f.SetActive(false);
                pillar_rebar_1f.SetActive(false);
            }
            if (pillar_concre_2f.activeSelf)
            {
                pillar_form_2f.SetActive(false);
                pillar_rebar_2f.SetActive(false);
            }
            if (base_concre_2f.activeSelf)
            {
                base_form_2f.SetActive(false);
                base_rebar_2f.SetActive(false);
            }
        }
        if (GameManager.Instance.userData.stageNum[0] == 2)
        {
            if(A_1F_pillar_concre.activeSelf)
            {
                A_1F_pillar_rebar.SetActive(false);
                A_1F_pillar_form.SetActive(false);
            }
            if (A_2F_pillar_concre.activeSelf)
            {
                A_2F_pillar_rebar.SetActive(false);
                A_2F_pillar_form.SetActive(false);
            }
            if (A_3F_pillar_concre.activeSelf)
            {
                A_3F_pillar_rebar.SetActive(false);
                A_3F_pillar_form.SetActive(false);
            }
            if (A_4F_pillar_concre.activeSelf)
            {
                A_4F_pillar_rebar.SetActive(false);
                A_4F_pillar_form.SetActive(false);
            }
            if (A_5F_pillar_concre.activeSelf)
            {
                A_5F_pillar_rebar.SetActive(false);
                A_5F_pillar_form.SetActive(false);
            }
            if (A_6F_pillar_concre.activeSelf)
            {
                A_6F_pillar_rebar.SetActive(false);
                A_6F_pillar_form.SetActive(false);
            }
            if (A_7F_pillar_concre.activeSelf)
            {
                A_7F_pillar_rebar.SetActive(false);
                A_7F_pillar_form.SetActive(false);
            }
            if(A_2F_base_concre.activeSelf)
            {
                A_2F_base_form.SetActive(false);
                A_2F_base_rebar.SetActive(false);
            }
            if (A_3F_base_concre.activeSelf)
            {
                A_3F_base_form.SetActive(false);
                A_3F_base_rebar.SetActive(false);
            }
            if (A_4F_base_concre.activeSelf)
            {
                A_4F_base_form.SetActive(false);
                A_4F_base_rebar.SetActive(false);
            }
            if (A_5F_base_concre.activeSelf)
            {
                A_5F_base_form.SetActive(false);
                A_5F_base_rebar.SetActive(false);
            }
            if (A_6F_base_concre.activeSelf)
            {
                A_6F_base_form.SetActive(false);
                A_6F_base_rebar.SetActive(false);
            }
            if (A_7F_base_concre.activeSelf)
            {
                A_7F_base_form.SetActive(false);
                A_7F_base_rebar.SetActive(false);
            }
            if (A_8F_base_concre.activeSelf)
            {
                A_8F_base_form.SetActive(false);
                A_8F_base_rebar.SetActive(false);
            }
        }
    }
}
