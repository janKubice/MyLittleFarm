using UnityEngine;
using UnityEngine.UI;
using System;

public class Settings : MonoBehaviour
{
    private Text ScreenModeButtonText;
    private bool isFullScreen;


    public void setWVGA()
    {
        FindObjectOfType<AudioManager>().Play("confirm");
        Screen.SetResolution(854, 480, isFullScreen);
    }

    public void setHD()
    {
        FindObjectOfType<AudioManager>().Play("confirm");
        Screen.SetResolution(1280, 720, isFullScreen);
    }

    public void setFHD()
    {
        FindObjectOfType<AudioManager>().Play("confirm");
        Screen.SetResolution(1920, 1080, isFullScreen);
    }

    public void set1660x900()
    {
        FindObjectOfType<AudioManager>().Play("confirm");
        Screen.SetResolution(1600, 900, isFullScreen);
    }

    public void ScreenMode()
    {
        if (ScreenModeButtonText == null)
        {
            try
            {
                ScreenModeButtonText = GameObject.Find("ScreenModeButtonText").GetComponent<Text>();
            }
            catch (Exception e)
            {
                print("Požadovaný objekt se nenašel na scéně.\n" + e);
            }
        }

        if (!Screen.fullScreen)
        {
            FindObjectOfType<AudioManager>().Play("confirm");
            Screen.fullScreen = true;
            isFullScreen = true;
            ScreenModeButtonText.text = "WINDOWED";
        }
        else if (Screen.fullScreen)
        {
            FindObjectOfType<AudioManager>().Play("confirm");
            Screen.fullScreen = !Screen.fullScreen;
            isFullScreen = false;
            ScreenModeButtonText.text = "FULLSCREEN";
        }
        Debug.Log("Fullscreen: " + Screen.fullScreen);
        
    }

    public void SetStartText()
    {
        if (!Screen.fullScreen)
        {
            ScreenModeButtonText.text = "WINDOWED";
        }
        else if (Screen.fullScreen)
        {
            ScreenModeButtonText.text = "FULLSCREEN";
        }
    }
}
