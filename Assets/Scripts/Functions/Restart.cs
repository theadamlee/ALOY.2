using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public int index;

    void Update()
    {
        if (Input.GetButtonDown("Restart"))
        {
            SceneManager.LoadScene(index);
            Time.timeScale = 1f;
        }

        if (Input.GetButtonDown("Restart") && Input.GetButton("PCShift"))
        {
            Time.timeScale = 1.5f;
        }
    }
}
