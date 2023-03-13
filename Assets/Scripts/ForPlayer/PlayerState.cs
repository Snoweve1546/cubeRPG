using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    //之後會用到的狀態機，裡面包含:預設、接訊息、死亡、僵持
    [SerializeField] enum State {
        idle,
        quest,
        death,
        impasse
    }
    [SerializeField] CharacterController controller;
    [Header("Movement")]
    [SerializeField] float speed = 15f;
    [Header("Gravity")]
    [SerializeField] float gravity = -9.8f;
    [SerializeField] Vector3 velocity;
    [Header("Ground Check")]
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundMask;
    [SerializeField] float groundDistance =0.4f;
    [SerializeField] bool isGrounded;
    [Header("Juup")]
    [SerializeField] float jumpheight;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GroundCheck();
        Gravity();
        Movement();
        Jump();
    }
    private void Movement()
    {
        //key(A、D)
        float x = Input.GetAxis("Horizontal");
        //key(W、S)
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right* x + transform.forward * z;
        controller.Move(move*speed*Time.deltaTime);
    }
    private void Gravity()
    {
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity*Time.deltaTime);
    }
    private void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position,groundDistance,groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
    }
    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);
        }
    }
}
