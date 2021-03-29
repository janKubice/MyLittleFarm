using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour
{
    private GameObject help;
    private float timeScale;

    void Start()
    {

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F1))
        {
            FindObjectOfType<AudioManager>().Play("confirm");
            HelpState(help.activeSelf);
        }
    }

    private void HelpState(bool state)
    {
        if (state)
        {
            help.SetActive(false);
            Time.timeScale = timeScale;
        }
        else if ((!state) && (Time.timeScale != 0))
        {
            timeScale = Time.timeScale;
            help.SetActive(true);
            Time.timeScale = 0;
        }
    }

}
