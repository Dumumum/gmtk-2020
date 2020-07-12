using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBag : MonoBehaviour
{
    // Variables
    public List<GameObject> cocaineBags;
    public GameObject goods;
    public int goodsCount;
    public GameObject curText;
    public GameObject nextScene;

    public int cocaineCount;
    private bool traded;
    private int goodCount;

    // Start is called before the first frame update
    void Start()
    {
        cocaineCount = 0;
        traded = false;
        goodCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Complete the trade
        if(cocaineCount >= cocaineBags.Count && !traded)
        {
            StartCoroutine(Trade());

            traded = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Money")
        {
            ++goodCount;

            // Begin loading the next level
            if (goodCount >= goodsCount)
            {
                curText.SetActive(false);
                nextScene.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Drug")
            ++cocaineCount;
    }

    private IEnumerator Trade()
    {
        yield return new WaitForSeconds(1.0f);

        // Remove all cocaine bags
        foreach (GameObject bag in cocaineBags)
            Destroy(bag);

        yield return new WaitForSeconds(1.0f);

        goods.SetActive(true);
    }
}
