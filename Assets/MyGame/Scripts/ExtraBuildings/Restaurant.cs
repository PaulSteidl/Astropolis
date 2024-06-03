using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Restaurant : MonoBehaviour
{
    public AudioSource upgradeS; 
    public float updateCost;
    public float updateIncome;
    public int restaurantLevel;


    [SerializeField] TextMeshProUGUI updateCostText, incomeText, nextIncomeText;
    [SerializeField] BFN_ExampleComponent formatCS;

    [Header("Sprite Update Level")]
    public float[] UpdateSpritesLevel;
    [SerializeField] int Spritenumber;
    public Sprite[] Main_Building_Spirtes;
    public SpriteRenderer Main_Building_Spirte;
    int currentspritelevel;
    [Space(40)]



    MoneyManager moneyManagerCS;
    void Awake()
    {
        moneyManagerCS = GameObject.FindObjectOfType<MoneyManager>();
        InvokeRepeating("RestaurantMoney", 1, 1);
        formatCS = GameObject.FindAnyObjectByType<BFN_ExampleComponent>();
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            MoneyUpgrade();
        }
    }

    public void RestaurantMoney()
    {
        moneyManagerCS.AddMoney(updateIncome); //Geld wird zum Konto hinzugefügt
    }

    public void MoneyUpgrade()
    {

        if (moneyManagerCS.money >= updateCost)        //wenn genug geld am konto ist
        {
            moneyManagerCS.money -= updateCost;
            restaurantLevel += 1;
            upgradeS.Play();
            LevelUpdate();
        }
    }

    public void LevelUpdate()
    {
        moneyManagerCS = GameObject.FindObjectOfType<MoneyManager>();
        updateCost = MoneyUpdateCost();
        updateIncome = MoneyUpdateIncome();
        moneyManagerCS.RestaurantIncomePerSecond = updateIncome;
        moneyManagerCS.UpdateMoneyPerSecond();
        NextUpdateIncome();
        UpdateInterface();
        UpdateSprite();
    }

    public float MoneyUpdateCost()
    {
        return 10 * Mathf.Pow(1.2f, restaurantLevel)+ 100 * restaurantLevel;

    }
    public float MoneyUpdateIncome()
    {
        return 10 * Mathf.Pow(1.05f, restaurantLevel);
    }

    
    
    public void UpdateInterface()
    {
        NextUpdateIncome();
        updateCostText.text = formatCS.Shorten_number(updateCost);
        incomeText.text = formatCS.Shorten_number(updateIncome);
    }
    
    public void NextUpdateIncome()
    {
        float nextIncome = 10 * Mathf.Pow(1.05f, restaurantLevel +1);
        float currentIncome = MoneyUpdateIncome();
        nextIncomeText.text = formatCS.Shorten_number((nextIncome - currentIncome));
    }
    public void UpdateSprite()
    {
        for (int i = 0; i < UpdateSpritesLevel.Length; i++)
        {
            if (restaurantLevel == UpdateSpritesLevel[i])
            {
                Debug.Log("Sprite +1");
                UpdateSpritebyOne();
            }
        }

    }

    void UpdateSpritebyOne()
    {
        if (Spritenumber < Main_Building_Spirtes.Length)
        {
            Debug.Log("Function");
            Main_Building_Spirte.sprite = Main_Building_Spirtes[Spritenumber];

            Spritenumber++;
        }
    }
}
