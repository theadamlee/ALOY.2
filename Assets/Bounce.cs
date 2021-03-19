using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float bounceForce;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.rigidbody.AddForce(transform.up * bounceForce);
    }
}
