using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField]
    GameObject buttonOn;

    [SerializeField]
    GameObject buttonOff;

    public GameObject stopWall;

    private bool isOn = false;


    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = buttonOff.GetComponent<SpriteRenderer>().sprite;
        
    }

    private void Update()
    {
      
    }
  

    private void ButtonOn()
    {
        isOn = true;
        gameObject.GetComponent<SpriteRenderer>().sprite = buttonOn.GetComponent<SpriteRenderer>().sprite;
        stopWall.GetComponent<BoxCollider2D>().enabled = false;
        FindObjectOfType<SoundManagerScriptALOY>().Play("ButtonOff");
    }

    private void ButtonOff()
    {
        isOn = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = buttonOff.GetComponent<SpriteRenderer>().sprite;
        stopWall.GetComponent<BoxCollider2D>().enabled = true;
        FindObjectOfType<SoundManagerScriptALOY>().Play("ButtonOff");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {               
            ButtonOn();      
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
            ButtonOff();
    }

}
