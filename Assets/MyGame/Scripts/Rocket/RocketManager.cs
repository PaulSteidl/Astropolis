using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketManager : MonoBehaviour
{
    public float moneyMade;
    public float moneyPerPerson;
    public float peoplePerRocket;
    public float rocketComebackTime;
    public float rocketTakeOffTime;


    [SerializeField] bool rocketStarted, automaticAllowed;

    void Start()
    {
        StartCoroutine("TakeOff");
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeOffOnTouch(); //testzwecke  touch simu        
        }

        if (rocketStarted)
        {
            automaticAllowed = false;
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
        moneyMade += MoneyPerRocket();
        rocketStarted = false;


        //automaticAllowed = true;
        
        
        //yield return new WaitForSeconds(rocketTakeOffTime);   //automatische Start Zeit    

        
       
        
        //if (automaticAllowed)
        //{
        //    StartCoroutine("TakeOff");    
        //}      
    }


    float MoneyPerRocket()
    {
        float moneyMadeRocket = moneyPerPerson * peoplePerRocket;
        return moneyMadeRocket;
    }
}
