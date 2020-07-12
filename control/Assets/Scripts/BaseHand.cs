using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHand : MonoBehaviour
{
    // Variables
    public float followSpeed;
    public float range;
    public Sprite openHand;
    public Sprite closedHand;

    private bool isGrab;
    private Rigidbody2D rigid;
    private CircleCollider2D circle;
    private List<DistanceJoint2D> hinges;

    private void Start()
    {
        // Prep our variables
        isGrab = false;
        rigid = GetComponent<Rigidbody2D>();
        circle = GetComponent<CircleCollider2D>();
        circle.enabled = false;
        hinges = new List<DistanceJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check this frame if we are grabbing
        if (Input.GetMouseButtonDown(0))
            isGrab = true;
        else
            isGrab = false;

        // Grabbing something
        if (Input.GetMouseButton(0))
        {
            // Change sprite
            GetComponent<SpriteRenderer>().sprite = closedHand;

            // Check for objects to grab
            circle.enabled = true;
        }
        // Open sesame
        else
        {
            GetComponent<SpriteRenderer>().sprite = openHand;

            // If we have hinges, remove all of them
            if (hinges.Count > 0)
            {
                while(hinges.Count > 0)
                {
                    Destroy(hinges[0]);
                    hinges.RemoveAt(0);
                }
            }

            // Deparent and reset all children
            for(int i = 0; i < gameObject.transform.childCount; ++i)
            {
                GameObject temp = gameObject.transform.GetChild(i).gameObject;

                temp.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                temp.GetComponent<Rigidbody2D>().velocity = rigid.velocity;
                temp.transform.parent = null;
            }

            // Check for objects to grab
            circle.enabled = false;
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Only check on frame 1
        if(isGrab)
        {
            // If we can grab this
            if (other.GetComponent<Grabbable>() && other.GetComponent<Grabbable>().grab)
            {
                // Lock to parent and make kinematic
                other.transform.parent = this.transform;

                // If this item should pivot around
                if(other.GetComponent<Grabbable>().pivot)
                {
                    // Attach by a hinge
                    DistanceJoint2D hinge = gameObject.AddComponent<DistanceJoint2D>();

                    // Set up the base variables
                    hinge.connectedBody = other.gameObject.GetComponent<Rigidbody2D>();
                    //ColliderDistance2D dist = Physics2D.Distance(other, gameObject.GetComponent<CircleCollider2D>());
                    //hinge.anchor = dist.pointB;
                    //hinge.connectedAnchor = dist.pointB;
                    hinge.maxDistanceOnly = true;

                    // Save for later
                    hinges.Add(hinge);
                }
                else
                {
                    other.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                }
            }
        }
    }

    public bool IsGrabbing()
    {
        return isGrab;
    }

}
