using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPress : MonoBehaviour
{
    // Variables
    public string input;       // What will be inputted
    public Text inputField;    // Where input will be placed
    public bool delete;        // If this key is a backspace

    public void AddKey()
    {
        if (delete)
            inputField.text = inputField.text.Substring(0, inputField.text.Length - 1);
        else
            inputField.text += input;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<BaseHand>() && other.gameObject.GetComponent<BaseHand>().IsGrabbing())
            // Input the key
            AddKey();
    }

}
