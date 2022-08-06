using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float playerMoveSpeed = 5.0f;
    public float playerRotateSpeed = 50f;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private float gravityValue = -9.81f;

    private float jumpHeight = 10.0f;
    private bool groundedPlayer;

    public GameObject inGameMenu;

    Animator anim;
   

    // Start is called before the first frame update
    void Start()
    {
        controller = this.GetComponent<CharacterController>();
        anim = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 moveDir = gameObject.transform.TransformDirection(Vector3.forward);
        // move fowrad
        if(Input.GetAxis("Vertical") > 0)
        {
            controller.Move(moveDir * Time.deltaTime * playerMoveSpeed);
            anim.SetInteger("walk", 1);
            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                anim.SetBool("run", true);
                playerMoveSpeed = 10f;
            }
        }

        // move backward
        else if (Input.GetAxis("Vertical") < 0)
        {
            controller.Move(-moveDir * Time.deltaTime * playerMoveSpeed);
        } else
        {
            anim.SetInteger("walk", 0);
            anim.SetBool("run", false);
            playerMoveSpeed = 5f;
        }
        // rotate left
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * playerRotateSpeed);
        }
        // rotate right
        else if (Input.GetAxis("Horizontal") < 0)
        {
            transform.Rotate(-Vector3.up * Time.deltaTime * playerRotateSpeed);
        }

        //jump
        if (Input.GetButtonDown("Jump"))
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);

            anim.SetTrigger("jump");
            
        }

        if(playerVelocity.y < -2)
        {
            anim.SetBool("falling", true);
        } else
        {
            anim.SetBool("falling", false);
        }
        // gravity affects player
        playerVelocity.y += gravityValue * Time.deltaTime;
        playerVelocity.x = 0;
        // playerVelocity.z = 0;
        controller.Move(playerVelocity * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            inGameMenu.SetActive(true);
        }
    }
    
}
