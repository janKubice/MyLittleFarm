using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScene : MonoBehaviour
{ 
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Death");
        StartCoroutine(wait());
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            FindObjectOfType<AudioManager>().Stop("Death");
            SceneManager.LoadScene("Menu");
        }
    }

    public IEnumerator wait()
    {
        yield return new WaitForSeconds(18);
        SceneManager.LoadScene("Menu");
    }
}
