using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [Header("Money")]
    [Space(10)]
    public float money;
    public float moneyPerSecond;

    [Space(10)]
    public float rocketIncomePerSecond;
    public float RestaurantIncomePerSecond;

    [Space(40)]

    [SerializeField] RocketManager rocketManagerCS;

    private void Awake()
    {
        money = PlayerPrefs.GetFloat("Money");
    }
    void Start()
    {
        rocketManagerCS = GameObject.FindObjectOfType<RocketManager>();

    }


    public void UpdateMoneyPerSecond()
    {
        moneyPerSecond = RestaurantIncomePerSecond + rocketIncomePerSecond;
    }
}
