using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask whatIsGround;

    public float moveSpeed;
    public float jumpForce;
    public float groundCheckRadius;

    private float moveInputDirection;

    private bool isGrounded;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        CheckSurroundings();
    }

    private void FixedUpdate()
    {
        ApplyMovement();
    }

    private void ApplyMovement()
    {

     if (rb.position.x >= -3 && rb.velocity.x >= 0)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }

        if (rb.position.x >= -3 && rb.velocity.x <= 0)
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }

        if (rb.position.x >= 3)
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }

        if (rb.position.x <= -3)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }

        if (rb.position.x <= 0.1 && rb.position.x >= -0.1)
        {
            StartCoroutine(Hop());
        }

    }
    public IEnumerator Hop()
    {
        yield return new WaitForSeconds(1f);
        Jump();
    }

    public IEnumerator Right()
    {
        yield return new WaitForSeconds(1f);
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }

    public IEnumerator Left()
    {
        yield return new WaitForSeconds(1f);
        rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
    }

    private void Jump()
    {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);  
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

