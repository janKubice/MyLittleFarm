using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private int speed;
    private Rigidbody2D playerRb;
    private Vector2 moveVelocity;
    private Animator anim;
    private SpriteRenderer itemInHand;
    private Player player;
    private PlayerConstoller playerController;
    public GameObject wiki;
    private Vector2 moveInput;

    public GameObject spotCan, spotSpade, spotGun;
    public GameObject can, spade, gun;

    public int Speed { get => speed; set => speed = value; }

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player").GetComponent<Player>();
        playerController = GameObject.Find("Player").GetComponent<PlayerConstoller>();

        if (playerRb == null)
            playerRb = GameObject.Find("Player").GetComponent<Rigidbody2D>();

    }


    void Update()
    {
        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveVelocity = moveInput.normalized * player.MovementSpeed;

        anim.SetFloat("directionHorizontal", Input.GetAxis("Horizontal"));
        anim.SetFloat("directionVertical", Input.GetAxis("Vertical"));

        Eating();
        helpOpener();
    }

    void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + moveVelocity * Time.deltaTime);
    }

    /// <summary>
    /// po zmáčknutí tlačítko zavolá metodu na otevření wiki
    /// </summary>
    private void helpOpener()
    {
        if (Input.GetKeyDown(KeyCode.F2))
        {
            FindObjectOfType<AudioManager>().Play("confirm");
            wikiState(wiki.activeSelf);
        }
    }

    /// <summary>
    /// zjistí jak je na tom wiki a otevře/zavře
    /// </summary>
    /// <param name="state"></param>
    private void wikiState(bool state)
    {
        if (state)
        {
            wiki.SetActive(false);
            Time.timeScale = 1;
        }
        else if ((!state) && (Time.timeScale != 0))
        {
            wiki.SetActive(true);
            Time.timeScale = 0;
        }
    }

    /// <summary>
    /// jezení
    /// </summary>
    private void Eating()
    {
        //TODO
        return;
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (player.inventory.equiped == null)
                return;

            if (player.inventory.equiped.itemOnSpot[0].type == ItemType.Type.Food)
            {

            }
        }
    }
}
