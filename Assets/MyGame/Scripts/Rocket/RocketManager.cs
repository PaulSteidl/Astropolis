using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketManager : MonoBehaviour
{
    public float rocketsMoneyMade;
    public float rocketsNumber;
    public float incomePerSec;

    [SerializeField] Rocket rocketCS;
    [SerializeField] MoneyManager moneyManagerCS;

    private void Start()
    {
        rocketCS = GameObject.Find("Rocket").GetComponent<Rocket>();
        moneyManagerCS = GameObject.Find("MoneyManager").GetComponent<MoneyManager>();
    }

    private void Update()
    {
        
    }

    public void MoneyComes(float m)
    {
        moneyManagerCS.Money += m; //Geld das von Rackete produziert wird
    }

    public void UpdateIncomePerSec()
    {
        incomePerSec = rocketCS.moneyPerPerson * rocketCS.peoplePerRocket / (rocketCS.rocketComebackTime + rocketCS.rocketTakeOffTime);
    }
}
