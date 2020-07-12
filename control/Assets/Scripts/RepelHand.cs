using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepelHand : MonoBehaviour
{
    // Variables
    public GameObject hand;      // The player's hand
    public float speed;          // The max speed of this object
    public float range;          // How close the hand must be for it to begin to run away
    public GameObject text;      // Regular game text
    public GameObject cutscene;  // Turns on when you grab the remote

    private bool grabbed;
    private Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // If we aren't currently grabbed
        if(!grabbed)
        {
            // find the distance
            Vector2 dir = transform.position - hand.transform.position;

            // If we are within range
            if (dir.magnitude < range)
            {
                // Randomize the direction
                dir = Random.insideUnitCircle.normalized;

                // Run away
                rigid.AddForce(dir.normalized * (range / dir.magnitude) * speed);
            }
        }
        // Begin text for the next scene
        else
        {
            // Turn on the new text
            text.SetActive(false);
            cutscene.SetActive(true);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If this is the hand, we have been grabbed
        if(collision.tag == "Hand")
        {
            grabbed = true;
        }
    }

}
