using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteButton : MonoBehaviour
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
        stopWall.GetComponent<SpriteRenderer>().enabled = false;
        FindObjectOfType<SoundManagerScriptALOY>().Play("ButtonOff");
    }

    private void ButtonOff()
    {
        isOn = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = buttonOff.GetComponent<SpriteRenderer>().sprite;
        stopWall.GetComponent<SpriteRenderer>().enabled = true;
        FindObjectOfType<SoundManagerScriptALOY>().Play("ButtonOff");
    }

    public IEnumerator Off()
    {
        yield return new WaitForSeconds(0.5f);
        ButtonOff();
    }

    public IEnumerator On()
    {
        yield return new WaitForSeconds(0.5f);
        ButtonOn();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(On());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

    }

}
