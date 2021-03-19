using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    private bool isOn;

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
        CheckIfOn();
    }

    private void FixedUpdate()
    {

    }

    private void CheckIfOn()
    {
        if (bc.enabled == true)
        {
            isOn = true;
        }
        else
            isOn = false;


    }

    private void Animations()
    {
        anim.SetBool("isOn", isOn);
    }
}

