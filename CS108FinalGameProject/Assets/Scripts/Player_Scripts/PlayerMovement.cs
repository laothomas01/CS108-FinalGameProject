using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;


    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;
    // Start is called before the first frame update
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        // Keeps same speed in each horizontal direction
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        // Jump control and animation
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (controller.m_Grounded != false)
            {
                jump = true;
                animator.SetBool("IsJumping", true);
            }
            else
            {
                jump = false;
                animator.SetBool("IsJumping", false);
            }


        }
        /*  if (Input.GetKey(KeyCode.LeftControl))
         {
             crouch = true;
         } */

        //Debug.Log("MOVING:" + controller.m_IsMoving);

        /*  if (Input.GetButtonDown("Crouch")) {
             crouch = true;
         } else if (Input.GetButtonUp("Crouch")) {
             crouch = false;
         } */
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
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
