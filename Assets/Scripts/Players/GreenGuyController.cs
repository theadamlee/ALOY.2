using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenGuyController : MonoBehaviour
{
    public Transform groundCheck;
    public Transform hazardCheck;
    public LayerMask whatIsGround;
    public LayerMask whatIsHazard;

    public BoxCollider2D greenCollider;
    public PolygonCollider2D flatCollider;

    public float groundCheckRadius;
    public float hazardCheckRadius;

    private bool isDead;
    private bool isFlat;
    private bool isGrounded;
    private bool isTouchingHazard;
    public Animator anim;
    private bool isRunning;

    private Rigidbody2D rb;

    public float flatSpeed;
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
        flatCollider.enabled = false;
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
            rb.constraints = RigidbodyConstraints2D.None;
            greenCollider.transform.localScale = new Vector3(1, 1);
            flatCollider.enabled = false;

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

        if (Input.GetButton("Special"))
        {
            Flat();
            greenCollider.transform.localScale = new Vector3(3f, 0.5f);
            rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
                flatCollider.enabled = true;
        }

        if (Input.GetButtonUp("Special"))
        {
            isFlat = false;
            greenCollider.transform.localScale = new Vector3(1, 1);
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                flatCollider.enabled = false;
        }
    }

    private void ApplyMovement()
    {

        rb.velocity = new Vector2(moveSpeed * moveInputDirection, rb.velocity.y);

        if (isFlat)
        {
            rb.velocity = new Vector2(flatSpeed * moveInputDirection, rb.velocity.y);
        }
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

    private void Flat()
    {
        isFlat = true;

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
        anim.SetBool("isFlat", isFlat);
        anim.SetBool("isRunning", isRunning);
    }
}

