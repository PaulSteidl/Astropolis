using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Interface : MonoBehaviour
{
    public GameObject MoneyMadeOffline;
    [SerializeField] GameObject MoneyMultiplierInterface;
    [SerializeField] GameObject restaurant, rocket, mine, cafe;
    [SerializeField] GameObject Buying_mine, Buying_rocket, Buying_restaurant, Buying_cafe;
    [SerializeField] Restaurant restaurantCS;
    [SerializeField] Mine mineCS;
    [SerializeField] Rocket rocketCS;
    [SerializeField] RocketUpdate rocketUpdateCS;

    bool Bought_Mine, Bought_restaurant, Bought_cafe;

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
            if (Bought_restaurant)
            {
                restaurant.SetActive(!restaurant.activeSelf);
                restaurantCS.UpdateInterface();
            }

            else
            {
                Buying_restaurant.SetActive(!Buying_restaurant.activeSelf);
            }
        }
    }

    public void MineOn()
    {
        if (Time.time - TouchStartTime <= 0.1)
            if (Bought_Mine)
            {
                mine.SetActive(!mine.activeSelf);
                mineCS.UpdateInterface();
            }

            else
            {
                Buying_mine.SetActive(!Buying_mine.activeSelf);
            }


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
        {
            rocket.SetActive(!rocket.activeSelf); 
            rocketUpdateCS.UpdateInterface();
        }
    }








}
