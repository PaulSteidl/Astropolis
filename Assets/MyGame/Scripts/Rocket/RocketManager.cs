using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketManager : MonoBehaviour
{
    public float rocketsMoneyMade;
    public float rocketsNumber;
    public float incomePerSecR;

    [SerializeField] Rocket rocketCS;
    [SerializeField] MoneyManager moneyManagerCS;

    private void Start()
    {
        rocketCS = GameObject.FindObjectOfType<Rocket>();
        moneyManagerCS = GameObject.FindObjectOfType<MoneyManager>();
    }

    private void Update()
    {
        
    }

    public void MoneyComes(float m)
    {
        moneyManagerCS.money += m; //Geld das von Rackete produziert wird
    }

    public void UpdateIncomePerSec()
    {
        incomePerSecR = rocketCS.moneyPerPerson * rocketCS.peoplePerRocket / (rocketCS.rocketComebackTime + rocketCS.rocketTakeOffTime);
        moneyManagerCS.rocketIncomePerSecond = incomePerSecR;
        moneyManagerCS.UpdateMoneyPerSecond();
    }
}
