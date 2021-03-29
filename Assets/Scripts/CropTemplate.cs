using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropTemplate : Item, IKillable, IAgable, IPlacable
{
    [Header("Život (sekundy)")]
    public int stage1_endAge;
    public int stage2_endAge;
    public int stage3_endAge;
    public int stage4_endAge;
    public int maxAge;

    [Header("Produkt")]
    public GameObject product;

    private float water;
    private float age;
    private bool canBeHarvested;
    private bool planted;
    private float timeWatered;

    [Header("Crop sprites")]
    public Sprite stage1;
    public Sprite stage2;
    public Sprite stage3;
    public Sprite stage4;
    public Sprite stage5;

    private UIData output;
    private SpriteRenderer spriteRend;
    private TileTemplate tile;

    protected virtual void Start()
    {
        output = GameObject.Find("CanvasDynamic").GetComponent<UIData>();
        spriteRend = gameObject.GetComponent<SpriteRenderer>();
        canBeHarvested = false;
        planted = false;
        timeWatered = 0;
        tile = null;
        quality = 1;
        base.Start();
    }

    void OnMouseDown()
    {
        if (canBeHarvested)
        {
            Chop(QualityCalculate());
        }

    }

    void FixedUpdate()
    {
        if (planted)
        {
            age += Time.fixedDeltaTime;
        }
        else return;

        AgeController();
        WaterController();
    }

    /// <summary>
    /// přiřadí políčko na kterém je
    /// </summary>
    public void AssignTile(TileTemplate tile)
    {
        this.tile = tile;
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

    public void AgeController()
    {
        if (age < stage1_endAge)
        {
            SetSprite(stage1);
        }
        else if (age < stage2_endAge)
        {
            SetSprite(stage2);
        }
        else if (age < stage3_endAge)
        {
            SetSprite(stage3);
        }
        else if (age < stage4_endAge)
        {
            SetSprite(stage4);
            if (!canBeHarvested)
            {
                canBeHarvested = true;
            }
        }

        if (age >= maxAge)
        {
            SetSprite(stage5);
            death("age");
        }

    }

   
    /// <summary>
    /// Jakmile dosáhne stage 5 vyresetuje se vše a kvete odznova jako by byla čerstvě zasazena
    /// </summary>
    private void resetCrop()
    {

    }

    /// <summary>
    /// nastaví požadovaný sprite 
    /// </summary>
    /// <param name="sprite">požadovaný sprite</param>
    private void SetSprite(Sprite sprite)
    {
        tile.GetComponent<Dirt>().plant.sprite = sprite;
    }

    /// <summary>
    /// poseká rostlinu, vytvoří sklizenou plodinu na prodej s příslušnou kvalitou a cenou
    /// </summary>
    private void Chop(float quality)
    {
        if (canBeHarvested)
        {
            SetSprite(stage5);
            CropSpawn(quality);
            //Destroy(gameObject);
        }

    }

    /// <summary>
    /// spawne crop
    /// </summary>
    /// <param name="price">cena cropu</param>
    private void CropSpawn(float quality)
    {
        int number = Random.Range(1, 4);
        for (int i = 0; i <= number; i++)
        {
            GameObject plodina = Instantiate(new GameObject());
            plodina.transform.localScale = new Vector2(0.1f, 0.1f);

            plodina.AddComponent<SpriteRenderer>();
            plodina.GetComponent<SpriteRenderer>().sprite = product.GetComponent<SpriteRenderer>().sprite;
            plodina.GetComponent<SpriteRenderer>().sortingLayerName = "Crop";


            plodina.AddComponent<Item>();

            plodina.tag = "ItemToSale";
            plodina.name = name;

            plodina.AddComponent<PolygonCollider2D>().isTrigger = true;
        }


    }

    /// <summary>
    /// vypočítá cenu z kvality
    /// </summary>
    /// <param name="quality">kvalita</param>
    /// <returns>cena</returns>
    private int PriceCalculate(float quality)
    {
        int price = ((int)(quality * this.price) - 1);
        if (price <= 0)
            return 0;
        else
            return price;
    }

    /// <summary>
    /// vypočítá kvalitu
    /// </summary>
    /// <returns>kvalita (např 1-4)</returns>
    private float QualityCalculate()
    {
        if (timeWatered >= ((age / 100) * 90))
            return 4;
        else if (timeWatered >= ((age / 100) * 75))
            return 3;
        else if (timeWatered >= ((age / 100) * 50))
            return 2;
        else if (timeWatered >= ((age / 100) * 35))
            return 1;
        else if (timeWatered >= ((age / 100) * 20))
            return 0.5f;
        else if (timeWatered >= ((age / 100) * 10))
            return 0.25f;
        else return 0;
    }

    public void plant()
    {
        this.planted = true;
    }

    public void death(string reason)
    {
        output.SetWarningText("your " + gameObject.name + " died. Reason: " + reason, 2, Color.red);
        //Destroy(gameObject);
    }
}
