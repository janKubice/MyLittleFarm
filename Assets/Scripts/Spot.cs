using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spot : MonoBehaviour
{
    public List<Item> itemOnSpot;
    public SpriteRenderer slotSprite;
    public SpriteRenderer itemSprite;

    public bool free;
    public Text countText;

    public Sprite selectedSprite;
    public Sprite normalSprite;

    protected virtual void Start()
    {
        itemOnSpot = new List<Item>();
        itemSprite.sprite = null;
        slotSprite.sprite = normalSprite;
        free = true;
        countText.text = "";
    }
    public void putItemOnSpot(Item item)
    {
        itemOnSpot.Add(item);
        item.transform.position = new Vector3(10000, 10000, item.transform.position.z);
        itemSprite.sprite = item.gameObject.GetComponent<SpriteRenderer>().sprite;
        free = false;
        if (item.stackable)
            countText.text = itemOnSpot.Count.ToString();
        else
            countText.text = "";
    }

    /// <summary>
    /// Pouze odstrani
    /// </summary>
    public void removeItemFromSpot()
    {
        if (itemOnSpot.Count == 0)
            return;

        Item item = itemOnSpot[0];
        itemOnSpot.RemoveAt(0);

        item.transform.position = FindObjectOfType<Player>().gameObject.transform.position;

        if (item.stackable)
        {
            countText.text = itemOnSpot.Count.ToString();
            if (itemOnSpot.Count == 0)
            {
                free = true;
                itemSprite.sprite = null;
                countText.text = "";
            }
        }
        else
        {
            free = true;
            itemSprite.sprite = null;
            countText.text = "";
        }
    }

    /// <summary>
    /// Vezme a odstrani
    /// </summary>
    /// <returns></returns>
    public Item getItem()
    {
        if (itemOnSpot.Count == 0)
            return null;

        Item item = itemOnSpot[0];
        itemOnSpot.RemoveAt(0);

        if (item.stackable)
        {
            countText.text = itemOnSpot.Count.ToString();
            if (itemOnSpot.Count == 0)
            {
                free = true;
                itemSprite.sprite = null;
                countText.text = "";
            }
        }
        else
        {
            free = true;
            itemSprite.sprite = null;
            countText.text = "";
        }           
        
        return item;
    }
}
