using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPanel : MonoBehaviour
{

    public GameObject infoPanel;
    public SpriteRenderer bcg;
    private Text item_name;
    private Text item_desc;
    private Text item_quality;
    private Text item_price;

    void Start()
    {
        item_name = GameObject.Find("Item_Name").GetComponent<Text>();
        item_quality = GameObject.Find("Item_Quality").GetComponent<Text>();
        item_price = GameObject.Find("Item_Price").GetComponent<Text>();
        item_desc = GameObject.Find("Item_Desc").GetComponent<Text>();
        bcg = GameObject.Find("InfoPanelBcg").GetComponent<SpriteRenderer>();
        DeactivatePanel();


    }

    /// <summary>
    /// nastavím text infoPanelu
    /// </summary>
    /// <param name="itemTag"></param>
    public void SetText(Item item)
    {
        if (item is ISellable)
        {
            ActivatePanel();
            item_name.text = item.name;
            item_desc.text = item.desc;
            item_price.text = item.price.ToString();
            item_quality.text = item.quality.ToString();
        }
        else
        {
            ActivatePanel();
            item_name.text = item.name;
            item_desc.text = "";
            item_price.text = "";
            item_quality.text = "";
        }
    }

    public void SetText(TileTemplate tile)
    {
        //TODO
    }

    /// <summary>
    /// "aktivuji" infoPanel, pouze se změní alfa aby byl neprůhledný
    /// </summary>
    public void ActivatePanel()
    {
        bcg.color = Color.white;
        item_name.color = new Color(1, 1, 1, 1);
        item_desc.color = new Color(1, 1, 1, 1);
        item_price.color = new Color(1, 1, 1, 1);
        item_quality.color = new Color(1, 1, 1, 1);
    }

    /// <summary>
    /// "deaktivuji" infoPanel,pouze se změní alfa aby byl průhledný
    /// </summary>
    public void DeactivatePanel()
    {
        bcg.color = new Color(1, 1, 1, 0);
        item_name.color = new Color(1, 1, 1, 0);
        item_desc.color = new Color(1, 1, 1, 0);
        item_price.color = new Color(1, 1, 1, 0);
        item_quality.color = new Color(1, 1, 1, 0);
    }
}
