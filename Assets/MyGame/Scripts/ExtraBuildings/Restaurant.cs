using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restaurant : MonoBehaviour
{
    public float updateCost;
    public float updateIncome;
    public int restaurantLevel;

    MoneyManager moneyManagerCS;
    void Start()
    {
        moneyManagerCS = GameObject.Find("MoneyManager").GetComponent<MoneyManager>();
        InvokeRepeating("RestaurantMoney", 1, 1);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            MoneyUpgrade();
        }
    }

    public void RestaurantMoney()
    {
        moneyManagerCS.money += updateIncome;
    }

    public void MoneyUpgrade()
    {

        if (moneyManagerCS.money >= updateCost)        //wenn genug geld am konto ist
        {
            moneyManagerCS.money -= updateCost;
            restaurantLevel += 1;
            MoneyUpdateCost();
            MoneyUpdateIncome();
            moneyManagerCS.RestaurantIncomePerSecond = updateIncome;
            moneyManagerCS.UpdateMoneyPerSecond();

        }
    }

    public void MoneyUpdateCost()
    {
        updateCost = 10 * Mathf.Pow(1.2f, restaurantLevel)+ 100 * restaurantLevel;
    }
    public void MoneyUpdateIncome()
    {
        updateIncome = 10 * Mathf.Pow(1.05f, restaurantLevel);
    }
}
