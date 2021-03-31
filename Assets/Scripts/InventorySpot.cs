using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySpot : Spot
{
    public bool selected;

    protected virtual void Start()
    {
        itemOnSpot = null;
        itemImage.sprite = null;
        itemImage.color = new Color(itemImage.color.r, itemImage.color.g, itemImage.color.b,0);
        slotSprite.sprite = normalSprite;
        free = true;
        base.Start();
    }

    private void OnMouseDown()
    {
        if (itemOnSpot == null)
            return;

        Chest[] chests = FindObjectsOfType<Chest>();
        foreach (Chest ch in chests)
        {
            if (ch.opened)
            {
                Item item = getItem();

                if (item == null)
                    return;

                ch.placeItem(item);
                itemOnSpot = null;
                return;
            }
        }
    }

    private void OnMouseEnter()
    {
        setActive();
    }

    private void OnMouseExit()
    {
        if (!selected)
            setNonActive();
    }

    public void setActive()
    {
        slotSprite.sprite = selectedSprite;
    }

    public void setNonActive()
    {
        slotSprite.sprite = normalSprite;
    }
}
