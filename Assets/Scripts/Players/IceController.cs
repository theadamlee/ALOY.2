using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceController : MonoBehaviour
{
    public Transform groundCheck;
    public Transform hazardCheck;
    public LayerMask whatIsGround;
    public LayerMask whatIsHazard;
    private bool isDead;
    public float hazardCheckRadius;
    private bool isTouchingHazard;

    public float groundCheckRadius;

    private bool isFrozen;
    private bool isGrounded;
    private bool isRunning;
    public Animator anim;

    private Rigidbody2D rb;
    private ParticleSystem snow;

    public float moveSpeed;
    public float jumpForce;

    private bool canMove = true;
    private float moveInputDirection;

    private bool isFacingRight = true;
    private int facingDirection = 1;

    private bool canJump;
    public int amountOfJumps;
    private int amountOfJumpsLeft;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        snow = GetComponent<ParticleSystem>();
        snow.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        CheckMovementDirection();
        CheckSurroundings();
        CheckIfCanJump();
        Animations();
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

            Melt();
                
        }
    }

    private void CheckInput()
    {
        if (canMove)
        {

        moveInputDirection = Input.GetAxisRaw("Horizontal");

        }

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if (Input.GetButtonDown("Special") && !Input.GetButton("Shift") && !Input.GetButton("Shift2"))
        {
            if (!isFrozen && !isDead)
            {
                Freeze();
            }
            else
            Melt();
        }


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
        if (isGrounded && rb.velocity.y <= 0)
        {
            amountOfJumpsLeft = amountOfJumps;
        }

        if (amountOfJumpsLeft <= 0)
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

    private void Freeze()
    {
        isFrozen = true;
        snow.Play();
        rb.bodyType = RigidbodyType2D.Static;
        FindObjectOfType<SoundManagerScriptALOY>().Play("Freeze");
    }

    private void Melt()
    {
        isFrozen = false;
        snow.Stop();
        rb.bodyType = RigidbodyType2D.Dynamic;
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

    private void Animations()
    {
        anim.SetBool("isFrozen", isFrozen);
        anim.SetBool("isRunning", isRunning);
    }
}

