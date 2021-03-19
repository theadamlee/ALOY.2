using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCSwitchController : MonoBehaviour
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

        if (Input.GetButton("PCShift"))
        {
            transform.localPosition = new Vector3(transform.localPosition.x, 0f);
        }
        else
            transform.localPosition = new Vector3(transform.localPosition.x, 50f);
    }
}