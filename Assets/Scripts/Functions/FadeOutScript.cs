using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutScript : MonoBehaviour
{
    private bool hasCollided;

    private SpriteRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
       rend = GetComponent<SpriteRenderer>();
        Color c = rend.color;
        c.a = 1f;
        rend.material.color = c;
    }

  IEnumerator FadeIn()
    {
        for (float f = 0f; f <= 1; f += 0.05f)
        {
            Color c = rend.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.01f);
        }
        hasCollided = false;
    }
    IEnumerator FadeOut()
    {
        for (float f = 1f; f >= -0.5f; f -= 0.05f)
        {
            Color c = rend.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.01f);
        }
        hasCollided = true;
    }

    public void StartFadeIn()
    {
        StartCoroutine(FadeIn());
    }

    public void StartFadeOut()
    {
        StartCoroutine(FadeOut());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasCollided)
        {
            StartFadeOut();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       //8====D
    }
}
