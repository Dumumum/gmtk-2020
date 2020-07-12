using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamenBowl : MonoBehaviour
{
    // Variables
    public GameObject win;

    public bool spoon;
    public bool ramen;
    public bool water;

    // Start is called before the first frame update
    void Start()
    {
        spoon = false;
        ramen = false;
        water = false;
    }

    // Update is called once per frame
    void Update()
    {
        // If we have made ramen
        if (spoon && ramen && water)
            win.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check the tag on something that entered the bowl
        switch(other.gameObject.tag)
        {
            case "Spoon":
                spoon = true;
                break;
            case "Ramen":
                ramen = true;
                break;
            case "Water":
                water = true;
                break;
            default:
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Check the tag on something that entered the bowl
        switch (collision.gameObject.tag)
        {
            case "Spoon":
                spoon = false;
                break;
            case "Ramen":
                ramen = false;
                break;
            case "Water":
                water = false;
                break;
            default:
                break;
        }
    }

}
