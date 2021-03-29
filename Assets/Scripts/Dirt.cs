using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirt : TileTemplate
{
    private WateringCan wateringCan;
    private InfoPanel infoPanel;
    public bool canPlant;
    public float fertility;
    public bool watered;
    private bool canInteract;


    protected override void Start()
    {
        wateringCan = FindObjectOfType<WateringCan>();
        infoPanel = FindObjectOfType<InfoPanel>();
        watered = false;
        canInteract = false;
        base.Start();
    }


    void Update()
    {

    }

    void FixedUpdate()
    {
        if (PlayerDistance() < 3f)
            canInteract = true;
        else
            canInteract = false;
    }
    /// <summary>
    /// zajišťuje kliknutí na políčku a vyhodnotí co se má stát
    /// </summary>
    void OnMouseDown()
    {
        //TODO
        if (canInteract)
        {
            if (player.inventory.equiped.itemOnSpot[0].type == ItemType.Type.Spade)
            {
                if (type == TileType.Type.Grass)
                {

                }


            }
            else if (player.inventory.equiped.itemOnSpot[0].type == ItemType.Type.WateringCan && wateringCan.canUse())
            {
                if (type == TileType.Type.Grass)
                {

                }
            }
            else if (player.inventory.equiped.itemOnSpot[0].type == ItemType.Type.GreenGun)
            {

            }
            else if (player.inventory.equiped.itemOnSpot[0].type == ItemType.Type.Seed)
            {

            }
        }



    }

    void OnMouseOver()
    {
        infoPanel.SetText(this);
    }

    void OnMouseExit()
    {
        infoPanel.DeactivatePanel();
    }
}
