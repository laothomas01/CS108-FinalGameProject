using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [Header("Movement")]
    //Physics Component
    Rigidbody2D rb2d;
    //our inputs for left and right value
    private float horizontalInput;
    [SerializeField]
    private float moveSpeed;
    private float movementInputDirection;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float groundCheckRadius;
    Vector2 moveDirection;
    private Vector2 m_Velocity = Vector2.zero;
    [Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f; // how much to smooth out the movement

    //direction character is facing

    private bool isFacingRight = true;
    public bool isGrounded;
    public bool canJump;

    public Transform groundCheck;

    public LayerMask whatIsGround;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CheckPlayerInput();
        CheckMovementDirection();
        CheckIfCanJump();
    }

    private void CheckIfCanJump()
    {
        if (isGrounded && rb2d.velocity.y <= 0.01f)
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }
    }
    void FixedUpdate()
    {
        Move(horizontalInput);
        CheckSurroundings();
    }
    public void CheckPlayerInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

    }
    private void Move(float horizontalInput)
    {
        movementInputDirection = horizontalInput * moveSpeed;
        Vector2 targetVelocity = new Vector2(movementInputDirection, rb2d.velocity.y);
        rb2d.velocity = Vector2.SmoothDamp(rb2d.velocity, targetVelocity, ref m_Velocity, movementSmoothing);
    }
    private void CheckMovementDirection()
    {
        if (isFacingRight && movementInputDirection < 0)
        {
            Flip();
        }
        else if (!isFacingRight && movementInputDirection > 0)
        {
            Flip();
        }
    }
    /*
     * Will be used to check walls. Dont want to stick to walls. 
     */
    private void CheckSurroundings()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(new Vector3(0, 180, 0));

    }
    private void Jump()
    {
        if (canJump)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        }
    }
    private void OnDrawGizmos()  // note the spelling "Gizmos"
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
            
    }

}
