﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnzipBag : MonoBehaviour
{
    // Variables
    public GameObject openBag;
    public GameObject thisBag;

    public void OpenBag()
    {
        openBag.SetActive(true);
        thisBag.SetActive(false);

        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Money")
            OpenBag();
    }
}