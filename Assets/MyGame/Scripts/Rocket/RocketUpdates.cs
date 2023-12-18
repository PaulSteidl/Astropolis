using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RocketUpdate : MonoBehaviour
{
   

    [Header("MoneyPerPerson")]
    public float moneyUpdateIncome;
    public float moneyUpdateCost;  
    public int moneyLevel = 0;
    [Space(40)]

    [Header("peoplePerRocket")]
    public float[] peopleUpdateNumber;
    public float peopleUpdateCost;
    public int peopleLevel = 0;
    [Space(40)]

    [Header("rocketComebackTime")]
    public float[] comebackTime;
    public float comebackCost;
    public int comebackLevel = 0;
    [Space(40)]

    [Header("rocketTakeOffTime")]
    public float takeOffTime;
    public float takeOffCost;
    public int takeOffLevel = 0;
    [Space(40)]


    [SerializeField] RocketManager rocketManagerCS;
    [SerializeField] MoneyManager moneyManagerCS;
    [SerializeField] Rocket rocketCS;

    [SerializeField] TextMeshProUGUI MoneyCostText, MoneyIncomeText, PeopleCostText, PeopleIncomeText, ComeBackCostText, ComeBackIncomeText, TakeOffCostText, TakeOffIncomeText;
    [SerializeField] BFN_ExampleComponent formatCS;

    private void Start()
    {
        rocketManagerCS = GameObject.FindObjectOfType<RocketManager>();
        moneyManagerCS = GameObject.FindObjectOfType<MoneyManager>();
        rocketCS = GameObject.FindObjectOfType<Rocket>();
        formatCS = GameObject.FindAnyObjectByType<BFN_ExampleComponent>();


        UpdateInterface();
        rocketManagerCS.UpdateIncomePerSec();
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

        if (Input.GetKeyDown(KeyCode.T))
        {
            rocketManagerCS.UpdateIncomePerSec(); //muss bei jedem Update dabei stehen
            TakeOffUpgrade();

        }
    }



    public void MoneyUpgrade()
    {
        Debug.Log("jo");
        rocketManagerCS.UpdateIncomePerSec(); //aktuaisiert anzeige
        

        if (moneyManagerCS.money >= moneyUpdateCost)        //wenn genug geld am konto ist
        {
            moneyManagerCS.money -= moneyUpdateCost;
            moneyLevel += 1;
            MoneyUpdateCost();
            MoneyUpdateIncome();
            rocketCS.moneyPerPerson = moneyUpdateIncome;
            UpdateInterface();
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
        rocketManagerCS.UpdateIncomePerSec(); //aktuaisiert anzeige per sec

        if (moneyManagerCS.money >= peopleUpdateCost)        //wenn genug geld am konto ist
        {
            moneyManagerCS.money -= peopleUpdateCost;
            peopleLevel += 1;
            PeopleUpdateCost();
            rocketCS.peoplePerRocket = peopleUpdateNumber[peopleLevel];
            UpdateInterface();
        }
    }
    public void PeopleUpdateCost()
    {
        peopleUpdateCost = 10 * Mathf.Pow(4, peopleLevel);
    }




    public void ComebackUpgrade()
    {
        rocketManagerCS.UpdateIncomePerSec(); //aktuaisiert anzeige

        if (moneyManagerCS.money >= comebackCost)        //wenn genug geld am konto ist
        {
            moneyManagerCS.money -= comebackCost;
            comebackLevel += 1;
            ComebackCost();
            rocketCS.rocketComebackTime = comebackTime[comebackLevel];
            UpdateInterface();
        }
    }
    public void ComebackCost()
    {
        comebackCost = 5 * Mathf.Pow(3.5f, comebackLevel);
    }



    public void TakeOffUpgrade()
    {
        rocketManagerCS.UpdateIncomePerSec(); //aktuaisiert anzeige

        if (moneyManagerCS.money >= takeOffCost)        //wenn genug geld am konto ist
        {
            moneyManagerCS.money -= takeOffCost;
            takeOffLevel += 1;
            TakeOffCost();
            TakeOffTime();
            rocketCS.rocketTakeOffTime = takeOffTime;
            UpdateInterface();
        }
    }
    public void TakeOffCost()
    {
        takeOffCost = 100 * Mathf.Pow(1.17f, takeOffLevel);
       
    }
    public void TakeOffTime()
    {
        takeOffTime = 40 * Mathf.Pow(0.97f, takeOffLevel);

    }






    public void UpdateInterface()
    {
        MoneyCostText.text = formatCS.Shorten_number(moneyUpdateCost);
        MoneyIncomeText.text = formatCS.Shorten_number(moneyUpdateIncome);

        PeopleCostText.text = formatCS.Shorten_number(peopleUpdateCost);
        Debug.Log(peopleLevel);
        PeopleIncomeText.text = formatCS.Shorten_number(peopleUpdateNumber[peopleLevel]);
        



    }

    public void LevelUpdate()
    {

    }
}

