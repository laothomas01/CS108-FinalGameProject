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
    private float groundCheckRadius;
    Vector2 moveDirection;
    private Vector2 m_Velocity = Vector2.zero;
    [Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f; // how much to smooth out the movement

    //direction character is facing

    private bool isFacingRight = true;
    private bool isGrounded;


    public Transform groundCheck;

    public LayerMask whatIsGround;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        getPlayerInput();
        CheckMovementDirection();

    }
    void FixedUpdate()
    {
        Move(horizontalInput);
    }
    public void getPlayerInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");

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
    private void onDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
