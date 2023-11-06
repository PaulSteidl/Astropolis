using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interface : MonoBehaviour
{
    [SerializeField] GameObject restaurant;
    void Start()
    {
        
    }

    public void Restaurant()
    {
        restaurant.SetActive(!restaurant.activeSelf);
    }
}
