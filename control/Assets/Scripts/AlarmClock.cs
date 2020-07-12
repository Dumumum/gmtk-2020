using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlarmClock : MonoBehaviour
{
    // Variables
    public Sprite brokenClock;
    public float breakTimer;
    public string nextScene;
    public GameObject soundAlarm;
    public GameObject soundShatter;

    public bool boxFirst;  // Has the box collider been hit first?
    private bool isBroken;  // When the sprite should be broken
    private float timer;    // Tracks when to load the next scene
    private BoxCollider2D box;  // Holds our box collider
    private CircleCollider2D circle;  // Holds the circle collider
    private SpriteRenderer sprite;  // Holds the sprite

    // Start is called before the first frame update
    void Start()
    {
        boxFirst = false;
        isBroken = false;
        timer = 0.0f;
        box = GetComponent<BoxCollider2D>();
        circle = GetComponent<CircleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // If the clock is broken, prepare for next level
        if(isBroken)
        {
            sprite.sprite = brokenClock;
            timer += Time.deltaTime;

            // If it is time for the next scene
            if(timer >= breakTimer)
            {
                SceneManager.LoadScene(nextScene);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If box is touching
        if(box.IsTouching(collision))
        {
            boxFirst = true;
        }
        // If body is touching
        else if(circle.IsTouching(collision))
        {
            // If we came from above, destroy clock
            if(boxFirst)
            {
                // The clock is broken
                isBroken = true;

                // Manage sounds
                soundAlarm.SetActive(false);
                soundShatter.SetActive(true);
            }

            boxFirst = false;
        }

    }

}
