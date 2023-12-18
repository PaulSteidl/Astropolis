using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    [Header("Money")]
    [Space(10)]
    public float money;
    public float moneyPerSecond;
    public float moneyMultiplyer;

    [Space(10)]
    public float rocketIncomePerSecond;
    public float RestaurantIncomePerSecond;

    [Space(40)]

    [SerializeField] RocketManager rocketManagerCS;
    [SerializeField] BFN_ExampleComponent formatCS;

    [SerializeField] TextMeshProUGUI moneyText, moneyPerSecText;

    void Awake()
    {
        money = PlayerPrefs.GetFloat("Money");
        rocketManagerCS = GameObject.FindObjectOfType<RocketManager>();
        formatCS = GameObject.FindAnyObjectByType<BFN_ExampleComponent>();
        moneyMultiplyer = GameObject.FindAnyObjectByType<MoneyMultiplyer>().amount;
    }

    private void Update()
    {
        moneyText.text = formatCS.Shorten_number(money);
    }

    public void UpdateMoneyPerSecond()
    {
        RestaurantIncomePerSecond = GameObject.FindAnyObjectByType<Restaurant>().updateIncome;
        rocketIncomePerSecond = GameObject.FindAnyObjectByType<RocketManager>().incomePerSecR;
        moneyPerSecond = RestaurantIncomePerSecond + rocketIncomePerSecond;
        moneyPerSecText.text = formatCS.Shorten_number(moneyPerSecond);

    }

    public void Multiplyer()
    {
        moneyMultiplyer = GameObject.FindAnyObjectByType<MoneyMultiplyer>().amount;
    }

    public void AddMoney(float a)
    {
        money = money + a * moneyMultiplyer;
    }
}
