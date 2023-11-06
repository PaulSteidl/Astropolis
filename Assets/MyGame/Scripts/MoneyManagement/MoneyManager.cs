using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [Header("Money")]
    [Space(10)]
    public float money;
    public float incomePerSecond;

    [Space(40)]

    [SerializeField] RocketManager rocketManagerCS;
    void Start()
    {
        rocketManagerCS = GameObject.FindObjectOfType<RocketManager>;

    }

    
    void Update()
    {
        
    }
}
