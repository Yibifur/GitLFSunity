using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    // movement
    private CharacterController characterController;
    public float speed;
    //cameracontroller;
    private float xRotation=0f;
    public float mousesens = 10f;
    private Vector3 velocity;
    public float gravity = -10f;
    //private GameObject CheckGround;
    public Transform groundchecker;
    public float groundcheckerRadius;
    public LayerMask obstacleLayer;
    private bool IsGround;
    public float gravitydivide = 18f;
    //Player Health;
    public float playerHealth;
    public TextMeshProUGUI playerHealthInfo;
    public Slider healthSlider;
    public TextMeshProUGUI playerHealthNumber;
    //Disable Player
    public GameObject AK47;
    public GameObject crosshair;
    public GameObject gameOverMenu;
    public GameObject gameManager;
    private void Awake()//constructor method
    {
        characterController=GetComponent<CharacterController>();  
        Cursor.visible=false;
        Cursor.lockState=CursorLockMode.Locked;
        //enemy HP
        healthSlider.GetComponent<Slider>().maxValue = playerHealth;
        gameOverMenu.SetActive(false);
    }
    private void Update()
    {
        //player health info
        if (playerHealthNumber != null)
        {
            playerHealthNumber.SetText(playerHealth.ToString());
        }
        if (playerHealthInfo != null)
        {
            playerHealthInfo.SetText("Player");
        }
        healthSlider.value = playerHealth;
        if (healthSlider.value <= 0)
        {
            playerHealth = 0;
            //Destroy(gameObject);
            GetComponent<PlayerMovement>().enabled = false;
            AK47.SetActive(false);
            crosshair.SetActive(false);
            //Cursor Activate
            Cursor.visible = true;
            Cursor.lockState=CursorLockMode.None;
            //enable menu
            gameOverMenu.SetActive(true);
            gameManager.SetActive(false);
        }
        //jumping
        IsGround = Physics.CheckSphere(groundchecker.position, groundcheckerRadius, obstacleLayer);
        //movement
        Vector3 moveinputs = Input.GetAxis("Horizontal")*transform.right+Input.GetAxis("Vertical")*transform.forward;
        Vector3 Movevelocity = moveinputs * speed * Time.deltaTime;
        characterController.Move(Movevelocity);// içine girilen vektöre göre hareket edilmesini saðlar
        

        if (Input.GetKeyDown(KeyCode.Space)&&IsGround){

            velocity.y =3.0f* Mathf.Sqrt(0.25f*-0.2f*gravity/gravitydivide);    
        }
        
        if (IsGround==false){
             velocity.y +=gravity * Time.deltaTime/ gravitydivide;
            
         
        }
        characterController.Move(velocity);
    }
    private void LateUpdate()
    {
         //cameracontroller
        transform.Rotate(0, Input.GetAxis("Mouse X")*Time.deltaTime*mousesens,0);
        xRotation -= Input.GetAxis("Mouse Y") * Time.deltaTime * mousesens;
        xRotation=Mathf.Clamp(xRotation, -90f, 90f);
        Camera.main.transform.localRotation=Quaternion.Euler(xRotation,0,0);   
    }
    




}
