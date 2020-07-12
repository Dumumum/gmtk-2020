using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimedFade : MonoBehaviour
{
    // Variables
    public bool toTransparent;  // If true, go from opaque to transparent
    public float waitTime;      // The time to wait before fading
    public float fadeSpeed;     // The speed to fade away
    public GameObject otherObj; // Other object to optionally turn on

    private Image picture;
    private SpriteRenderer picture2;
    private float timer;
    private bool working;

    // Start is called before the first frame update
    void Start()
    {
        picture = GetComponent<Image>();
        picture2 = GetComponent<SpriteRenderer>();
        timer = 0.0f;
        working = false;
    }

    // Update is called once per frame
    void Update()
    {
        // If it's time to fade
        if(!working && timer >= waitTime)
        {
            StartCoroutine(Fade());
        }

        // Update timer
        timer += Time.deltaTime;
    }

    private IEnumerator Fade()
    {
        // Don't call this again
        working = true;
        // Turn on optional object
        if (otherObj)
            otherObj.SetActive(true);

        // If we want to fade out
        if(toTransparent)
        {
            // Loop until the image is transparent
            for (float i = 1; i >= 0; i -= (Time.deltaTime / fadeSpeed))
            {
                // Set the new color
                if(picture)
                    picture.color = new Color(picture.color.r, picture.color.g, picture.color.b, i);
                else
                    picture2.color = new Color(picture2.color.r, picture2.color.g, picture2.color.b, i);

                yield return null;
            }

            // Set the new color
            if (picture)
                picture.color = new Color(picture.color.r, picture.color.g, picture.color.b, 0);
            else
                picture2.color = new Color(picture2.color.r, picture2.color.g, picture2.color.b, 0);
        }
        else
        {
            // Loop until the image is opaque
            for (float i = 0; i <= 1; i += (Time.deltaTime / fadeSpeed))
            {
                // Set the new color
                if (picture)
                    picture.color = new Color(picture.color.r, picture.color.g, picture.color.b, i);
                else
                    picture2.color = new Color(picture2.color.r, picture2.color.g, picture2.color.b, i);

                yield return null;
            }

            // Set the new color
            if (picture)
                picture.color = new Color(picture.color.r, picture.color.g, picture.color.b, 1);
            else
                picture2.color = new Color(picture2.color.r, picture2.color.g, picture2.color.b, 1);
        }

    }
}
