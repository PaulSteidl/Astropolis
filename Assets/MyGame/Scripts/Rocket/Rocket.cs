using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

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

    [Header("Sprite Update Level")]
    public float[] UpdateSpritesLevel;
    [SerializeField] int Spritenumber;
    public Sprite[] Main_Building_Spirtes;
    public SpriteRenderer Main_Building_Spirte;
    public VideoClip[] Main_Building_Clips;
    public VideoPlayer Main_Building_Video;
    int currentspritelevel;
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
        Invoke("TF", 0.1f);
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
        Invoke("LF", 0.1f);
    }
    void LF()
    {
        rocketAnim.SetBool("Landing", false);
    }
    void TF()
    {
        rocketAnim.SetBool("Start", false);
    }



    float MoneyPerRocket()
    {
        float moneyMadeRocket = moneyPerPerson * peoplePerRocket;
        return moneyMadeRocket;
    }

    public void UpdateSprite()
    {
        for (int i = 0; i < UpdateSpritesLevel.Length; i++)
        {
            if (peoplePerRocket == UpdateSpritesLevel[i])
            {
                Debug.Log("Sprite +1");
                UpdateSpritebyOne();
            }
        }

    }

    void UpdateSpritebyOne()
    {
        if (Spritenumber < Main_Building_Spirtes.Length)
        {
            Debug.Log("Function");
            Main_Building_Spirte.sprite = Main_Building_Spirtes[Spritenumber];
            Main_Building_Video.clip = Main_Building_Clips[Spritenumber];
            upgradeSprite.Play();
            Spritenumber++;
        }
    }

}
