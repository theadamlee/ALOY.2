using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkController : MonoBehaviour
{
    public Transform groundCheck;
    public Transform ceilingCheck;
    public LayerMask whatIsGround;
    private bool isDead;
    public float ceilingCheckRadius;
    private bool isTouchingCeiling;
    private bool isRunning;

    public BoxCollider2D Shrinkcollider;
    public BoxCollider2D Hazardcollider;

    public float groundCheckRadius;

    public BoxCollider2D Headcollider;
    public GameObject HeadGround;

    private bool isShrink;
    private bool isGrounded;
    
    public Animator anim;

    private Rigidbody2D rb;

    public float miniSpeed;
    public float moveSpeed;
    public float jumpForce;
    public float miniJumpForce;

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
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        CheckSurroundings();
        CheckIfCanJump();
        Animations();
        CheckMovementDirection();
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

        if (Input.GetButton("Special") || (isTouchingCeiling && isGrounded && isShrink))
        {
            isShrink = true;
            Shrink();
            if (Shrinkcollider != null)
                Shrinkcollider.enabled = false;

            if (Headcollider != null)
                Headcollider.enabled = false;

            if (Hazardcollider != null)
                Hazardcollider.enabled = false;
            groundCheckRadius = 0.11f;
            ceilingCheckRadius = 0.09f;

          
        }
        else
        {
            isShrink = false;
            if (Shrinkcollider != null)
                Shrinkcollider.enabled = true;

            if (Hazardcollider != null)
                Hazardcollider.enabled = true;

            if (Headcollider != null)
                Headcollider.enabled = true;
            groundCheckRadius = 0.2f;
            ceilingCheckRadius = 0f;
        }


    }

    private void ApplyMovement()
    {

       rb.velocity = new Vector2(moveSpeed * moveInputDirection, rb.velocity.y);
        if (isShrink)
        {
            rb.velocity = new Vector2(miniSpeed * moveInputDirection, rb.velocity.y);
        }
    }

    private void Jump()
    {
        if (canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            amountOfJumpsLeft--;

            if (canJump && Input.GetButton("Special"))
            {
                rb.velocity = new Vector2(rb.velocity.x, miniJumpForce);
                FindObjectOfType<SoundManagerScriptALOY>().Play("Jump");
            }
            else
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
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
        else if (isTouchingCeiling && isGrounded && isShrink)
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
        isTouchingCeiling = Physics2D.OverlapCircle(ceilingCheck.position, ceilingCheckRadius, whatIsGround);
    }

    private void Shrink()
    {
        isShrink = true;
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        Gizmos.DrawWireSphere(ceilingCheck.position, ceilingCheckRadius);
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
        anim.SetBool("isShrink", isShrink);
        anim.SetBool("isRunning", isRunning);
    }
}

