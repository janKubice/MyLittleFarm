using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public InventorySpot equiped;
    public InventorySpot[] inventorySpot;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            activate(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            activate(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            activate(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            activate(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            activate(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            activate(5);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            activate(6);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            activate(7);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            activate(8);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (equiped != null && equiped.free == false)
            {
                equiped.removeItemFromSpot();
            }
        }
    }

    public void activate(int spot)
    {
        equiped = null;
        deactivateAll();
        equiped = inventorySpot[spot];
        equiped.setActive();
        equiped.selected = true;
    }

    public void deactivateAll()
    {
        foreach(InventorySpot spot in inventorySpot)
        {
            spot.selected = false;
            spot.setNonActive();
        }
    }

    public bool placeItem(Item item)
    {
        int spot = getStackableSpot(item);

        if (spot == -1)
            spot = getFirstFree();

        if (spot >= 0)
        {
            inventorySpot[spot].putItemOnSpot(item);
            return true;
        }
        else
        {
            return false;
            //TODO hláška o plném inventáři
        }
    }

    public int getStackableSpot(Item item)
    {
        for (int i = 0; i < inventorySpot.Length; i++)
        {
            if (inventorySpot[i].itemOnSpot.Count > 0 && inventorySpot[i].itemOnSpot[0].stackable && inventorySpot[i].itemOnSpot[0].name == item.name)
            {
                return i;
            }
        }

        return -1;
    }

    public int getFirstFree()
    {
        for(int i = 0; i < inventorySpot.Length; i++)
        {
            if (inventorySpot[i].free)
            {
                return i;
            }
        }

        return -1;
    }
}
