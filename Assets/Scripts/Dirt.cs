using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirt : TileTemplate
{
    private WateringCan wateringCan;
    private InfoPanel infoPanel;
    public bool canPlant;
    public float fertility;
    public bool needPlowing;
    public bool watered;
    public SpriteRenderer plant;
    public Item itemOnTile;

    public Sprite plowed;
    public Sprite unplowed;
    public Sprite wateredSprite;

    protected override void Start()
    {
        wateringCan = FindObjectOfType<WateringCan>();
        infoPanel = FindObjectOfType<InfoPanel>();
        watered = false;
        canPlant = false;
        needPlowing = true;
        plant.sprite = null;
        base.Start();
    }


    void Update()
    {
        WaterController();
    }

    /// <summary>
    /// zajišťuje kliknutí na políčku a vyhodnotí co se má stát
    /// </summary>
    void OnMouseDown()
    {
        //TODO
        if (PlayerDistance() < 3f)
        {
            if ((player.inventory.equiped.free == true && itemOnTile != null && itemOnTile.GetComponent<CropTemplate>().canBeHarvested) || (itemOnTile != null && itemOnTile.GetComponent<CropTemplate>().canBeHarvested))
            {
                itemOnTile.GetComponent<CropTemplate>().Chop();
                return;
            }

            if (player.inventory.equiped.free == false && player.inventory.equiped.itemOnSpot[0].type == ItemType.Type.Crop && canPlant && !needPlowing)
            {
                Item crop = player.inventory.equiped.getItem();
                plant.sprite = crop.itemSprite.sprite;
                itemOnTile = crop;
                crop.GetComponent<CropTemplate>().plant();
                crop.GetComponent<CropTemplate>().AssignTile(this);
                canPlant = false;
                return;
            }

            if (player.inventory.equiped.free == false && player.inventory.equiped.itemOnSpot[0].type == ItemType.Type.Spade && needPlowing)
            {
                spriteRend.sprite = plowed;
                canPlant = true;
                needPlowing = false;
                return;
            }

            if (player.inventory.equiped.free == false && player.inventory.equiped.itemOnSpot[0].type == ItemType.Type.WateringCan && !watered && plowed)
            {
                watered = true;
                spriteRend.sprite = wateredSprite;
            }
        }



    }

    /// <summary>
    /// zjišťuje stav vody
    /// přebírá stav vody z rodiče (tile) v sekundách
    /// pokud zbývá vody pod 15 sekund nastaví uschlý sprite
    /// </summary>
    private void WaterController()
    {
        if (water > 50)
        {
            timeWatered += Time.deltaTime;
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
