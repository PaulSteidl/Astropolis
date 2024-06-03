using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cafe : MonoBehaviour
{
    public AudioSource upgradeS;
    public float updateCost;
    public float updateIncome;
    public int mineLevel;


    [SerializeField] TextMeshProUGUI updateCostText, incomeText, nextIncomeText;

    [Header("Sprite Update Level")]
    public float[] UpdateSpritesLevel;
    [SerializeField] int Spritenumber;
    public Sprite[] Main_Building_Spirtes;
    public SpriteRenderer Main_Building_Spirte;
    int currentspritelevel;
    [Space(40)]

    BFN_ExampleComponent formatCS;
    MoneyManager moneyManagerCS;
    void Awake()
    {
        moneyManagerCS = GameObject.FindObjectOfType<MoneyManager>();
        formatCS = GameObject.FindAnyObjectByType<BFN_ExampleComponent>();
        InvokeRepeating("RestaurantMoney", 1, 1);
        
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
            mineLevel += 1;
            upgradeS.Play();
            LevelUpdate();
        }
    }

    public void LevelUpdate()
    {
        moneyManagerCS = GameObject.FindObjectOfType<MoneyManager>();
        updateCost = MoneyUpdateCost();
        updateIncome = MoneyUpdateIncome();
        moneyManagerCS.MineIncomePerSecond = updateIncome;
        moneyManagerCS.UpdateMoneyPerSecond();
        NextUpdateIncome();
        UpdateInterface();
        UpdateSprite();
    }

    public float MoneyUpdateCost()
    {
        return 10 * Mathf.Pow(1.2f, mineLevel)+ 100 * mineLevel;

    }
    public float MoneyUpdateIncome()
    {
        return 10 * Mathf.Pow(1.05f, mineLevel);
    }

    
    
    public void UpdateInterface()
    {
        NextUpdateIncome();
        updateCostText.text = formatCS.Shorten_number(updateCost);
        incomeText.text = formatCS.Shorten_number(updateIncome);
    }
    
    public void NextUpdateIncome()
    {
        float nextIncome = 10 * Mathf.Pow(1.05f, mineLevel +1);
        float currentIncome = MoneyUpdateIncome();
        nextIncomeText.text = formatCS.Shorten_number((nextIncome - currentIncome));
    }

    public void UpdateSprite()
    {
        for (int i = 0; i < UpdateSpritesLevel.Length; i++)
        {
            if (mineLevel == UpdateSpritesLevel[i])
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
