using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
    public int index;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("You"))
        {
            SceneManager.LoadScene(index);
            FindObjectOfType<SoundManagerScriptALOY>().Play("Goal");
        }
    }
}
