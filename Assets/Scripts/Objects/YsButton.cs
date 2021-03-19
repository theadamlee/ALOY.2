using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YsButton : MonoBehaviour
{
    [SerializeField]
    GameObject buttonOn;

    [SerializeField]
    GameObject buttonOff;

    public GameObject stopWall1;
    public GameObject stopWall2;
    public GameObject stopWall3;
    public GameObject stopWall4;
    public GameObject stopWall5;
    public GameObject stopWall6;
    public GameObject stopWall7;
    public GameObject stopWall66;

    private bool isOn = false;


    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = buttonOff.GetComponent<SpriteRenderer>().sprite;

    }

    private void Update()
    {
        Press();
    }


    private void ButtonOn()
    {
        isOn = true;
        gameObject.GetComponent<SpriteRenderer>().sprite = buttonOn.GetComponent<SpriteRenderer>().sprite;
        stopWall1.GetComponent<SpriteRenderer>().enabled = false;
        stopWall2.GetComponent<SpriteRenderer>().enabled = false;
        stopWall3.GetComponent<SpriteRenderer>().enabled = false;
        stopWall4.GetComponent<SpriteRenderer>().enabled = false;
        stopWall5.GetComponent<SpriteRenderer>().enabled = false;
        stopWall6.GetComponent<SpriteRenderer>().enabled = false;
        stopWall66.GetComponent<SpriteRenderer>().enabled = false;
        stopWall7.GetComponent<SpriteRenderer>().enabled = true;
    }

    private void ButtonOff()
    {

    }

    public IEnumerator On()
    {
        yield return new WaitForSeconds(0.5f);
        ButtonOn();
    }

    private void Press()
    {
        if (Input.GetButtonDown("4") || ((Input.GetButtonDown("4C")) && (Input.GetButtonDown("Shift"))))
        {
            StartCoroutine(On());
        }
    }

}
