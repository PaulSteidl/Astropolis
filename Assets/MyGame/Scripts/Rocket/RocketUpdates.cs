using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketUpdate : MonoBehaviour
{
   

    [Header("MoneyPerPerson")]
    public float MoneyUpdateCost;
    public float MoneyUpdateNew;
    public int level;
    [Space(40)]


    [SerializeField] RocketManager rocketManagerCS;
    [SerializeField] MoneyManager moneyManagerCS;

    private void Start()
    {
        rocketManagerCS = GameObject.Find("RocketManager").GetComponent<RocketManager>();
        moneyManagerCS = GameObject.Find("MoneyManager").GetComponent<MoneyManager>();
        
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            rocketManagerCS.UpdateIncomePerSec(); //muss bei jedem Update dabei stehen
            MoneyUpgrade();
        }
    }

    public void MoneyUpgrade()
    {
        if (moneyManagerCS.Money >= MoneyUpdateCost)
        {
            moneyManagerCS.Money -= MoneyUpdateCost;
        }
    }
}
