using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInScript : MonoBehaviour
{
    private SpriteRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
       rend = GetComponent<SpriteRenderer>();
        Color c = rend.color;
        c.a = 0f;
        rend.material.color = c;
    }

  IEnumerator FadeIn()
    {
        for (float f = 0.3f; f <= 1; f += 0.05f)
        {
            Color c = rend.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.01f);
        }
    }
    IEnumerator FadeOut()
    {
        for (float f = 1f; f >= 0.3f; f -= 0.05f)
        {
            Color c = rend.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.01f);
        }
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
        StartFadeIn();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StartFadeOut();
    }
}
