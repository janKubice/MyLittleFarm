using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public GameObject toGoDoor;
    private bool canGo;

    private void Update()
    {
        if (canGo && Input.GetKeyDown(KeyCode.E))
        {
            FindObjectOfType<Player>().gameObject.transform.position = toGoDoor.transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canGo = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canGo = false;
    }
}
