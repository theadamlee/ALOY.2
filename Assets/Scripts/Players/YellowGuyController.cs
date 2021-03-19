using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowGuyController : MonoBehaviour
{
    public Transform groundCheck;
    public Transform hazardCheck;
    public Transform phaseCheck;
    public Transform phaseGroundCheck;
    public Transform phaseUpCheck;
    public LayerMask whatIsGround;
    public LayerMask whatIsHazard;
    public LayerMask whatIsPhase;
    public LayerMask whatIsPhaseGround;
    public LayerMask whatIsPhaseUp;
    private bool isDead;
    public float hazardCheckRadius;
    private bool isTouchingHazard;
    private bool isRunning;

    public float groundCheckRadius;


    private bool isGhost;
    private bool isGrounded;
    public Animator anim;

    private Rigidbody2D rb;

    public float phaseCheckDistance;
    public float phaseGroundCheckDistance;
    public float phaseUpCheckDistance;
    public float moveSpeed;
    public float jumpForce;

    private float moveInputDirection;
    private bool canMove = true;

    private bool isTouchingPhase;
    private bool isTouchingPhaseGround;
    private bool isTouchingPhaseUp;
    private bool canJump;
    private bool isFacingRight = true;
    private int facingDirection = 1;
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
        CheckMovementDirection();
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

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if (Input.GetButtonDown("Special") && isTouchingPhase && !Input.GetButton("Shift") && !Input.GetButton("Shift2"))
        {
            Phase();
        }

        if (Input.GetButtonDown("Special") && isTouchingPhaseGround && !Input.GetButton("Shift") && !Input.GetButton("Shift2"))
        {
            PhaseDown();
        }

        if (Input.GetButtonDown("Special") && isTouchingPhaseUp && !Input.GetButton("Shift") && !Input.GetButton("Shift2"))
        {
            PhaseUp();
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
        isTouchingPhase = Physics2D.Raycast(phaseCheck.position, transform.right, phaseCheckDistance, whatIsPhase);
        isTouchingPhaseGround = Physics2D.Raycast(phaseGroundCheck.position, -transform.up, phaseGroundCheckDistance, whatIsPhaseGround);
        isTouchingPhaseUp = Physics2D.Raycast(phaseUpCheck.position, transform.up, phaseUpCheckDistance, whatIsPhaseUp);
        isTouchingHazard = Physics2D.OverlapCircle(hazardCheck.position, hazardCheckRadius, whatIsHazard);

        if (isTouchingPhase || isTouchingPhaseGround || isTouchingPhaseUp)
        {
            isGhost = true;
        }
        else
            isGhost = false;
    }

    private void Phase()
    {
        transform.position = new Vector3(transform.position.x + 1.5f * facingDirection, transform.position.y);
        FindObjectOfType<SoundManagerScriptALOY>().Play("Phase");
    }

    private void PhaseDown()
    {
        FindObjectOfType<SoundManagerScriptALOY>().Play("Phase");
        transform.position = new Vector3(transform.position.x, transform.position.y - 1.7f);
    }

    private void PhaseUp()
    {
        FindObjectOfType<SoundManagerScriptALOY>().Play("Phase");
        transform.position = new Vector3(transform.position.x, transform.position.y + 2.3f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        Gizmos.DrawWireSphere(hazardCheck.position, hazardCheckRadius);
        Gizmos.DrawLine(phaseCheck.position, new Vector3(phaseCheck.position.x + phaseCheckDistance, phaseCheck.position.y, phaseCheck.position.z));
        Gizmos.DrawLine(phaseGroundCheck.position, new Vector3(phaseGroundCheck.position.x, phaseGroundCheck.position.y - phaseGroundCheckDistance, phaseGroundCheck.position.z));
        Gizmos.DrawLine(phaseUpCheck.position, new Vector3(phaseUpCheck.position.x, phaseUpCheck.position.y + phaseUpCheckDistance, phaseUpCheck.position.z));

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
        anim.SetBool("isGhost", isGhost);
        anim.SetBool("isRunning", isRunning);
    }
}

