using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;
    public float speed = 5f;
    public float gravity = -9.8f;
    public float jumpheight = 1.5f;

    



    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        FindObjectOfType<AudioManager>().StopSound("ThemeSong");
        FindObjectOfType<AudioManager>().PlaySound("GameSong");

    }

    // Update is called once per frame
    void Update()
    {
        
        isGrounded = controller.isGrounded;
    }

    //receive the input from our inputManager.cs and apply to character controller
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection)* speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if(isGrounded && playerVelocity.y < 0) { 
          
            playerVelocity.y = -2f;
        
        }
        controller.Move(playerVelocity* speed * Time.deltaTime);

    }

    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpheight * -1.5f * gravity);
        }
    }

    
}
