using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectMouseOver : MonoBehaviour
{
    private Material material;
    private Color origincolor = Color.white;
    private bool isActive;
    [SerializeField] private AudioClip isActiveSound;

    private void Start()
    {
        isActive = false;
        material = GetComponent<MeshRenderer>().material;
        //origincolor = material.GetColor("_BaseColor");
       
    }
    private void Update()
    {
        DetectMouseOverObject();
        ActiveRealObject();
    }
    #region 2024.09.30 ���� �� DetectMouseOverObject
    /*
    private void DetectMouseOverObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray,out hit))
        {
            if(hit.transform.parent == transform.parent)
            {
                //Debug.Log("�ʷ� ����");
                //this.material.color = Color.green;
                material.SetColor("_BaseColor", Color.green);
            }
        }
        else
        {
            //this.material.color = Color.red;
            material.SetColor("_BaseColor", Color.red);  // ���̴��� BaseColor ����
        }
    }
    */
    #endregion
    #region 2024.09.30 ���� �� ActiveRealObject
    /*
    private void ActiveRealObject()
    {
       
        int layerMask = ~(1 << LayerMask.NameToLayer("Ignore Raycast"));  // "Ignore Raycast" ���̾ �����ϴ� ����ũ

        if (Input.GetMouseButton(0))
        {
            Debug.Log("���콺 Ŭ��");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.parent == transform.parent)
                {
                    
                    material.SetColor("_BaseColor", Color.green);

                    
                    if (Input.GetMouseButtonDown(0))  // ���콺 ���� Ŭ��
                    {
                        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");  // ���̾ "Ignore Raycast"�� ����
                        material.SetColor("_BaseColor", origincolor);  // ���� �������� ����
                        Debug.Log($"{hit.transform.name}�� 'Ignore Raycast'�� ����ǰ� ������ ���� �������� �����Ǿ����ϴ�.");
                    }
                }
            }
            else if(hit.transform.parent.gameObject.layer == 2 )
            {
                // ������Ʈ���� ���콺�� ����� ���������� ����
                material.SetColor("_BaseColor", Color.red);
            }
        }
    }
    */
    #endregion

    private void OnEnable()
    {
        SetChildrenColor(transform.parent, Color.red);
    }

    private void DetectMouseOverObject()
    {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit))
        {
            // ������ ������Ʈ�� �θ� ������
            Transform parentTransform = hit.transform.parent;

            if (parentTransform != null)  // �θ� �����ϴ��� Ȯ��
            {
                SetChildrenColor(parentTransform, Color.green);  // �θ��� ��� �ڽĵ��� ������ �ʷϻ����� ����

            }
            else
            {
                SetChildrenColor(transform.parent, Color.red);  // �θ��� ��� �ڽĵ��� ������ ���������� ����
                Debug.Log("����");

            }

        }

    }

    private void ActiveRealObject()
    {
        int layerMask = ~(1 << LayerMask.NameToLayer("Ignore Raycast"));  // "Ignore Raycast" ���̾ �����ϴ� ����ũ
        
        if (Input.GetMouseButton(0))  // ���콺 Ŭ�� ����
        {
            Debug.Log("���콺 Ŭ��");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // �θ� ������ Ȯ��
                if (hit.transform.parent == transform.parent)
                {

                    // �θ��� �ڽĵ鸸 ������ ���� �������� ����
                    Transform parentTransform = hit.transform.parent;  // ������ ������Ʈ�� �θ�

                    // �ڽĵ鸸 ��ȸ
                    foreach (Transform child in parentTransform)
                    {
                        // �θ� �ڽ��� ������ �ڽĵ鸸 ���� ����
                        if (child != parentTransform)  // �θ� ����
                        {
                            Renderer childRenderer = child.GetComponent<Renderer>();
                            if (childRenderer != null)
                            {
                                childRenderer.material.SetColor("_BaseColor", Color.white);  // �ڽ��� ���� ����
                                                                                             // SetChildrenColor(child, Color.white);  // �ڽĵ��� ������ ���� �������� ����
                                child.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
                                GameManager.Instance.PlayClip(isActiveSound);
                            }
                        }

                    }

                    Debug.Log($"{hit.transform.parent.name}�� �ڽĵ��� ������ ���� �������� �����Ǿ����ϴ�.");

                    isActive = true;
                    Debug.Log($"{isActive} �Դϴ�.");
                    // Ŭ���� ������Ʈ�� ���̾ "Ignore Raycast"�� ����
                }
            }
        }
    }

    private void SetChildrenColor(Transform parentTransform, Color color)
    {
        // �θ� �����ϰ� ��� �ڽĵ鸸 ��ȸ (�θ� �����ϱ� ���� GetComponentsInChildren ���)
        foreach (Transform child in parentTransform.GetComponentsInChildren<Transform>())
        {
            if (child != parentTransform)  // �θ� �ڽ��� ����
            {
                Renderer childRenderer = child.GetComponent<Renderer>();
                if (childRenderer != null)
                {
                    childRenderer.material.SetColor("_BaseColor", color);  // �ڽ��� ���� ����
                }
            }
        }
    }

}
