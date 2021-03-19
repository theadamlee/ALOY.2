using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeLever : MonoBehaviour
{
    [SerializeField]
    GameObject leverOn;

    [SerializeField]
    GameObject leverOff;

    public GameObject stopWall;

    private bool isOn = false;

    private bool canPress;


    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = leverOff.GetComponent<SpriteRenderer>().sprite;

    }

    private void Update()
    {
        ButtonPress();
    }
    private void ButtonPress()
    {
        if (canPress)
        {
            if (Input.GetButtonDown("Lever") && !Input.GetButton("Shift") && !Input.GetButton("Shift2"))
            {
                if (isOn)
                {
                    LeverOff();
                }
                else
                {
                    LeverOn();
                }
            }
        }


    }

    private void LeverOn()
    {
        isOn = true;
        gameObject.GetComponent<SpriteRenderer>().sprite = leverOn.GetComponent<SpriteRenderer>().sprite;
        stopWall.GetComponent<BoxCollider2D>().enabled = false;
        FindObjectOfType<SoundManagerScriptALOY>().Play("ButtonOff");
    }

    private void LeverOff()
    {
        isOn = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = leverOff.GetComponent<SpriteRenderer>().sprite;
        stopWall.GetComponent<BoxCollider2D>().enabled = true;
        FindObjectOfType<SoundManagerScriptALOY>().Play("ButtonOff");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "You")
        {
            canPress = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "You")
        {
            canPress = false;
        }
    }

}
