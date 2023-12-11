using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Restaurant : MonoBehaviour
{
    public float updateCost;
    public float updateIncome;
    public int restaurantLevel;


    [SerializeField] TextMeshProUGUI updateCostText, incomeText, nextIncomeText;
    [SerializeField] BFN_ExampleComponent formatCS;


    MoneyManager moneyManagerCS;
    void Start()
    {
        moneyManagerCS = GameObject.Find("MoneyManager").GetComponent<MoneyManager>();
        InvokeRepeating("RestaurantMoney", 1, 1);
        formatCS = GameObject.FindAnyObjectByType<BFN_ExampleComponent>();
        
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
        moneyManagerCS.AddMoney(updateIncome); //Geld wird zum Konto hinzugefügt
    }

    public void MoneyUpgrade()
    {

        if (moneyManagerCS.money >= updateCost)        //wenn genug geld am konto ist
        {
            moneyManagerCS.money -= updateCost;
            LevelUpdate();
        }
    }

    public void LevelUpdate()
    {
        restaurantLevel += 1;
        updateCost = MoneyUpdateCost();
        updateIncome = MoneyUpdateIncome();
        moneyManagerCS.RestaurantIncomePerSecond = updateIncome;
        moneyManagerCS.UpdateMoneyPerSecond();
        NextUpdateIncome();
        UpdateInterface();
    }

    public float MoneyUpdateCost()
    {
        return 10 * Mathf.Pow(1.2f, restaurantLevel)+ 100 * restaurantLevel;

    }
    public float MoneyUpdateIncome()
    {
        return 10 * Mathf.Pow(1.05f, restaurantLevel);
    }

    
    
    public void UpdateInterface()
    {
        NextUpdateIncome();
        updateCostText.text = formatCS.Shorten_number(updateCost);
        incomeText.text = formatCS.Shorten_number(updateIncome);
    }
    
    public void NextUpdateIncome()
    {
        float nextIncome = 10 * Mathf.Pow(1.05f, restaurantLevel +1);
        float currentIncome = MoneyUpdateIncome();
        nextIncomeText.text = formatCS.Shorten_number((nextIncome - currentIncome));
    }
}
