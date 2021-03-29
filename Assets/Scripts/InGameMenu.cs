using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    private GameObject menu;
    private GameObject inGameMenu;
    private GameObject settings;
    private float timeScale;

    void Start()
    {
        menu = GameObject.Find("InGameMenu");
        inGameMenu = GameObject.Find("Menu");
        settings = GameObject.Find("Settings");
        menu.SetActive(false);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            FindObjectOfType<AudioManager>().Play("confirm");
            MenuState(menu.activeSelf);
        }
    }

    private void MenuState(bool state)
    {
        if (state)
        {
            menu.SetActive(false);
            Time.timeScale = timeScale;
        }
        else if ((!state) && (Time.timeScale != 0))
        {
            timeScale = Time.timeScale;
            menu.SetActive(true);
            settings.SetActive(false);
            Time.timeScale = 0;
        }
    }

    public void Resume()
    {
        FindObjectOfType<AudioManager>().Play("confirm");
        menu.SetActive(false);
        Time.timeScale = timeScale;
    }

    public void Settings()
    {
        FindObjectOfType<AudioManager>().Play("confirm");
        inGameMenu.SetActive(false);
        settings.SetActive(true);
    }

    public void Back()
    {
        FindObjectOfType<AudioManager>().Play("confirm");
        inGameMenu.SetActive(true);
        settings.SetActive(false);
    }

    public void Menu()
    {
        FindObjectOfType<AudioManager>().Play("confirm");
        SceneManager.LoadScene("Menu");
    }

    public void Desktop()
    {
        FindObjectOfType<AudioManager>().Play("confirm");
        Application.Quit();
    }
}
