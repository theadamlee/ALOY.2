using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretGuyController : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform groundCheck;
   
    public LayerMask whatIsGround;
   
    private bool isDead;
    
   
    private bool canMove = true;

    public float moveSpeed;
    public float jumpForce;
    public float groundCheckRadius;

    private float moveInputDirection;
    private bool isFacingRight = true;
    private int facingDirection = 1;

    private bool isGrounded;
    private bool canJump;
    public int amountOfJumps;
    private int amountOfJumpsLeft;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        CheckSurroundings();
        CheckIfCanJump();

    }

    private void FixedUpdate()
    {
        ApplyMovement();
    }


    private void CheckInput()
    {
       
       moveInputDirection = Input.GetAxisRaw("Horizontal");
        


        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

    }

    private void ApplyMovement()
    {

        rb.velocity = new Vector2(moveSpeed * moveInputDirection, rb.velocity.y);

    }

    private void CheckIfCanJump()
    {
        if (isGrounded && rb.velocity.y <= 0)
        {
            amountOfJumpsLeft = amountOfJumps;
        }

        if (isGrounded)
        {
            canJump = true;
        }

        if (amountOfJumpsLeft <= 0 && !isGrounded)
        {
            canJump = false;
        }

        else
        {
            canJump = true;
        }
    }

    private void Jump()
    {
        if (canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            amountOfJumpsLeft--;

        }

    }
    private void CheckSurroundings()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        
    }

}
