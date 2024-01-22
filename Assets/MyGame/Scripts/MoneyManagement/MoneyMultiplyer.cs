using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyMultiplyer : MonoBehaviour
{

    public float Multiplier;
    public float rocket_multiplier;
    public float restaurant_multipier;
    public float mine_multiplier;

    public void UpdateMultiplyer(float a)
    {
        Multiplier =+ a;
    }

    public void RocketMultipier(float a)
    {
        rocket_multiplier =+ a;
    }

    public void RestaurantMultipier(float a)
    {
        restaurant_multipier =+ a;
    }

    public void MineMultiplier(float a)
    {
        mine_multiplier =+ a;
    }
}
