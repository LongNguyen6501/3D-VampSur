using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{

    public float mouseSensitivity = 300f;

    public float xRotation = 0f;
    public float yRotation = 0f;

    public float topClamp = -90f;
    public float bottomClamp = 90f;

    void Start()
    {
        //Locking Cursor
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        // Get mouse inputs
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotate around X axis (look up and down)
        xRotation -= mouseY;

        // Clamp rotation (lock rotation at 90 degree)
        xRotation = Mathf.Clamp(xRotation, topClamp, bottomClamp);

        // Rotate around y axis (look sideways)
        yRotation += mouseX;

        //Apply rotation 
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
