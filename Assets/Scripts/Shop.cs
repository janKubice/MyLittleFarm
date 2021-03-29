using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Shop : MonoBehaviour, IClickable
{
    private Player player;
    private UIData output;
    private InfoPanel infoPanel;
    private GameObject shopWin;
    PlayerConstoller playerController;

    public Item[] itemsToBuy;
    public ShopItem[] shopSlots;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        output = GameObject.Find("CanvasDynamic").GetComponent<UIData>();
        infoPanel = GameObject.Find("InfoPanelBcg").GetComponent<InfoPanel>();
        playerController = GameObject.Find("Player").GetComponent<PlayerConstoller>();
        shopWin = GameObject.Find("ShopWin");

        shopWin.SetActive(false);

        foreach (ShopItem slot in shopSlots)
        {
            slot.gameObject.SetActive(false);
        }

        for (int i = 0; i < itemsToBuy.Length; i++)
        {
            shopSlots[i].gameObject.SetActive(true);
            shopSlots[i].setToBuyItem(itemsToBuy[i]);
            shopSlots[i].setButton();
        }
    }

    private void Update()
    {
        if (shopWin.activeSelf && !CanEquip())
        {
            closeShopWin();
        }
    }

    /// <summary>
    /// nakoupí a spawne item na zem
    /// </summary>
    /// <param name="name">jméno semínka</param>
    public void Buy(Item item)
    {
        if (player.golds >= item.price)
        {
            player.MinusMoney(item.price);
            Item buyed = spawnItem(item);
            bool result = player.inventory.placeItem(buyed);
            if (!result)
            {
                DropItem(buyed);
            }
        }
    }

    /// <summary>
    /// prodá věc držící v ruce
    /// </summary>
    /// <param name="price">cena</param>
    /// <param name="name">jméno věci - uvádí se kvůli WerningTextu</param>
    /// <param name="selling">gameobjekt který prodávám</param>
    protected void Sell(int price, string name, GameObject selling)
    {
        //TODO předělat
        Destroy(selling);
        player.PlusMoney(price);
        output.SetWarningText("You sold " + name + " for " + price + ".", 2, Color.green);
        infoPanel.DeactivatePanel();
    }

    public Item spawnItem(Item item)
    {
        Item i = Instantiate(item, this.gameObject.transform.position, Quaternion.identity);
        return i;
    }

    public void SellItem(string cropName)
    {
        //Šlo by mnoooohem víc zefektivnit, ale není čas
        //zbytečně neprocházet furt pole, itemy někde uchovávat a jen do nich přidávat atd...
        GameObject[] itemsToSale;
        List<GameObject> items = new List<GameObject>();
        string name = cropName;

        itemsToSale = GameObject.FindGameObjectsWithTag("ItemToSale");

        if (itemsToSale.Length <= 0)
        {
            output.SetWarningText("Nothing to sell", 2, Color.red);
            return;
        }

        foreach (GameObject item in itemsToSale)
        {
            if (item.name.Contains(cropName))
                items.Add(item);
        }

        GameObject itemToSale = items[0];
        //player.PlusMoney(itemToSale.GetComponent<ItemToSale>().Price);
        Destroy(itemToSale);

    }

    /// <summary>
    /// vyhodí věc na zem po když není místo v inventári
    /// </summary>
    /// <param name="seed">název cropu</param>
    private void DropItem(Item item)
    {
        //TODO
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="price">cena</param>
    /// <param name="name">jméno</param>
    /// <param name="seed">seed objekt</param>
    /// <param name="tag">tag objektu</param>
    private void evaluateCase(int price, String name, GameObject seed, string tag)
    {
        if (!playerController.EnoughtMoney(price))
            output.SetWarningText("You don't have enough money", 2, Color.red);
        else
        {
            Spawn(seed, tag);
            player.MinusMoney(price);
            output.SetWarningText("You bought: " + name, 2, Color.green);
        }
    }

    /// <summary>
    /// spawne objekct semínka
    /// </summary>
    /// <param name="seed">jaký objekt, používá se na obchod takže vždy jen pref. crop</param>
    /// <param name="tag">tag cropu</param>
    /// <param name="bouhgtPrice">nákupní cena</param>
    private void Spawn(GameObject seed, string tag)
    {
        GameObject crop = Instantiate(seed, this.gameObject.transform.position, Quaternion.identity);
        crop.transform.position = new Vector3(Random.Range(GameObject.Find("werehousePoint1").transform.position.x, GameObject.Find("werehousePoint2").transform.position.x),
                Random.Range(GameObject.Find("werehousePoint1").transform.position.y, GameObject.Find("werehousePoint3").transform.position.y),
                this.gameObject.transform.position.z);
        crop.tag = tag;
        crop.name = tag;
    }

    void OnMouseOver()
    {
        if ((Input.GetMouseButtonDown(1)) && CanEquip())
        {
            clickEvent();
        }
    }

    public bool CanEquip()
    {
        float distance = Vector2.Distance(gameObject.transform.position, player.transform.position);
        if ((distance <= 3f))
        {
            return true;
        }
        else
            return false;
    }

    public void clickEvent()
    {
        shopWin.SetActive(!shopWin.activeSelf);
    }

    public void closeShopWin()
    {
        shopWin.SetActive(false);
    }
}
