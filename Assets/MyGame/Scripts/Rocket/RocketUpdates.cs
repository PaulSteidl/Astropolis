using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketUpdate : MonoBehaviour
{
   

    [Header("MoneyPerPerson")]
    public float moneyUpdateIncome;
    public float moneyUpdateCost;  
    public int moneyLevel = -1;
    [Space(40)]

    [Header("peoplePerRocket")]
    public float[] peopleUpdateNumber;
    public float peopleUpdateCost;
    public int peopleLevel = -1;
    [Space(40)]

    [Header("rocketComebackTime")]
    public float[] comebackTime;
    public float comebackCost;
    public int comebackLevel = -1;
    [Space(40)]

    [Header("rocketTakeOffTime")]
    public float[] takeOffTime;
    public float takeOffCost;
    public int takeOffLevel = -1;
    [Space(40)]


    [SerializeField] RocketManager rocketManagerCS;
    [SerializeField] MoneyManager moneyManagerCS;
    [SerializeField] Rocket rocketCS;

    private void Start()
    {
        rocketManagerCS = GameObject.Find("RocketManager").GetComponent<RocketManager>();
        moneyManagerCS = GameObject.Find("MoneyManager").GetComponent<MoneyManager>();
        rocketCS = GameObject.Find("Rocket").GetComponent<Rocket>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            rocketManagerCS.UpdateIncomePerSec(); //muss bei jedem Update dabei stehen
            MoneyUpgrade();
            
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            rocketManagerCS.UpdateIncomePerSec(); //muss bei jedem Update dabei stehen
            PeopleUpgrade();

        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            rocketManagerCS.UpdateIncomePerSec(); //muss bei jedem Update dabei stehen
            ComebackUpgrade();

        }
    }


    public void MoneyUpgrade()
    {
        
        if (moneyManagerCS.Money >= moneyUpdateCost)        //wenn genug geld am konto ist
        {
            moneyManagerCS.Money -= moneyUpdateCost;
            moneyLevel += 1;
            MoneyUpdateCost();
            MoneyUpdateIncome();
            rocketCS.moneyPerPerson = moneyUpdateIncome;
        }
    }

    public void MoneyUpdateCost()
    {
        moneyUpdateCost = 150 * Mathf.Pow(1.19f, moneyLevel);
    }
    public void MoneyUpdateIncome()
    {
        moneyUpdateIncome = 5 * Mathf.Pow(1.1f, moneyLevel);  
    }


    public void PeopleUpgrade()
    {

        if (moneyManagerCS.Money >= peopleUpdateCost)        //wenn genug geld am konto ist
        {
            moneyManagerCS.Money -= peopleUpdateCost;
            peopleLevel += 1;
            PeopleUpdateCost();
            rocketCS.peoplePerRocket = peopleUpdateNumber[peopleLevel];
        }
    }
    public void PeopleUpdateCost()
    {
        peopleUpdateCost = 10 * Mathf.Pow(4, peopleLevel);
    }




    public void ComebackUpgrade()
    {

        if (moneyManagerCS.Money >= comebackCost)        //wenn genug geld am konto ist
        {
            moneyManagerCS.Money -= comebackCost;
            comebackLevel += 1;
            ComebackCost();
            rocketCS.rocketComebackTime = comebackTime[comebackLevel];
        }
    }
    public void ComebackCost()
    {
        comebackCost = 5 * Mathf.Pow(3.5f, comebackLevel);
    }



    public void TakeOffUpgrade()
    {

        if (moneyManagerCS.Money >= takeOffCost)        //wenn genug geld am konto ist
        {
            moneyManagerCS.Money -= takeOffCost;
            takeOffLevel += 1;
            TakeOffCost();
            rocketCS.rocketTakeOffTime = takeOffTime[takeOffLevel];
        }
    }
    public void TakeOffCost()
    {
        takeOffCost = 5 * Mathf.Pow(3.5f, takeOffLevel);
    }
    public void TakeOffIncome()
    {
        takeOffCost = 100 * Mathf.Pow(1.17f, takeOffLevel);
    }
}

