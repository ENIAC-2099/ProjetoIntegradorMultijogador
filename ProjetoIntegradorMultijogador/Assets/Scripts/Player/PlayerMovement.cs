using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Atributos Player
    public CharacterController controller;
    public float speed = 6f;
    public float gravity = -10f;
    public float jumpHeight;
    public float runningSpeed = 12f; 


    //Checar Ch�o
    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask; 

    //Variaveis privadas
    Vector3 velocity;
    bool isGrounded;
    float initialSpeed; 

    private void Start()
    {
        initialSpeed = speed; 
    }

    private void Update()
    {
        //Checagem do ch�o 
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //Aplica��o da gravidade
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; 
        }

        //Correndo
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runningSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = initialSpeed; 
        }

        //Pulo
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); 
        }

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
