using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeGuyController : MonoBehaviour
{
    public Transform groundCheck;
    public Transform hazardCheck;
    public LayerMask whatIsGround;
    public LayerMask whatIsHazard;   
    private bool isDead;
    public float hazardCheckRadius;
    private bool isTouchingHazard;
    private bool isRunning;

    public float groundCheckRadius;

    private bool isAustralian;
    
    private bool isGrounded;
    public Animator anim;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    public float moveSpeed;
    public float jumpForce;

    private float moveInputDirection;
    private bool canMove = true;

    private bool canJump;
    private bool isFacingRight = true;
    public int amountOfJumps;
    private int facingDirection = 1;
    private int amountOfJumpsLeft;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        CheckSurroundings();
        CheckMovementDirection();
        CheckIfCanJump();
        Animations();
        GravityCheck();
    }

    private void FixedUpdate()
    {
        ApplyMovement();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hazard"))
        {
            Debug.Log("YOU DIED");
            canMove = false;
            isDead = true;

        }
    }

    private void CheckMovementDirection()
    {
        if (!isDead && (isFacingRight && moveInputDirection < 0))
        {
            Flip();
        }
        else if (!isDead && (!isFacingRight && moveInputDirection > 0))
        {
            Flip();
        }

        if (rb.velocity.x < -0.1 && isGrounded || rb.velocity.x > 0.1 && isGrounded)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
    }

    private void CheckInput()
    {
        if (canMove)
        {
            moveInputDirection = Input.GetAxisRaw("Horizontal");
        }
        

        if (rb.gravityScale > 0)
        {
            isAustralian = false;
        }

        if (rb.gravityScale < 0)
        {
            sprite.flipX = true;
        }
        else
            sprite.flipX = false;

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
            
        }

        if (Input.GetButtonDown("Special") && isGrounded)
        {
            if(isAustralian)
            {
                Canada();
                
            }
            else
            {
                Australia();
                
            }
        }

        if (Input.GetButtonDown("Special") && !isGrounded)
        {
            if (isAustralian && rb.rotation != 180)
            {
                rb.rotation = +180;
            }

            if (!isAustralian && rb.rotation != 0)
            {
                rb.rotation = 0;
            }
        }
    }

    private void GravityCheck()
    {
        if (isAustralian)
        {
            jumpForce = -20;
        }
        else
            jumpForce = 20;
    }

    private void Australia()
    {     
        rb.gravityScale = -10;
        rb.rotation = 180;
        isAustralian = true;
    }

    private void Canada()
    {
        rb.gravityScale = 10;
        rb.rotation = 0;
        isAustralian = false;  
    }

    private void ApplyMovement()
    {
        rb.velocity = new Vector2(moveSpeed * moveInputDirection, rb.velocity.y);
    }

    private void Jump()
    {
        if (canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            amountOfJumpsLeft--;
            FindObjectOfType<SoundManagerScriptALOY>().Play("Jump");
        }
    }

    private void CheckIfCanJump()
    {
        if (isGrounded && rb.velocity.y <= 0 && !isAustralian)
        {
            amountOfJumpsLeft = amountOfJumps;
        }
        if (isGrounded && rb.velocity.y >= 0 && isAustralian)
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

    private void CheckSurroundings()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        isTouchingHazard = Physics2D.OverlapCircle(hazardCheck.position, hazardCheckRadius, whatIsHazard);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        Gizmos.DrawWireSphere(hazardCheck.position, hazardCheckRadius);
    }

    private void Flip()
    {
        if (!isDead)
        {
            facingDirection *= -1;
            isFacingRight = !isFacingRight;
            transform.Rotate(0.0f, 180.0f, 0f);
        }
    }

    private void Animations()
    {
        anim.SetBool("isAustralian", isAustralian);
        anim.SetBool("isRunning", isRunning);
    }
}