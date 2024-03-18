using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneyMultiplyer : MonoBehaviour
{

    [Header("All Money Multiplier")]
    public float[] moneyMulti;
    public float[] moneyMultiCost;
    public int moneyMultiLevel = 0;
    [Space(40)]

    [Header("Rocket Money Multiplier")]
    public float[] rocketmoneyMulti;
    public float[] rocketmoneyMultiCost;
    public int rocketmoneyMultiLevel = 0;
    [Space(40)]

    [Header("Restaurant Money Multiplier")]
    public float[] restaurantmoneyMulti;
    public float[] restaurentmoneyMultiCost;
    public int restaurantmoneyMultiLevel = 0;
    [Space(40)]

    [Header("Mine Money Multiplier")]
    public float[] minemoneyMulti;
    public float[] minemoneyMultiCost;
    public int minemoneyMultiLevel = 0;
    [Space(40)]

    
    [Header("Sprite Update Level")]
    public float[] UpdateSpritesLevel;
    [SerializeField] int Spritenumber;
    public Sprite[] Main_Building_Spirtes;
    public SpriteRenderer Main_Building_Spirte;
    int currentspritelevel;
    [Space(40)]

    public float rocket_multiplier;
    public float restaurant_multipier;
    public float mine_multiplier;

    MoneyManager moneyManagerCS;
    [SerializeField]TextMeshProUGUI Multiplier_cost;
    [SerializeField] TextMeshProUGUI RocketMultiplier_cost;
    [SerializeField] TextMeshProUGUI RestaurantMultiplier_cost;
    BFN_ExampleComponent formatCS;

    private void Start()
    {
        moneyManagerCS = GameObject.FindObjectOfType<MoneyManager>();
        formatCS = GameObject.FindAnyObjectByType<BFN_ExampleComponent>();
        moneyManagerCS.moneyMultiplier = moneyMulti[moneyMultiLevel];
        UpdateInterface();
    }

    public void UpdateMultiplyer()
    {
        if (moneyManagerCS.money >= moneyMultiCost[moneyMultiLevel])        //wenn genug geld am konto ist
        {
            moneyManagerCS.money -= moneyMultiCost[moneyMultiLevel];
            moneyMultiLevel += 1;
            UpdateInterface();
            UpdateSprite();
        }
        moneyManagerCS.moneyMultiplier = moneyMulti[moneyMultiLevel];
        moneyManagerCS.UpdateMoneyPerSecond();
    }

    public void rocketUpdateMultiplyer()
    {
        if (moneyManagerCS.money >= rocketmoneyMultiCost[rocketmoneyMultiLevel])        //wenn genug geld am konto ist
        {
            moneyManagerCS.money -= rocketmoneyMultiCost[rocketmoneyMultiLevel];
            rocketmoneyMultiLevel += 1;
            UpdateInterface();
            UpdateSprite();
        }
        moneyManagerCS.rocketmoneyMultiplier = rocketmoneyMulti[rocketmoneyMultiLevel];
        moneyManagerCS.UpdateMoneyPerSecond();
    }

    public void restaurantUpdateMultiplyer()
    {
        if (moneyManagerCS.money >= restaurentmoneyMultiCost[restaurantmoneyMultiLevel])        //wenn genug geld am konto ist
        {
            moneyManagerCS.money -= restaurentmoneyMultiCost[restaurantmoneyMultiLevel];
            restaurantmoneyMultiLevel += 1;
            UpdateInterface();
            UpdateSprite();
        }
        moneyManagerCS.restaurantmoneyMultiplier = restaurantmoneyMulti[restaurantmoneyMultiLevel];
        moneyManagerCS.UpdateMoneyPerSecond();
    }


    public void mineUpdateMultiplyer()
    {
        if (moneyManagerCS.money >= minemoneyMultiCost[minemoneyMultiLevel])        //wenn genug geld am konto ist
        {
            moneyManagerCS.money -= minemoneyMultiCost[minemoneyMultiLevel];
            minemoneyMultiLevel += 1;
            UpdateInterface();
            UpdateSprite();
        }
        moneyManagerCS.MinemoneyMultiplier = minemoneyMulti[minemoneyMultiLevel];
        moneyManagerCS.UpdateMoneyPerSecond();
    }


    public void RocketMultipier(float a)
    {
        rocket_multiplier += a;
    }

    public void RestaurantMultipier(float a)
    {
        restaurant_multipier += a;
    }

    public void MineMultiplier(float a)
    {
        mine_multiplier += a;
    }


    public void UpdateInterface()
    {
        Multiplier_cost.text = formatCS.Shorten_number(moneyMultiCost[moneyMultiLevel]);
        RocketMultiplier_cost.text = formatCS.Shorten_number(rocketmoneyMultiCost[rocketmoneyMultiLevel]);
        RestaurantMultiplier_cost.text = formatCS.Shorten_number(restaurentmoneyMultiCost[restaurantmoneyMultiLevel]);
    }

    public void UpdateSprite()
    {
        for (int i = 0; i < UpdateSpritesLevel.Length; i++)
        {
            if (restaurantmoneyMultiLevel + rocketmoneyMultiLevel + moneyMultiLevel == UpdateSpritesLevel[i])
            {
                Debug.Log("Sprite +1");
                UpdateSpritebyOne();
            }
        }

    }

    void UpdateSpritebyOne()
    {
        if (Spritenumber < Main_Building_Spirtes.Length)
        {
            Debug.Log("Function");
            Main_Building_Spirte.sprite = Main_Building_Spirtes[Spritenumber];

            Spritenumber++;
        }
    }
}
