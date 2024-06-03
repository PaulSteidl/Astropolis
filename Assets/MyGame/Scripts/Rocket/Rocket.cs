using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public Animator rocketAnim;
    public AudioSource rocketTakeOff;
    public AudioSource rocketLanding;
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


        rocketManagerCS = GameObject.FindObjectOfType<RocketManager>();
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
        
        if (timeUntilTakeOff <= 0)
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
        rocketTakeOff.Play();                   
        rocketStarted = true;                   //Startet
        rocketAnim.SetBool("Start", true);
        if (rocketComebackTime >= 5)
        {
            Invoke("LandingSound", rocketComebackTime - 5);

        }
        else
        {
            LandingSound();
        }

        if (rocketComebackTime >= 3)
        {
            Invoke("LandingAnim", rocketComebackTime - 3);

        }
        else
        {
            LandingAnim();
        }


        yield return new WaitForSeconds(rocketComebackTime);    // Flug Zeit von Racketewährend in der Luft
                                                                                            //Landet--
        rocketManagerCS.MoneyComes(MoneyPerRocket());   //Geld wird erhöht
        rocketStarted = false;     
    }

    void LandingSound()
    {
        rocketLanding.Play();
    }
    void LandingAnim()
    {
        rocketAnim.SetBool("Landing", true);
    }


    float MoneyPerRocket()
    {
        float moneyMadeRocket = moneyPerPerson * peoplePerRocket;
        return moneyMadeRocket;
    }

    
}
