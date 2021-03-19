using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathControl : MonoBehaviour
{
    private bool alreadyPlayed = false;
    public int index;
    private Rigidbody2D rb;

    public GameObject player;


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "You")
        {
            StartCoroutine(ResetLevel());
            Time.timeScale = 0.5f;

            player = col.gameObject;
            rb = player.GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Dynamic;

            rb.drag = 1;
            rb.gravityScale = 10;
            
            rb.velocity = new Vector2(rb.velocity.x, 30);
            alreadyPlayed = true;
            rb.angularVelocity = 1000;
            rb.constraints = RigidbodyConstraints2D.None;     
        }
    }

    public IEnumerator ResetLevel()
        {
        if (alreadyPlayed == false)
        {

            FindObjectOfType<SoundManagerScriptALOY>().Play("Death");

        }
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(index);
        Time.timeScale = 1f;  
    }
}
