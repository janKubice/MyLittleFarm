using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public SpriteRenderer chestSpriteRenderer;
    public Sprite normalSprite;
    public Sprite openedSprite;
    public ChestSpot[] spots;
    public GameObject chestGui;

    public int chestSize;

    public bool opened;

    private void Start()
    {
        chestSpriteRenderer.sprite = normalSprite;
        chestGui.SetActive(false);
        opened = false;
        initSpots();
    }

    private void Update()
    {
        float distance = Vector2.Distance(gameObject.transform.position, FindObjectOfType<Player>().gameObject.transform.position);
        if (distance > 3)
        {
            closeChest();
        }
    }

    private void deactivateAllSpots()
    {
        foreach (ChestSpot spot in spots)
        {
            spot.gameObject.SetActive(false);
        }
    }

    private void initSpots()
    {
        for (int i = chestSize; i < spots.Length; i++)
        {
            Destroy(spots[i].gameObject);
        }
    }

    private void OnMouseDown()
    {
        float distance = Vector2.Distance(gameObject.transform.position, FindObjectOfType<Player>().gameObject.transform.position);
        if (distance > 3)
            return;

        if (!opened)
            openChest();
        else
            closeChest();
        
    }

    public void placeItem(Item item)
    {
        int spot = getStackableSpot(item);

        if (spot == -1)
            spot = getFirstFree();

        if (spot >= 0)
        {
            Debug.Log("item transfer to " + gameObject.name + " spot " + spot);
            spots[spot].putItemOnSpot(item);
        }
        else
        {
            //TODO hláška o plném inventáři
        }
    }

    public void openChest()
    {
        opened = true;
        chestSpriteRenderer.sprite = openedSprite;
        chestGui.SetActive(true);
    }

    public int getStackableSpot(Item item)
    {
        for (int i = 0; i < chestSize; i++)
        {
            if (spots[i].itemOnSpot.Count > 0 && spots[i].itemOnSpot[0].stackable && spots[i].itemOnSpot[0].name == item.name)
            {
                return i;
            }
        }

        return -1;
    }

    public int getFirstFree()
    {
        for (int i = 0; i < chestSize; i++)
        {
            if (spots[i].free)
            {
                return i;
            }
        }

        return -1;
    }

    public void closeChest()
    {
        opened = false;
        chestSpriteRenderer.sprite = normalSprite;
        chestGui.SetActive(false);
    }
}
