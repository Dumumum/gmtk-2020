using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingText : MonoBehaviour
{
    // Variables
    public float textSpeed;     // The time inbetween letters
    public float fadeSpeed;     // Time it takes to fade
    public List<string> lines;  // The lines to display
    public List<float> delay;   // The time after the line is completed to show it for

    private Text textBox;   // Where to display the text
    private int curLine;    // The line we are using
    private bool isTyping;  // Currently displaying letters at a time
    private bool working;   // Currently in a coroutine

    // Start is called before the first frame update
    void Start()
    {
        textBox = GetComponent<Text>();
        curLine = 0;
        isTyping = true;
        working = false;
    }

    // Update is called once per frame
    void Update()
    {
        // While we still have lines, continue updating
        if(curLine < lines.Count)
        {
            // If we aren't doing a coroutine
            if(!working)
            {
                // We will start typing the box
                if (isTyping)
                {
                    StartCoroutine(Scroll(lines[curLine]));
                }
                // Hold the text box
                else
                {
                    StartCoroutine(HoldLine(delay[curLine]));
                }
            }
        }
        // Fade away the text or something
        else
        {
            if(!working)
            {
                StartCoroutine(FadeText());
            }
        }
    }

    private IEnumerator Scroll(string line)
    {
        // Tracks our current letter showing
        int letter = 0;
        working = true;

        // Prepare our text to type out
        textBox.text = "";
        //isTyping = true;

        // While we can show more letters
        while(letter < line.Length - 1)
        {
            // Add the next letter and move forward
            textBox.text += line[letter];
            ++letter;

            // Wait to add our next letter
            yield return new WaitForSeconds(textSpeed);
        }

        // We have finished the line
        textBox.text = line;
        isTyping = false;
        working = false;
    }

    private IEnumerator HoldLine(float delay)
    {
        // We are now holding a line
        working = true;

        yield return new WaitForSeconds(delay);

        // We have finished holding
        isTyping = true;
        working = false;
        ++curLine;
    }

    private IEnumerator FadeText()
    {
        // Lock other coroutines from running
        working = true;

        // Loop until the text is transparent
        for(float i = 1; i >= 0; i -= (Time.deltaTime / fadeSpeed))
        {
            // Set the new color
            textBox.color = new Color(textBox.color.r, textBox.color.g, textBox.color.b, i);
            yield return null;
        }
    }

}
