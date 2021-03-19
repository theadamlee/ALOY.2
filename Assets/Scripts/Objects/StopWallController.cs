using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopWallController : MonoBehaviour
{
    private bool isClosed;

    public Animator anim;

    private BoxCollider2D bc;

    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Animations();
        CheckIfClosed();
    }

    private void FixedUpdate()
    {

    }

    private void CheckIfClosed()
    {
        if (bc.enabled == true)
        {
            isClosed = true;
        }
        else
            isClosed = false;


    }

    private void Animations()
    {
        anim.SetBool("isClosed", isClosed);
    }
}

