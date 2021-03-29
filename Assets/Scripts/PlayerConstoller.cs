using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerConstoller : MonoBehaviour
{
    Player player;
    UIData output;
    public GameObject Black;

    void Start()
    {
        player = this.gameObject.GetComponent<Player>();
        output = GameObject.Find("CanvasDynamic").GetComponent<UIData>();
        Black.SetActive(false);
    }

    void Update()
    {
        Controllers();
    }

    void FixedUpdate()
    {
        player.Hunger -= Time.fixedDeltaTime / player.HungerDecreaseRate;
        player.Thirst -= Time.fixedDeltaTime / player.WaterDecreaseRate;
        player.Sleep -= Time.fixedDeltaTime / player.SleepDecreaseRate;
    }

  

    private void Controllers()
    {
        HungerController(player.Hunger);
        ThirstController(player.Thirst);
        SleepController(player.Sleep);
    }
    /// <summary>
    /// hlídá stav hladu
    /// </summary>
    /// <param name="hunger">hlad</param>
    private void HungerController(float hunger)
    {
        if ((hunger <= 50) && (hunger > 49.9f))
        {
            output.SetWarningText("you're getting hungry", 5, Color.red);
        }
        else if ((hunger <= 25) && (hunger > 24.9f))
        {
            output.SetWarningText("you're very getting hungry", 5, Color.red);
        }
        else if ((hunger <= 10) && (hunger > 9.9f))
        {
            output.SetWarningText("you are extremely hungry", 5, Color.red);
        }
        else if (hunger == 1)
        {
            output.SetWarningText("you will soon starve", 5, Color.red);
        }
        else if (hunger <= 0)
        {
            output.SetWarningText("You died of hunger", 5, Color.red);
            Death();
        }

    }

    /// <summary>
    /// hlídá stav žízně
    /// </summary>
    /// <param name="thirst">žízeň</param>
    private void ThirstController(float thirst)
    {
        if ((thirst <= 50) && (thirst > 49.9f))
        {
            output.SetWarningText("you're getting thirsty", 5, Color.red);
        }
        else if ((thirst <= 25) && (thirst > 24.9f))
        {
            output.SetWarningText("you're very getting thirsty", 5, Color.red);
        }
        else if ((thirst <= 10) && (thirst > 9.9f))
        {
            output.SetWarningText("you are extremely thirsty", 5, Color.red);
        }
        else if (thirst == 1)
        {
            output.SetWarningText("you will soon die of thirst", 5, Color.red);
        }
        else if (thirst <= 0)
        {
            output.SetWarningText("You died of thirst", 5, Color.red);
            Death();
        }

    }

    /// <summary>
    /// smrt...načte AfterDeath scénu
    /// </summary>
    private void Death()
    {
        SceneManager.LoadScene("AfterDeath");
    }

    /// <summary>
    /// hlídá stav spánku, upomíná hráče
    /// </summary>
    /// <param name="sleep">spánek</param>
    private void SleepController(float sleep)
    {
        if ((sleep <= 50) && (sleep > 49.9f))
        {
            output.SetWarningText("you're getting tired", 5, Color.red);
        }
        else if ((sleep <= 25) && (sleep > 24.9f))
        {
            output.SetWarningText("you're very getting tired", 5, Color.red);
        }
        else if ((sleep <= 10) && (sleep > 9.9f))
        {
            player.IsCorountineStarted = false;
            output.SetWarningText("you are extremely tired", 5, Color.red);
        }
        else if (sleep == 1)
        {
            output.SetWarningText("you will soon fall asleep", 5, Color.red);
        }
        else if (sleep <= 0)
        {
            output.SetWarningText("you fell asleep", 5, Color.red);
            if (!player.IsCorountineStarted)
                StartCoroutine(Unconsciousness(5, 4, 25));
        }

    }

    /// <summary>
    /// omdlení/spánek přetočí čas
    /// </summary>
    /// <param name="time">kolik sekund má uplynout</param>
    /// <param name="speed">jakou rychlostí</param>
    /// <param name="sleep">jaký bude stav spánku na konci cyklu</param>
    public IEnumerator Unconsciousness(float time, int speed, int sleep)
    {
        FindObjectOfType<AudioManager>().Play("night");
        player.IsCorountineStarted = true;
        player.MovementSpeed = 0;
        Black.SetActive(true);
        Time.timeScale = speed;
        yield return new WaitForSeconds(time * speed);
        Time.timeScale = 1;
        player.Sleep = sleep;
        Black.SetActive(false);
        player.MovementSpeed = 4;
        output.SetWarningText("You wake up.", 3, Color.green);
        FindObjectOfType<AudioManager>().Stop("night");
        FindObjectOfType<AudioManager>().Play("rooster");

    }

    /// <summary>
    /// zničí item v ruce, nastaví SetItemInHandBool na false
    /// </summary>
    public void DestroyItemInHand()
    {
        GameObject item;
        item = GameObject.Find("rightHandItemPosition").transform.GetChild(0).gameObject;
        Destroy(item);
        item.transform.parent = null;
    }

    /// <summary>
    /// zjistím zda má postava dost peněz
    /// </summary>
    /// <param name="money">peníze o který chci zjistit zda na to mám</param>
    /// <returns>ano/ne</returns>
    public bool EnoughtMoney(int money)
    {
        if (player.golds >= money)
            return true;
        else
        {
            output.SetWarningText("You dont have enougt golds", 2, Color.red);
            return false;
        }

    }

}
