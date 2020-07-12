using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    // Variables
    public string level;

    public void StartGame()
    {
        SceneManager.LoadScene(level);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
