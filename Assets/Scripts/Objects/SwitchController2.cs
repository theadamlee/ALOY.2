using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController2 : MonoBehaviour
{
    void Update()
    {
        SwitchCheckInput();
    }

    private void FixedUpdate()
    {

    }

    private void SwitchCheckInput()
    {

        if (Input.GetButton("Shift2"))
        {
            transform.localPosition = new Vector3(transform.localPosition.x, 0f);
        }
        else
            transform.localPosition = new Vector3(transform.localPosition.x, 50f);
    }
}