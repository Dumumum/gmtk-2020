using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OfficeJob : MonoBehaviour
{
    // Variables
    public float jobTime;
    public Text prompt;
    public GameObject win;
    public GameObject lose;

    private bool done;
    private Text ourText;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        done = false;
        ourText = GetComponent<Text>();
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(!done)
        {
            // If our job is over
            if (timer >= jobTime)
            {
                lose.SetActive(true);
                done = true;
            }

            // If we finished our job
            if (ourText.text == prompt.text)
            {
                win.SetActive(true);
                done = true;
            }

            timer += Time.deltaTime;
        }

    }
}
