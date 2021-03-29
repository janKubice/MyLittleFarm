using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
public class TDW : MonoBehaviour
{
    public Light2D globalLight;
    public Light2D playerLight;
    public int lightDown, lightUp;

    public SpriteRenderer timeSR;
    [Tooltip("Index 0 - půlnoc...index 23 - 23.hodina")]
    public Sprite[] times;
    

    public int hour;
    private float hourTimer;
    private readonly int secondInHour = 120;

    void Start()
    {
        globalLight.intensity = 1;
        playerLight.intensity = 0;

        if (times.Length != 24)
        {
            Debug.LogError("Nesprávný počet spritů na čas");
        }

        timeSR.sprite = times[hour];
    }

    private void FixedUpdate()
    {
        UpdateTime();
        lightManager();
    }

    private void UpdateTime()
    {
        hourTimer += Time.deltaTime;

        if (hourTimer >= secondInHour)
        {
            hour++;
            hourTimer = 0;

            if (hour == 24)
            {
                hour = 0;
            }

            timeSR.sprite = times[hour];
        }
    }

    private void lightManager()
    {
        if (hour > 15 && hour < 22 && globalLight.intensity > 0)
        {
            globalLight.intensity -= (float)((1.0 / 4.0 / (double)secondInHour) * Time.deltaTime);
            playerLight.intensity += (float)((1.0 / 4.0 / (double)secondInHour) * Time.deltaTime);
        }
        
        if (hour > 5 && hour < 12 && globalLight.intensity < 1)
        {
            globalLight.intensity += (float)((1.0 / 4.0 / (double)secondInHour) * Time.deltaTime);
            playerLight.intensity -= (float)((1.0 / 4.0 / (double)secondInHour) * Time.deltaTime);
        }

        //Fixnutí kvůli desetinám, mohlo by se nastakovat a dělat ošklivé světlo
        if (hour == 12)
        {
            globalLight.intensity = 1;
            playerLight.intensity = 0;
        }
    }
}
