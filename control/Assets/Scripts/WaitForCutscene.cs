using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForCutscene : MonoBehaviour
{
    // Variables
    public float waitTime;
    public GameObject curText;
    public GameObject cutscene;
    public GameObject smoke;
    public GameObject car;
    public GameObject soundCar;

    private float timer;

    private void Start()
    {
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // If it is time to start the cutscene
        if(timer >= waitTime)
        {
            curText.SetActive(false);
            smoke.SetActive(true);
            smoke.GetComponent<ParticleSystem>().Play();
            cutscene.SetActive(true);
            soundCar.SetActive(false);

            // Turn off wheels
            foreach (WheelJoint2D wheel in car.GetComponents<WheelJoint2D>())
                wheel.useMotor = false;
        }

        timer += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If this is the light, begin the end of the level
        if (collision.tag == "Light")
        {
            curText.SetActive(false);
            cutscene.SetActive(true);
        }
    }
}
