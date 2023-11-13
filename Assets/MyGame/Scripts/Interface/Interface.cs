using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interface : MonoBehaviour
{
    [SerializeField] GameObject restaurant;
    [SerializeField] Restaurant restaurantCS;

    void Start()
    {
        restaurantCS = GameObject.FindAnyObjectByType<Restaurant>();
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
    public void RestaurantUpgrade()
    {
        restaurantCS.MoneyUpgrade();
    }

}
