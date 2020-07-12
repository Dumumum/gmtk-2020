using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountMoney : MonoBehaviour
{
    // Variables
    public Text count;  // What displays our count
    public int goal;    // The goal number of bills to store
    public float moneyTime;  // How long they have to put the money away

    private int curCount;
    private CutsceneTimer cont;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        curCount = 0;
        cont = GetComponent<CutsceneTimer>();
        timer = 0.0f;
    }

    private void Update()
    {
        if (timer >= moneyTime)
            cont.enabled = true;

        timer += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If it's money, save it and remove the bill
        if(collision.tag == "Money")
        {
            ++curCount;

            count.text = curCount.ToString();

            Destroy(collision.gameObject);

            // Check if we should continue
            if (curCount >= goal)
                cont.enabled = true;
        }
    }
}
