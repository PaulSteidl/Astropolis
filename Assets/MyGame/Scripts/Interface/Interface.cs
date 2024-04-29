using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Interface : MonoBehaviour
{
    public GameObject MoneyMadeOffline;
    [SerializeField] GameObject MoneyMultiplierInterface;
    [SerializeField] GameObject restaurant, rocket, mine;
    [SerializeField] GameObject Buying_mine, Buying_rocket, Buying_restaurant;
    [SerializeField] Restaurant restaurantCS;
    [SerializeField] Mine mineCS;
    [SerializeField] Rocket rocketCS;
    [SerializeField] RocketUpdate rocketUpdateCS;

    bool Bought_Mine;

    float TouchStartTime;

    void Start()
    {
        restaurantCS = GameObject.FindAnyObjectByType<Restaurant>();
        mineCS = GameObject.FindAnyObjectByType<Mine>();
        rocketCS = GameObject.FindAnyObjectByType<Rocket>();
        rocketUpdateCS = GameObject.FindAnyObjectByType<RocketUpdate>();
        if (PlayerPrefs.HasKey("sysString") && PlayerPrefs.HasKey("MoneyPerSecond") && PlayerPrefs.GetInt("FirstStartup") == 1)
        {
            MoneyMadeOfflineSwitch();
        }
    }

    private void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                TouchStartTime = Time.time;
            }
        }
    }

    public void RestaurantOn()
    {
        if (Time.time - TouchStartTime <= 0.1)
        {
            restaurant.SetActive(true);
            restaurantCS.UpdateInterface();
        }
    }

    
    public void RestaurantOff()
    {
        if (Time.time - TouchStartTime <= 0.1)
            restaurantCS.UpdateInterface(); restaurant.SetActive(false);
    }

    public void MineOn()
    {
        if (Time.time - TouchStartTime <= 0.1)
            if (Bought_Mine)
            {
                mine.SetActive(true); mineCS.UpdateInterface();
            }

            else Buying_mine.SetActive(true);


    }
    public void MineOff()
    {
        if (Time.time - TouchStartTime <= 0.1)
            mine.SetActive(false);
    }

    public void MoneyMadeOfflineSwitch()
    {
        if (Time.time - TouchStartTime <= 0.1)
            MoneyMadeOffline.SetActive(!MoneyMadeOffline.gameObject.activeSelf);
    }
            

    public void MoneyMultiplierSwitch()
    {
        if (Time.time - TouchStartTime <= 0.1)
           MoneyMultiplierInterface.SetActive(!MoneyMultiplierInterface.gameObject.activeSelf);           
    }


    public void RestaurantUpgrade()
    {
        if (Time.time - TouchStartTime <= 0.1)
            restaurantCS.MoneyUpgrade();           
    }
    public void RocketUpgrade()
    {
        
    }



    public void RocketOn()
    {
        if (Time.time - TouchStartTime <= 0.1)
            rocket.SetActive(true); rocketUpdateCS.UpdateInterface();
    }
    public void RocketOff()
    {
        if (Time.time - TouchStartTime <= 0.1)
            rocket.SetActive(false);            
    }








}
