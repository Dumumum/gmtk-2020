using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCursor : MonoBehaviour
{
    // Variables
    //private Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        //rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Tightly hug the cursor
        Vector2 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = newPos;
    }
}
