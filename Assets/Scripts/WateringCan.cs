using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WateringCan : Item
{
    private readonly int maxUse = 7;
    private int remainingUse;
    private Slider WateringCanSlider;

    public int RemainingUse { get => remainingUse; set => remainingUse = value; }

    public int MaxUse => maxUse;

    protected virtual void Start()
    {
        remainingUse = maxUse;

        while (WateringCanSlider == null)
            WateringCanSlider = GameObject.Find("WateringCanSlider").GetComponent<Slider>();

        base.Start();
        UpdateRemainingSlider();
    }

    /// <summary>
    /// obnoví ukazatel vody na konvy
    /// </summary>
    public void UpdateRemainingSlider()
    {
        WateringCanSlider.value = remainingUse;
    }

    /// <summary>
    /// použití konvce
    /// </summary>
    public void Use()
    {
        RemainingUse -= 1;
        UpdateRemainingSlider();
    }

    /// <summary>
    /// naplnění konve
    /// </summary>
    public void FillCan()
    {
        remainingUse = maxUse;
        UpdateRemainingSlider();
    }

    public bool canUse()
    {
        return remainingUse > 0;
    }
}
