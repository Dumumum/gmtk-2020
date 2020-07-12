using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    // Variables
    public GameObject obj;
    public float followTime;

    private float timer;
    private Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        // Follow the object
        if (timer <= followTime)
        {
            Vector3 temp = new Vector3(obj.transform.position.x, obj.transform.position.y, transform.position.z);

            transform.position = temp;
        }
        else
        {
            if (anim && anim.isPlaying == false)
            {
                anim.enabled = true;
                anim.Play();
            }
        }

        timer += Time.deltaTime;
    }
}
