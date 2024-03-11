using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    [SerializeField] float asteroidMoney;
    
    
    BFN_ExampleComponent formatCS;
    MoneyManager moneyManagerCS;
    [SerializeField] Animator m_Animator;

    private void Awake()
    {
        moneyManagerCS = GameObject.FindObjectOfType<MoneyManager>();
        formatCS = GameObject.FindAnyObjectByType<BFN_ExampleComponent>();
        m_Animator = gameObject.GetComponent<Animator>();
        m_Animator.SetBool("Meteroid_Start", true);
       
    }

    public void AsteroidClicked()
    {
        asteroidMoney = moneyManagerCS.moneyPerSecond * Random.Range(30, 100);
        moneyManagerCS.AddMoneyOnly(asteroidMoney);
        Destroy(gameObject);
        
    }

    
}
