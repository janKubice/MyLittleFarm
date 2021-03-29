using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Well : MonoBehaviour
{
    private Player player;
    private WateringCan wateringCan;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        wateringCan = GameObject.Find("WateringCan").GetComponent<WateringCan>();
    }

    /// <summary>
    /// po kliknutí se buďto napiju nebo naplním konev
    /// </summary>
    void OnMouseDown()
    {
        //TODO
    }
}
