using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interface : MonoBehaviour
{
    [SerializeField] GameObject restaurant, rocket, MoneyMadeOffline;
    [SerializeField] Restaurant restaurantCS;
    [SerializeField] Rocket rocketCS;

    void Start()
    {
        restaurantCS = GameObject.FindAnyObjectByType<Restaurant>();
        rocketCS = GameObject.FindAnyObjectByType<Rocket>();
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
        MoneyMadeOffline.SetActive(false);
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
        //restaurantCS.UpdateInterface();
    }
    public void RocketOff()
    {
        rocket.SetActive(false);
    }








}
