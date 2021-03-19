using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YGuyController : MonoBehaviour
{
    public Transform hazardCheck;
    public LayerMask whatIsHazard;
    private bool isDead;
    public float hazardCheckRadius;
    private bool isTouchingHazard;

    private bool canMove = true;

    private Rigidbody2D rb;
    Vector2 yAxis;

  

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        yAxis = new Vector2(0, 10);

       
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hazard"))
        {
           
            rb.constraints = RigidbodyConstraints2D.None;
            Debug.Log("YOU DIED");
            canMove = false;
            isDead = true;


        }
    }

    private void CheckInput()
    {

        rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;


        rb.velocity = yAxis * Input.GetAxisRaw("Vertical");

        if (rb.velocity != Vector2.zero)
        {
            rb.velocity = yAxis * Input.GetAxisRaw("Vertical");
            rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
        }
            else
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }

            
        
    }

    private void CheckSurroundings()
    {
        isTouchingHazard = Physics2D.OverlapCircle(hazardCheck.position, hazardCheckRadius, whatIsHazard);
    }



    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(hazardCheck.position, hazardCheckRadius);
    }
}
