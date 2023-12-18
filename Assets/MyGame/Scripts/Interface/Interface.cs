using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interface : MonoBehaviour
{
    public GameObject MoneyMadeOffline;
    [SerializeField] GameObject restaurant, rocket;
    [SerializeField] Restaurant restaurantCS;
    [SerializeField] Rocket rocketCS;
    [SerializeField] RocketUpdate rocketUpdateCS;

    void Start()
    {
        restaurantCS = GameObject.FindAnyObjectByType<Restaurant>();
        rocketCS = GameObject.FindAnyObjectByType<Rocket>();
        rocketUpdateCS = GameObject.FindAnyObjectByType<RocketUpdate>();
        if (PlayerPrefs.HasKey("sysString") && PlayerPrefs.HasKey("MoneyPerSecond") && PlayerPrefs.GetInt("FirstStartup") == 1)
        {
            MoneyMadeOfflineSwitch();
        }
    }

    public void RestaurantOn()
    {
        restaurant.SetActive(true);
        restaurantCS.UpdateInterface();
    }
    public void RestaurantOff()
    {
        restaurant.SetActive(false);
    }
    public void MoneyMadeOfflineSwitch()
    {
        MoneyMadeOffline.SetActive(!MoneyMadeOffline.gameObject.activeSelf);
    }
   
    
    public void RestaurantUpgrade()
    {
        restaurantCS.MoneyUpgrade();
    }
    public void RocketUpgrade()
    {
        
    }



    public void RocketOn()
    {
        rocket.SetActive(true);
        rocketUpdateCS.UpdateInterface();
    }
    public void RocketOff()
    {
        rocket.SetActive(false);
    }








}
