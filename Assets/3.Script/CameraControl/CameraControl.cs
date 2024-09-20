using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Update()
    {
        MouseRotate();
    }

    private void MouseRotate()
    {
        Vector3 lookPosition = LookAtObj.transform.position;
        if(Input.GetMouseButton(0))
        {
            Debug.Log("입력 됨");
            xRotateMove = Input.GetAxis("Mouse X") * Time.deltaTime * rotateSpeed - DeSpeed * Time.deltaTime;
            //yRotateMove = Input.GetAxis("Mouse Y") * Time.deltaTime * rotateSpeed - DeSpeed * Time.deltaTime;

            //Vector3 currentRotation = transform.eulerAngles;

            //currentRotation.x -= yRotateMove;
            //currentRotation.x = Mathf.Clamp(currentRotation.x,yminLimite,ymaxLimite);

            //currentRotation.y += xRotateMove;
            //
            //transform.eulerAngles = currentRotation;
            
            //transform.RotateAround(lookPosition, Vector3.right, -yRotateMove);
            transform.RotateAround(lookPosition, Vector3.up, xRotateMove);
            Debug.Log("입력 나감");
        }
        else
        {
            float scrollWheel = Input.GetAxis("Mouse ScrollWheel");

            Vector3 cameraDirection = this.transform.localRotation * Vector3.forward;

            this.transform.position += cameraDirection * Time.deltaTime * scrollWheel * ScrollSpeed;
        }
        //else if(Input.GetMouseButton(1))
        //{
        //    yRotateMove = Input.GetAxis("Mouse Y") * Time.deltaTime * rotateSpeed - DeSpeed * Time.deltaTime;
        //    transform.RotateAround(lookPosition, Vector3.right, -yRotateMove);
        //}
    }

}
