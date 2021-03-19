using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLever : MonoBehaviour
{
    [SerializeField]
    GameObject leverOn;

    [SerializeField]
    GameObject leverOff;

    public GameObject source;

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
        source.GetComponent<AudioSource>().enabled = true;
    }

    private void LeverOff()
    {
        isOn = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = leverOff.GetComponent<SpriteRenderer>().sprite;
        source.GetComponent<AudioSource>().enabled = false;
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
