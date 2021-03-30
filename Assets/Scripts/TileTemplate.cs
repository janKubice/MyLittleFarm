using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TileTemplate : MonoBehaviour
{
    public new string name;
    public TileType.Type type;

    protected Player player;
    public SpriteRenderer spriteRend;
    protected GameObject playerDistancePoint;
    protected UIData output;



    /// <summary>
    /// nastaví potřebné parametry
    /// </summary>
    protected virtual void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        spriteRend = gameObject.GetComponent<SpriteRenderer>();
        output = GameObject.Find("CanvasDynamic").GetComponent<UIData>();
        playerDistancePoint = GameObject.Find("playerDistancePoint");
    }

    /// <summary>
    /// zjišťuje vzdálenost mezi políčkem a hráčem
    /// </summary>
    /// <returns></returns>
    protected float PlayerDistance()
    {
        return Vector2.Distance(gameObject.transform.position, playerDistancePoint.transform.position);
    }

}
