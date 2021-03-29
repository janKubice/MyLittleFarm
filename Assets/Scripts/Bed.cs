using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour
{
    private Player player;
    private PlayerConstoller playerController;
    private UIData output;
    private bool canSleep = false;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        output = GameObject.Find("CanvasDynamic").GetComponent<UIData>();
        playerController = GameObject.Find("Player").GetComponent<PlayerConstoller>();
    }

    private void Update()
    {
        if (canSleep && Input.GetKeyDown(KeyCode.E))
        {
            Sleeping();
        }
    }

    private void Sleeping()
    {
        if ((player.Thirst <= 30) || (player.Hunger <= 20))
        {
            output.SetWarningText("Better get some snack!", 2, Color.red);
        }
        else
        {
            playerController.StartCoroutine(playerController.Unconsciousness(5, 5, 100));
            player.ThirstChange(-25);
            player.HungerChange(-15);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canSleep = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canSleep = false;
    }
}
