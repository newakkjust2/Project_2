using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    public  Vector3 offset;
    [SerializeField] private float rotateSpeed;
    public Transform pivot;
    //Camera follows player and hide cursor during play
    private void Start()
    {
        offset = target.position - transform.position;

        pivot.transform.position = target.transform.position;
        
        pivot.transform.parent = target.transform;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void LateUpdate()
    {
        //Get the x and y position oif the mouse and rotate the target
        float hor = Input.GetAxis("Mouse X") * rotateSpeed;
        target.Rotate(0.0f, hor, 0.0f);

        float ver = Input.GetAxis("Mouse Y") * rotateSpeed;
        pivot.Rotate(ver, 0.0f, 0.0f);


        //Move the camera based on the current rotation of the target and the original offset
        float desiredYAngle = target.eulerAngles.y;
        float desiredXAngle = pivot.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0.0f);
        transform.position = target.position - (rotation * offset);
        if(transform.position.y < target.position.y)
        {
            transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
        }
        transform.LookAt(target);
    }
}
