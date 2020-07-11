using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHand : MonoBehaviour
{
    // Variables
    public float followSpeed;
    public Sprite openHand;
    public Sprite closedHand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Follow the mouse harshly
        transform.position = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Update hand
        
    }
}
