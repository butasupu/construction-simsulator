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
    #region 2024.09.30 수정 전 DetectMouseOverObject
    /*
    private void DetectMouseOverObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray,out hit))
        {
            if(hit.transform.parent == transform.parent)
            {
                //Debug.Log("초록 들어옴");
                //this.material.color = Color.green;
                material.SetColor("_BaseColor", Color.green);
            }
        }
        else
        {
            //this.material.color = Color.red;
            material.SetColor("_BaseColor", Color.red);  // 셰이더의 BaseColor 변경
        }
    }
    */
    #endregion
    #region 2024.09.30 수정 전 ActiveRealObject
    /*
    private void ActiveRealObject()
    {
       
        int layerMask = ~(1 << LayerMask.NameToLayer("Ignore Raycast"));  // "Ignore Raycast" 레이어를 무시하는 마스크

        if (Input.GetMouseButton(0))
        {
            Debug.Log("마우스 클릭");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.parent == transform.parent)
                {
                    
                    material.SetColor("_BaseColor", Color.green);

                    
                    if (Input.GetMouseButtonDown(0))  // 마우스 왼쪽 클릭
                    {
                        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");  // 레이어를 "Ignore Raycast"로 변경
                        material.SetColor("_BaseColor", origincolor);  // 원래 색상으로 복원
                        Debug.Log($"{hit.transform.name}가 'Ignore Raycast'로 변경되고 색상이 원래 색상으로 복원되었습니다.");
                    }
                }
            }
            else if(hit.transform.parent.gameObject.layer == 2 )
            {
                // 오브젝트에서 마우스가 벗어나면 빨간색으로 변경
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
            // 감지된 오브젝트의 부모를 가져옴
            Transform parentTransform = hit.transform.parent;

            if (parentTransform != null)  // 부모가 존재하는지 확인
            {
                SetChildrenColor(parentTransform, Color.green);  // 부모의 모든 자식들의 색상을 초록색으로 변경

            }
            else
            {
                SetChildrenColor(transform.parent, Color.red);  // 부모의 모든 자식들의 색상을 빨간색으로 복원
                Debug.Log("빨강");

            }

        }

    }

    private void ActiveRealObject()
    {
        int layerMask = ~(1 << LayerMask.NameToLayer("Ignore Raycast"));  // "Ignore Raycast" 레이어를 무시하는 마스크
        
        if (Input.GetMouseButton(0))  // 마우스 클릭 감지
        {
            Debug.Log("마우스 클릭");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // 부모가 같은지 확인
                if (hit.transform.parent == transform.parent)
                {

                    // 부모의 자식들만 색상을 원래 색상으로 복원
                    Transform parentTransform = hit.transform.parent;  // 감지된 오브젝트의 부모

                    // 자식들만 순회
                    foreach (Transform child in parentTransform)
                    {
                        // 부모 자신을 제외한 자식들만 색상 변경
                        if (child != parentTransform)  // 부모 제외
                        {
                            Renderer childRenderer = child.GetComponent<Renderer>();
                            if (childRenderer != null)
                            {
                                childRenderer.material.SetColor("_BaseColor", Color.white);  // 자식의 색상 변경
                                                                                             // SetChildrenColor(child, Color.white);  // 자식들의 색상을 원래 색상으로 복원
                                child.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
                                GameManager.Instance.PlayClip(isActiveSound);
                            }
                        }

                    }

                    Debug.Log($"{hit.transform.parent.name}의 자식들의 색상이 원래 색상으로 복원되었습니다.");

                    isActive = true;
                    Debug.Log($"{isActive} 입니다.");
                    // 클릭된 오브젝트의 레이어를 "Ignore Raycast"로 변경
                }
            }
        }
    }

    private void SetChildrenColor(Transform parentTransform, Color color)
    {
        // 부모를 제외하고 모든 자식들만 순회 (부모를 제외하기 위해 GetComponentsInChildren 사용)
        foreach (Transform child in parentTransform.GetComponentsInChildren<Transform>())
        {
            if (child != parentTransform)  // 부모 자신을 제외
            {
                Renderer childRenderer = child.GetComponent<Renderer>();
                if (childRenderer != null)
                {
                    childRenderer.material.SetColor("_BaseColor", color);  // 자식의 색상 변경
                }
            }
        }
    }

}
