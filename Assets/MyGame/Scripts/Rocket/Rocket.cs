using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [Header("Money Parameter")]
    
    public float moneyPerPerson;
    public float peoplePerRocket;
    public float rocketComebackTime;
    public float rocketTakeOffTime;
    [Space(40)]

    public float timeUntilTakeOff;

    [SerializeField] bool rocketStarted;
    [SerializeField] RocketManager rocketManagerCS;

    void Start()
    {
        StartCoroutine("TakeOff");
        timeUntilTakeOff = rocketTakeOffTime;


        rocketManagerCS = GameObject.Find("RocketManager").GetComponent<RocketManager>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeOffOnTouch(); //testzwecke  touch simu        
        }

        
        if (rocketStarted)                             //Automatischer Start
        {
            timeUntilTakeOff = rocketTakeOffTime;
        }
        else
        {
            timeUntilTakeOff -= Time.deltaTime;
        }
        
        if (timeUntilTakeOff == 0)
        {
            StartCoroutine("TakeOff");
        }



    }
    public void TakeOffOnTouch()
    {       
        if (!rocketStarted)                                 //Touch Start
        {
            StartCoroutine("TakeOff");        
        }
    }

    public IEnumerator TakeOff()
    {
        rocketStarted = true;
        yield return new WaitForSeconds(rocketComebackTime);    // Flug Zeit von Rackete
        rocketManagerCS.MoneyComes(MoneyPerRocket());   //Geld wird erhöht
        rocketStarted = false;     
    }


    float MoneyPerRocket()
    {
        float moneyMadeRocket = moneyPerPerson * peoplePerRocket;
        return moneyMadeRocket;
    }
}
