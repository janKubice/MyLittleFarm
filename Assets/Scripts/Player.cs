using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private float hunger; //max 100
    private float thirst; //max 100
    private float sleep; //max 100

    public Inventory inventory;

    private readonly float maxStat = 100;

    private float hungerDecreaseRate = 3.5f;
    private float waterDecreaseRate = 2.5f;
    private float sleepDecreaseRate = 5f;
    private float movementSpeed;

    public int golds;

    //private WarningText warningText;
    //private PlayerMovement playerMov;
    public GameObject Black;
    //private PlayerStats playerStats;

    private bool isCorountineStarted = false;

    public int Golds { get => golds; set => golds = value; }
    public float Hunger { get => hunger; set => hunger = value; }
    public float Thirst { get => thirst; set => thirst = value; }
    public float Sleep { get => sleep; set => sleep = value; }
    public float HungerDecreaseRate { get => hungerDecreaseRate; set => hungerDecreaseRate = value; }
    public float WaterDecreaseRate { get => waterDecreaseRate; set => waterDecreaseRate = value; }
    public float SleepDecreaseRate { get => sleepDecreaseRate; set => sleepDecreaseRate = value; }
    public float MovementSpeed { get => movementSpeed; set => movementSpeed = value; }
    public bool IsCorountineStarted { get => isCorountineStarted; set => isCorountineStarted = value; }

    void Start()
    {
        hunger = 100;
        thirst = 100;
        sleep = 100;
        movementSpeed = 3;

        inventory = FindObjectOfType<Inventory>();
    }

    /// <summary>
    /// ubere hlad/postava se nají
    /// </summary>
    /// <param name="hunger">kolik přidám jídla</param>
    public void HungerChange(int hunger)
    {
        if ((hunger + this.hunger) <= maxStat)
            this.hunger += hunger;
        else
            this.hunger = maxStat;
    }

    public void ThirstChange(int thirts)
    {
        if ((thirts + this.thirst) <= maxStat)
            this.thirst += thirts;
        else
            this.thirst = maxStat;
    }

    public void SleepChange(int sleep)
    {
        if ((sleep + this.sleep) <= maxStat)
            this.sleep += sleep;
        else
            this.sleep = maxStat;
    }

    /// <summary>
    /// odečtu peníze postavě
    /// </summary>
    /// <param name="money">kolik peněz</param>
    public void MinusMoney(int money)
    {
        golds -= money;
    }

    /// <summary>
    /// přičtu peníze postave
    /// </summary>
    /// <param name="money">kolik peněz</param>
    public void PlusMoney(int money)
    {
        golds += money;
    }

    /// <summary>
    /// uberu energii
    /// </summary>
    /// <param name="sleep">energie na ubrání</param>
    public void DoWork(int sleep)
    {
        this.sleep -= sleep;
    }

}
   
