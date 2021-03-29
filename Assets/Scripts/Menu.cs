using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void StartGame()
    {
        FindObjectOfType<AudioManager>().Play("confirm");
        SceneManager.LoadScene("Game");
    }

    public void Setting()
    {
        FindObjectOfType<AudioManager>().Play("confirm");
        SceneManager.LoadScene("Setting");
    }

    public void AppQuit()
    {
        FindObjectOfType<AudioManager>().Play("confirm");
        Application.Quit();
    }

    public void BackToMenu()
    {
        FindObjectOfType<AudioManager>().Play("confirm");
        SceneManager.LoadScene("Menu");
    }

    public void OpenFreeSound()
    {
        FindObjectOfType<AudioManager>().Play("confirm");
        Application.OpenURL("https://freesound.org/");
    }
}
