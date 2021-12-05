using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;



    public float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;
    int jumpClickCount = 0;
    // Start is called before the first frame update
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        // Keeps same speed in each horizontal direction
        controller.animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        // Jump control and animation
        if (Input.GetKeyDown(KeyCode.K))
        {

            jump = true;
            jumpClickCount += 1;
            if (jumpClickCount == 1)
            {
                controller.animator.SetBool("IsJumping", true);
            }
            else if (jumpClickCount > 1)
            {
                controller.animator.SetBool("IsJumping", false);
            }


        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            crouch = true;
        }


    }

    public void OnLanding()
    {
        jumpClickCount = 0;
        controller.animator.SetBool("IsJumping", false);
    }

    /*   public void OnCrouching (bool isCrouching) {
          animator.SetBool("IsCrouching", isCrouching);
      } */

    // Update is called once per frame
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }


}
