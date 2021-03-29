using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Travel : MonoBehaviour
{
    public Scene scene;

    public Travel()
    {
        SceneManager.LoadScene(scene.ToString());
    }
}
