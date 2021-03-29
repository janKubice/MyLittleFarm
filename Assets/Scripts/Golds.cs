using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Golds : MonoBehaviour
{

    private Text goldText;
    private Player player;

    void Start()
    {
        goldText = GameObject.Find("goldText").GetComponent<Text>();
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    void FixedUpdate()
    {
        SetGolds();
    }

    /// <summary>
    /// nastavím goldy postavě
    /// </summary>
    protected void SetGolds()
    {
        string fakeZeros = "";

        for (int i = 0; i <= -(player.golds.ToString().Length - 4); i++)
        {
            fakeZeros += "0";
        }
        goldText.text = fakeZeros + player.Golds.ToString();
    }
}
