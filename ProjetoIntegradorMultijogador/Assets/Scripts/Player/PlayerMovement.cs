using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 

public class PlayerMovement : MonoBehaviour
{
    public Image derrota; 

    [Header("Atributos do jogador")]
    public CharacterController controller;
    public float speed = 6f;
    public float gravity = -10f;
    public float jumpHeight;
    public float runningSpeed = 12f;
    public GameObject player;
    public GameObject postProcessing;
    //public Camera camera; 

    [Header("Vida")]
    public float life;
    public float maxLife = 4f; 
    public Slider vida;
    [SerializeField] bool healthKit;

    [Header("Checagem do chão")]
    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;

    [Header("Knock Back")]
    [SerializeField] bool knockBack;
    public float forçaKnockBack = 10f;
    public float tempoKnockBack = 0.2f; 

    //Variaveis privadas
    Vector3 velocity;
    bool isGrounded;
    float initialSpeed;
    

    private void Start()
    {
        vida.maxValue = maxLife;
        vida.value = vida.maxValue;
        life = maxLife; 
        initialSpeed = speed;
    }

    private void Update()
    {

        //mudañça de tag
        if (life <= 0)
        {
            player.tag = "Untagged";
        }
        else
        {
            player.tag = "Player"; 
        }

        //Sistema de vida
        if(life <= 0 && healthKit == true)
        {
            life = 4;
            healthKit = false; 
        }
        else if(life <= 0f && healthKit == false)
        {
            life = 0;
            derrota.enabled = true; 
            postProcessing.SetActive(true);
            Invoke("LoadScene", 5);
            return; 
        }

        vida.value = life; 

        //Checagem do chão 
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //Aplicação da gravidade
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "kit medico")
        {
            if(healthKit == true)
            {
                return;
            }
            else
            {
                healthKit = true;
                Destroy(other.gameObject);
            }           
        }
    }

    public void Dano()
    {
      life -= 4;
    }

    void LoadScene()
    {
        SceneManager.LoadScene("Menu"); 
    }

}
