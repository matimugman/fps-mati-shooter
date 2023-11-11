using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
   
    public float MouseSensivity = 80f;

    public Transform playerBody;

    float xRotation = 0;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; 
    }

    
    void Update()
    {

        float mouseX = Input.GetAxis("Mouse X") * MouseSensivity * Time.deltaTime;

        float mouseY = Input.GetAxis("Mouse Y") * MouseSensivity * Time.deltaTime;

        xRotation += mouseY;

        xRotation = Mathf.Clamp(xRotation,90f,90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        playerBody.Rotate(Vector3.up * mouseX);

    }
}
