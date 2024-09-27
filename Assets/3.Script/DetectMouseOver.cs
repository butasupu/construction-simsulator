using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectMouseOver : MonoBehaviour
{
    private Material material;

    private void Start()
    {
        material = GetComponent<MeshRenderer>().material;
    }
    private void Update()
    {
        DetectMouseOverObject();
    }
    private void DetectMouseOverObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray,out hit))
        {
            if(hit.transform == transform)
            {
                Debug.Log("�ʷ� ����");
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
}
