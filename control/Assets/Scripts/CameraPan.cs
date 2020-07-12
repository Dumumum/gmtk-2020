using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class CameraPan : MonoBehaviour
{
    // Variables
    public float speed;
    public float waitTime;
    public float panTime;

    private float timer;
    private bool startPan;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        startPan = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!startPan)
        {
            if (timer >= waitTime)
            {
                startPan = true;
                timer = 0.0f;
            }
        }
        else
        {
            if(timer <= panTime)
                // Move in the speed direction along x for timer
                transform.position = new Vector3(transform.position.x + (speed * Time.deltaTime), transform.position.y, transform.position.z);
        }

        timer += Time.deltaTime;
    }
}
