using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interface : MonoBehaviour
{
    public GameObject MoneyMadeOffline;
    [SerializeField] GameObject MoneyMultiplierInterface;
    [SerializeField] GameObject restaurant, rocket, mine, cafe;
    [SerializeField] GameObject Buying_mine, Buying_rocket, Buying_restaurant, Buying_cafe;
    [SerializeField] Restaurant restaurantCS;
    [SerializeField] Mine mineCS;
    [SerializeField] Cafe cafeCS;
    [SerializeField] Rocket rocketCS;
    [SerializeField] RocketUpdate rocketUpdateCS;
    [SerializeField] MoneyManager moneyManagerCS;
    [SerializeField] GameObject Mine_sprite, Cafe_sprite, Resaurat_sprite;
    [SerializeField] GameObject Mine_foundation_sprite, Cafe_foundation_sprite, Resaurat_foundation_sprite;

    [SerializeField] float buyCafe, buyRestaurant, buyMine;

    public bool Bought_Mine, Bought_restaurant, Bought_cafe;

    public int Bought_Mine_int, Bought_restaurant_int, Bought_cafe_int;

    float TouchStartTime;

    void Start()
    {
        restaurantCS = GameObject.FindAnyObjectByType<Restaurant>();
        mineCS = GameObject.FindAnyObjectByType<Mine>();
        rocketCS = GameObject.FindAnyObjectByType<Rocket>();
        rocketUpdateCS = GameObject.FindAnyObjectByType<RocketUpdate>();
        cafeCS = GameObject.FindAnyObjectByType<Cafe>();
        moneyManagerCS = GameObject.FindObjectOfType<MoneyManager>();
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
        {
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

    }

    public void CafeSwitch()
    {
        if (Time.time - TouchStartTime <= 0.1)
        {
            if (Bought_cafe)
            {
                cafe.SetActive(!cafe.activeSelf);
                cafeCS.UpdateInterface();
            }

            else
            {
                Buying_cafe.SetActive(!Buying_cafe.activeSelf);
            }
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





    public void BuyCafe()
    {

        if (moneyManagerCS.money >= buyCafe)        //wenn genug geld am konto ist
        {
            moneyManagerCS.money -= buyCafe;
            Bought_cafe = true;
            Cafe_foundation_sprite.SetActive(false);
            Buying_cafe.SetActive(false);
            Cafe_sprite.SetActive(true);
        }
    }
    public void BuyRestaurant()
    {

        if (moneyManagerCS.money >= buyRestaurant)        //wenn genug geld am konto ist
        {
            moneyManagerCS.money -= buyRestaurant;
            Bought_restaurant = true;
            Resaurat_foundation_sprite.SetActive(false);
            Buying_restaurant.SetActive(false);
            Resaurat_sprite.SetActive(true);
        }
    }
    public void BuyMine()
    {

        if (moneyManagerCS.money >= buyMine)        //wenn genug geld am konto ist
        {
            moneyManagerCS.money -= buyMine;
            Bought_Mine = true;
            Mine_foundation_sprite.SetActive(false);
            Buying_mine.SetActive(false);
            Mine_sprite.SetActive(true);
        }
    }

    private void OnApplicationQuit()
    {
        if (Bought_cafe)
        {
            Bought_cafe_int = 1;
        }
        else
        {
            Bought_cafe_int = 0;
        }

        if (Bought_Mine)
        {
            Bought_Mine_int = 1;
        }
        else
        {
            Bought_Mine_int = 0;
        }

        if (Buying_restaurant)
        {
            Bought_restaurant_int = 1;
        }
        else
        {
            Bought_restaurant_int = 0;
        }
    }
}
