using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneTimer : MonoBehaviour
{
    // Variables
    public float cutsceneLength;
    public string level;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > cutsceneLength)
            SceneManager.LoadScene(level);

        timer += Time.deltaTime;
    }
}
