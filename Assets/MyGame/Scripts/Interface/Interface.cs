using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interface : MonoBehaviour
{
    [SerializeField] GameObject restaurant;
    [SerializeField] Restaurant restaurantCS;
    void Start()
    {
        
    }

    public void RestaurantOn()
    {
        restaurant.SetActive(true);
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
