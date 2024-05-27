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

    [Header("Anzahl")]
    public float anzahl;
    public float[] anzahlCost;
    public int anzahlLevel = 0;
    public GameObject[] rockets;

    [SerializeField] RocketManager rocketManagerCS;
    [SerializeField] MoneyManager moneyManagerCS;
    [SerializeField] Rocket[] rocketCS;

    [SerializeField] TextMeshProUGUI AnzahlText, AnzahlCostText, MoneyCostText, MoneyIncomeText, PeopleCostText, PeopleIncomeText, ComeBackCostText, ComeBackIncomeText, TakeOffCostText, TakeOffIncomeText;
    [SerializeField] BFN_ExampleComponent formatCS;

    [SerializeField] GameObject[] rocketsPic, rocketsButtons;

    private void Start()
    {
        rocketManagerCS = GameObject.FindObjectOfType<RocketManager>();
        moneyManagerCS = GameObject.FindObjectOfType<MoneyManager>();
        
        rocketCS = GameObject.FindObjectsOfType<Rocket>();
        formatCS = GameObject.FindAnyObjectByType<BFN_ExampleComponent>();

        AnzahlCostText.text = anzahlCost[anzahlLevel].ToString();

        for (int i = 0; i < rockets.Length; i++)
        {
            if (anzahl > i)
            {
                rockets[i].SetActive(true);

            }
        }
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
            for (int i = 0; i < rocketCS.Length -1; i++)
            {
                rocketCS[i].moneyPerPerson = moneyUpdateIncome;

            }
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
            for (int i = 0; i < rocketCS.Length - 1; i++)
            {
                
                rocketCS[i].peoplePerRocket = peopleUpdateNumber[peopleLevel];

            }
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
            for (int i = 0; i < rocketCS.Length - 1; i++)
            {

                rocketCS[i].rocketComebackTime = comebackTime[comebackLevel];
            }
            
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
            for (int i = 0; i < rocketCS.Length - 1; i++)
            {

                rocketCS[i].rocketTakeOffTime = takeOffTime;
            }
            
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

        ComeBackCostText.text = formatCS.Shorten_number(comebackCost);
        ComeBackIncomeText.text = formatCS.Shorten_number(comebackTime[comebackLevel]);

        TakeOffCostText.text = formatCS.Shorten_number(takeOffCost);
        TakeOffIncomeText.text = formatCS.Shorten_number(takeOffTime);

    }

    public void LevelUpdate()
    {
        MoneyUpdateCost();
        MoneyUpdateIncome();

        PeopleUpdateCost();
    }

    public void Anzahl()
    {
        rocketManagerCS.UpdateIncomePerSec(); //aktuaisiert anzeige

        if (moneyManagerCS.money >= anzahlCost[anzahlLevel])        //wenn genug geld am konto ist
        {
            moneyManagerCS.money -= anzahlCost[anzahlLevel];
            anzahlLevel += 1;
            AnzahlCostText.text = anzahlCost[anzahlLevel].ToString();
            anzahl += 1;
            AnzahlText.text = anzahl.ToString();
            for (int i = 0; i < rockets.Length; i++)
            {
                if (anzahl > i)
                {
                    rockets[i].SetActive(true);
                    rocketsPic[i].SetActive(true);
                    rocketsButtons[i].SetActive(true);

                }
            }

            UpdateInterface();
        }
    }
}

