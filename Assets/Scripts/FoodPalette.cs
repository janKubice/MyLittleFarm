using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPalette : MonoBehaviour
{

    public Player player;
    public PlayerConstoller playerController;
    public Sprite breadSprite, rollSPrite;
    public Shop shop;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        playerController = GameObject.Find("Player").GetComponent<PlayerConstoller>();
        shop = GameObject.Find("paletteShop").GetComponent<Shop>();
    }

    /// <summary>
    /// spawne jídlo
    /// </summary>
    /// <param name="price"></param>
    /// <param name="name"></param>
    private void FoodSpawn(int price,string name)
    {
        if (playerController.EnoughtMoney(price))
        {
            player.MinusMoney(price);

            GameObject food = Instantiate(new GameObject());

            food.AddComponent<SpriteRenderer>();
            food.GetComponent<SpriteRenderer>().sprite = SpriteSet();
            food.GetComponent<SpriteRenderer>().sortingLayerName = "Crop";
            food.GetComponent<SpriteRenderer>().sortingOrder = 1;

            food.AddComponent<PolygonCollider2D>().isTrigger = true;

            food.AddComponent<Item>();

            food.tag = "food";
            food.name = name;
            food.transform.position = new Vector3(Random.Range(GameObject.Find("werehousePoint1").transform.position.x, GameObject.Find("werehousePoint2").transform.position.x),
                Random.Range(GameObject.Find("werehousePoint1").transform.position.y, GameObject.Find("werehousePoint3").transform.position.y),
                this.gameObject.transform.position.z);

        }

    }

    /// <summary>
    /// nastaví sprite objektu
    /// </summary>
    /// <returns></returns>
    private Sprite SpriteSet()
    {
        if (this.gameObject.name == "PaletteBread")
            return breadSprite;
        else if (this.gameObject.name == "PaletteRoll")
            return rollSPrite;
        else
            return null;
    }
}
