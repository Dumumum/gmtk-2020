using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasySpin : MonoBehaviour
{
    // Variables
    public float speed;

    // Update is called once per frame
    void Update()
    {
        // Rotate the object
        transform.Rotate(Vector3.back, speed * Time.deltaTime);
    }
}
