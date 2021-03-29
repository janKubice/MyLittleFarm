using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public Item toBuy;
    public Image item_image;
    public Text item_name;
    public Text item_price;
    public Button buy;

    private void Start()
    {
        buy.onClick.AddListener(buyItem);
    }

    public void setToBuyItem(Item item)
    {
        toBuy = item;
    }

    public void setButton()
    {
        item_image.sprite = toBuy.itemSprite.sprite;
        item_name.text = toBuy.name;
        item_price.text = toBuy.price.ToString();
    }

    public void buyItem()
    {
        FindObjectOfType<Shop>().Buy(toBuy);
    }
}
