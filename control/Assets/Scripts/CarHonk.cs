using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarHonk : MonoBehaviour
{
    // Variables
    public GameObject soundHonk;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If it was the player, honk
        if (collision.gameObject.tag == "Car")
            soundHonk.SetActive(true);
    }

}
