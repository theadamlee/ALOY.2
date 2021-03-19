﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotation : MonoBehaviour
{
    

    public GameObject secretGuy;
   
    void FixedUpdate()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();

        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);

      if (rotZ <-90 || rotZ > 90)
        {



            if(secretGuy.transform.eulerAngles.y == 0)
            {

                transform.localRotation = Quaternion.Euler(180, 0, -rotZ);


            }
            else if(secretGuy.transform.eulerAngles.y == 180)
            {
                transform.localRotation = Quaternion.Euler(180, 180, -rotZ);
            }


        }
    }
}
