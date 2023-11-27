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

    private void Awake()
    {
        money = PlayerPrefs.GetFloat("Money");
    }
    void Start()
    {
        rocketManagerCS = GameObject.FindObjectOfType<RocketManager>();
        formatCS = GameObject.FindAnyObjectByType<BFN_ExampleComponent>();
    }

    private void Update()
    {
        moneyText.text = formatCS.Shorten_number(money);
    }

    public void UpdateMoneyPerSecond()
    {
        moneyPerSecond = RestaurantIncomePerSecond + rocketIncomePerSecond;
        moneyPerSecText.text = formatCS.Shorten_number(moneyPerSecond);

    }

    public void AddMoney(float a)
    {
        float b = moneyMultiplyer;

        money = money +  a * b;
    }
}
