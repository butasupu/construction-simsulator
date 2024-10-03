using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraControl : MonoBehaviour
{

    //https://bloodstrawberry.tistory.com/604

    private float xRotateMove, yRotateMove;
    [SerializeField] private GameObject LookAtObj;
    public float rotateSpeed;
    public float DeSpeed;

    public float ScrollSpeed = 2000f;
    public float minZoom = 5.0f;
    public float maxZoom = 20.0f;

    //public float yminLimite = 0f;
    //public float ymaxLimite = 44f;
    private void Start()
    {
        FixCamera();
    }

    private void Update()
    {
        MouseRotate();
    }

    private void MouseRotate()
    {
        Vector3 lookPosition = LookAtObj.transform.position;
        if(!IsPointerOverUIElement())
        {
            if(Input.GetMouseButton(0))
            {
                
                xRotateMove = Input.GetAxis("Mouse X") * Time.deltaTime * rotateSpeed - DeSpeed * Time.deltaTime;
            
                transform.RotateAround(lookPosition, Vector3.up, xRotateMove);
                
            }
            else
            {
                float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
            
                //Vector3 cameraDirection = this.transform.localRotation * Vector3.forward;
                //
                //this.transform.position += cameraDirection * Time.deltaTime * scrollWheel * ScrollSpeed;
            
                float distanceToTarget = Vector3.Distance(transform.position, lookPosition);
                //카메라와 lookPosition과 사이의 거리를 vector3값으로 받아오는 것
            
                Vector3 cameraDirection = (transform.position - lookPosition).normalized;
                //카메라가 LookAtObj 방향으로 이동하는 백터 계산
            
                float zoomAmount = scrollWheel * Time.deltaTime * ScrollSpeed;
                //스크롤에 따른 이동 거리 계산
            
                float newDistance = Mathf.Clamp(distanceToTarget - zoomAmount, minZoom, maxZoom);
                //줌 이후의 거리를 계산하고 범위 제한 적용
            
                transform.position = lookPosition + cameraDirection * newDistance;
                //새로운 거리를 적용하여 카메라 위치를 조정한다
            
            }
        }

    }
    private bool IsPointerOverUIElement()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    private void FixCamera()
    {
        if(GameManager.Instance.userData.stageNum[0] == 1)
        {
            minZoom = 15f;
            maxZoom = 25f;
        }
        if (GameManager.Instance.userData.stageNum[0] == 2)
        {
            minZoom = 50f;
            maxZoom = 80f;
        }
    }
}
