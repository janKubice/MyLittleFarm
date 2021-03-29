using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IClickable
{
    public new string name;
    public string desc;
    public int price;
    public int quality;
    public ItemType.Type type;
    public bool stackable;

    private GameObject player;
    private GameObject playerDistancePoint;
    private InfoPanel infoPanel;

    public SpriteRenderer itemSprite;
    public SpriteRenderer whiteBcg;

    protected virtual void Start()
    {
        player = GameObject.Find("Player");
        playerDistancePoint = GameObject.Find("playerDistancePoint");
        infoPanel = FindObjectOfType<InfoPanel>();

        if (whiteBcg != null)
            whiteBcg.enabled = false;
    }
    
    void OnMouseOver()
    {
        infoPanel.SetText(this);
        setBackground();

        if ((Input.GetMouseButtonDown(1)) && (CanEquip())) 
        {
            clickEvent();
        }
    }

    void OnMouseExit()
    {
        infoPanel.DeactivatePanel();
        if (whiteBcg != null)
            whiteBcg.enabled = false;
    }

    /// <summary>
    /// zjistí zda mohu equipnout objekt
    /// </summary>
    /// <returns>true/false dle vzdálenosti od hráče</returns>
    public bool CanEquip()
    {
        float distance = Vector2.Distance(gameObject.transform.position, playerDistancePoint.transform.position);
        if ((distance <= 3f))
        {
            return true;
        }
        else
            return false;
    }

    public void setBackground()
    {
        if (whiteBcg == null)
            return;

        whiteBcg.enabled = true;
        float distance = Vector2.Distance(gameObject.transform.position, playerDistancePoint.transform.position);
        if ((distance <= 3f))
        {

            whiteBcg.color = new Color(0, 255, 0, 0.3f);
        }
        else
            whiteBcg.color = new Color(255, 0, 0, 0.3f);

    }

    public void clickEvent()
    {
        Debug.Log("picked up " + this.name);
        Player p = FindObjectOfType<Player>();
        p.inventory.placeItem(this);
    }
}
