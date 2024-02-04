using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player: MonoBehaviour
{
    public CharacterController controller;
 
    public float speed = 12f;
    public float gravity = -9.81f * 2;
    public float jumpHeight = 3f;
 
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public GameObject obj;
    public GameObject fire;

    

    
 
    Vector3 velocity;
 
    bool isGrounded;
    private void Start() {
        
    }
 
    // Update is called once per frame
    void Update()
    {
        //checking if we hit the ground to reset our falling velocity, otherwise we will fall faster the next time
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
 
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
 
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
 
        //right is the red Axis, foward is the blue axis
        Vector3 move = transform.right * x + transform.forward * z;
 
        controller.Move(move * speed * Time.deltaTime);
 
        //check if the player is on the ground so he can jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //the equation for jumping
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        if (Input.GetKeyDown(KeyCode.Escape)){
            SceneManager. LoadScene (0) ;
            Cursor.lockState = CursorLockMode.Locked;   
        }
 
        velocity.y += gravity * Time.deltaTime;
 
        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.F) && CraftingSystem.Instance.FireCreated){
            Instantiate(fire,transform.position,this.transform.rotation);
            InventorySystem.Instance.RemoveItem("Fire",1);
            CraftingSystem.Instance.FireCreated = false;

        }
    }
    
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Tree" && CraftingSystem.Instance.AxeCreated){
            

            Debug.Log("Treeeee");
            obj.gameObject.GetComponent<Animator>().SetBool("axe",true);
            Destroy(other.gameObject, 1f);
            InventorySystem.Instance.AddToInventory(other.gameObject.name);
            
            Invoke("delay", 1.5f);


            
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "rabbit"){
            PlayerState.Instance.currentHealth -= 10;
        }

        if(other.gameObject.tag == "banana"){
            PlayerState.Instance.currentHealth += 5;
            Destroy(other.gameObject, 1f);

        }
    }

        
        
        
    
    

    private void delay(){
        obj.gameObject.GetComponent<Animator>().SetBool("axe",false);
    }
}