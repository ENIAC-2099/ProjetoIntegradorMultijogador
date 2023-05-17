using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookArroud : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;

    float xRotation;


    private void Start()
    {
        // some com o ponteiro do mouse
        Cursor.lockState = CursorLockMode.Locked; 
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //impedir de mexer no eixo y
        xRotation -= mouseY;

        //limitar rotação da camera 
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        //movimentação da camera
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        //rotacionar o corpo no eixou y com a camera 
        playerBody.Rotate(Vector3.up * mouseX); 
    }
}
