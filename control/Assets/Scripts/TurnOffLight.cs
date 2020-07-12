using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffLight : MonoBehaviour
{
    // Variables
    public GameObject cutscene;
    public GameObject curText;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If this is the light, begin the end of the level
        if(collision.tag == "Light")
        {
            curText.SetActive(false);
            cutscene.SetActive(true);
        }
    }
}
