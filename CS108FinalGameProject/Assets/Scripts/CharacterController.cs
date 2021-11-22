using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [Header("Movement")]
    //Physics Component
    Rigidbody2D rb2d;
    //our inputs for left and right value
    float horizontalInput;
    float moveSpeed;
    float moveLeftRight;
    Vector2 moveDirection;
    private Vector2 m_Velocity = Vector2.zero;
    [Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f; // how much to smooth out the movement
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        getPlayerInput();
    }
    public void getPlayerInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        Move(horizontalInput);
    }
    private void Move(float horizontalInput)
    {
        moveLeftRight = horizontalInput * moveSpeed;
        Vector2 targetVelocity = new Vector2(moveLeftRight, rb2d.velocity.y);
        rb2d.velocity = Vector2.SmoothDamp(rb2d.velocity, targetVelocity, ref m_Velocity, movementSmoothing);
    }
}
