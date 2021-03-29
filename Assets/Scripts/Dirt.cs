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
    public SpriteRenderer plant;
    public Item itemOnTile;


    protected override void Start()
    {
        wateringCan = FindObjectOfType<WateringCan>();
        infoPanel = FindObjectOfType<InfoPanel>();
        watered = false;
        canPlant = true;
        plant.sprite = null;
        base.Start();
    }


    void Update()
    {

    }

    /// <summary>
    /// zajišťuje kliknutí na políčku a vyhodnotí co se má stát
    /// </summary>
    void OnMouseDown()
    {
        //TODO
        if (PlayerDistance() < 3f)
        {
            if (player.inventory.equiped.itemOnSpot[0].type == ItemType.Type.Crop && canPlant)
            {
                Item crop = player.inventory.equiped.getItem();
                plant.sprite = crop.itemSprite.sprite;
                itemOnTile = crop;
                crop.GetComponent<CropTemplate>().plant();
                crop.GetComponent<CropTemplate>().AssignTile(this);
                canPlant = false;
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
