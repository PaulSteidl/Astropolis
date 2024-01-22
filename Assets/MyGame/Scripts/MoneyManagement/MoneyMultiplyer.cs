using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyMultiplyer : MonoBehaviour
{

    [Header("MoneyPerPerson")]
    public float[] moneyMulti;
    public float[] moneyMultiCost;
    public int moneyMultiLevel = 0;
    [Space(40)]


    public float rocket_multiplier;
    public float restaurant_multipier;
    public float mine_multiplier;

    MoneyManager moneyManagerCS;

    private void Start()
    {
        moneyManagerCS = GameObject.FindObjectOfType<MoneyManager>();
    }

    public void UpdateMultiplyer()
    {
        if (moneyManagerCS.money >= moneyMultiCost[moneyMultiLevel])        //wenn genug geld am konto ist
        {
            moneyManagerCS.money -= moneyMultiCost[moneyMultiLevel];
            moneyMultiLevel += 1;
            UpdateInterface();
        }
        moneyManagerCS.moneyMultiplier = moneyMulti[moneyMultiLevel];

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

    }
}
