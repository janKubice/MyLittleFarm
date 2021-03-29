using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSpot : Spot
{
    private void OnMouseEnter()
    {
        slotSprite.sprite = selectedSprite;
    }

    private void OnMouseExit()
    {
        slotSprite.sprite = normalSprite;
    }

    private void OnMouseDown()
    {
        if (itemOnSpot == null)
            return;

        Inventory inv = FindObjectOfType<Inventory>();
        Item item = getItem();

        if (item == null)
            return;

        inv.placeItem(item);
        itemOnSpot = null;
        return;
    }
}
