using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIData : MonoBehaviour
{
    private float hunger;
    private float thirst;
    private float sleep;
    private int golds;

    private Slider hungerSlider;
    private Slider thirstSlider;
    private Slider sleepSlider;

    private Player player;

    public Text warningText;
    public Text goldText;
    private float warningTimer;
    private float durationMultiplier;

    public Text WarningText { get => warningText; set => warningText = value; }

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        findComp();
        initUI();
        initWarningText();
    }

    void Update()
    {
        //updateGold();
        updateHunger();
        updateSleep();
        updateThirst();
    }

    void FixedUpdate()
    {
        if (warningTimer > -0.1)
            updateWarningText();   
    }

    private void findComp()
    {
        hungerSlider = GameObject.Find("Hunger").GetComponent<Slider>();
        thirstSlider = GameObject.Find("Thirst").GetComponent<Slider>();
        sleepSlider = GameObject.Find("Sleep").GetComponent<Slider>();
    }

    public void updateHunger()
    {
        hungerSlider.value = player.Hunger;
    }

    public void updateThirst()
    {
        thirstSlider.value = player.Thirst;
    }

    public void updateSleep()
    {
        sleepSlider.value = player.Sleep;
    }

    public void updateGold()
    {
        goldText.text = golds.ToString();
    }

    public void initUI()
    {
        hunger = 100;
        thirst = 100;
        sleep = 100;
        golds = 10;
    }

    public void initWarningText()
    {
        warningText = GameObject.Find("WarningText").GetComponent<Text>();
        warningText.text = "";
        warningTimer = 0;
        durationMultiplier = 2;
    }

    /// <summary>
    /// set warning text
    /// </summary>
    /// <param name="text"></param>
    /// <param name="timer"></param>
    /// <param name="color"></param>
    public void SetWarningText(string text, float timer, Color color)
    {
        warningText.text = text;
        warningTimer = timer * durationMultiplier;
        warningText.color = color;
    }
    
    public void updateWarningText()
    {
        warningTimer -= Time.fixedDeltaTime;
        if (warningTimer <= 0)
        {
            warningText.text = "";
        }
    }
}
