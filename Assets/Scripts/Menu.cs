using UnityEngine;
using System;

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("Go");
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
