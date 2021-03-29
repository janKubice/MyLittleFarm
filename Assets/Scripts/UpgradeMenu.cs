using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour
{
    private Player player;
    private GameObject upgradeMenu;
    private PlayerConstoller playerController;
    private float timeScale;

    private int speedCost;
    private int eatCost;
    private int waterCost;
    private int sleepCost;

    private Text speedCostTx;
    private Text eatCostTx;
    private Text waterCostTx;
    private Text sleepCostTx;

    void Start()
    {
        speedCost = 50;
        eatCost = 50;
        waterCost = 50;
        sleepCost = 50;

        upgradeMenu = GameObject.Find("UpgradeMenu");
        player = GameObject.Find("Player").GetComponent<Player>();
        playerController = GameObject.Find("Player").GetComponent<PlayerConstoller>();

        //speedCostTx = GameObject.Find("BetterSpeedButton").GetComponentInChildren<Text>();
        //eatCostTx = GameObject.Find("BetterEatingButton").GetComponentInChildren<Text>();
        //waterCostTx = GameObject.Find("BetterDrinkingButton").GetComponentInChildren<Text>();
        //sleepCostTx = GameObject.Find("BetterSleepingButton").GetComponentInChildren<Text>();

        //speedCostTx.text = CostText(speedCost);
        //eatCostTx.text = CostText(eatCost);
        //waterCostTx.text = CostText(waterCost);
        //sleepCostTx.text = CostText(sleepCost);

        //upgradeMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            UpgradeMenuState(upgradeMenu.activeSelf);
        }
    }

    public void UpgradeSleep()
    {
        if (playerController.EnoughtMoney(sleepCost))
        {
            FindObjectOfType<AudioManager>().Play("confirm");
            player.MinusMoney(sleepCost);
            sleepCost += 50;
            sleepCostTx.text = CostText(sleepCost);
            player.SleepDecreaseRate += 0.1f;
        }
    }

    public void UpgradeEat()
    {
        if (playerController.EnoughtMoney(eatCost))
        {
            FindObjectOfType<AudioManager>().Play("confirm");
            player.MinusMoney(eatCost   );
            eatCost += 50;
            eatCostTx.text = CostText(eatCost);
            player.HungerDecreaseRate += 0.5f;
        }
    }

    public void UpgradeDrink()
    {
        if (playerController.EnoughtMoney(waterCost))
        {
            FindObjectOfType<AudioManager>().Play("confirm");
            player.MinusMoney(waterCost);
            waterCost += 50;
            waterCostTx.text = CostText(waterCost);
            player.WaterDecreaseRate += 0.5f;
        }
    }

    public void UpgradeSpeed()
    {
        if (playerController.EnoughtMoney(speedCost))
        {
            FindObjectOfType<AudioManager>().Play("confirm");
            player.MinusMoney(speedCost);
            speedCost += 50;
            speedCostTx.text = CostText(speedCost);
            player.MovementSpeed += 0.5f;
        }
    }

    private string CostText(int price)
    {
        return "Cost: " + price.ToString() + "Golds";
    }

    private void UpgradeMenuState(bool state)
    {
        FindObjectOfType<AudioManager>().Play("confirm");
        if (state)
        {
            upgradeMenu.SetActive(false);
            Time.timeScale = timeScale;
        }
        else if ((!state) && (Time.timeScale != 0))
        {
            timeScale = Time.timeScale;
            upgradeMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
