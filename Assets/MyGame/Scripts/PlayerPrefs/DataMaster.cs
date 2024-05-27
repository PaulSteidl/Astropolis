using UnityEngine;
using System.Collections;
using System;
using TMPro;
public class DataMaster : MonoBehaviour
{
    DateTime currentDate;
    DateTime oldDate;

    MoneyManager moneyManager_cs;
    RocketUpdate rocketTakeOffTime;
    Restaurant Restaurant_cs;
    RocketUpdate RocketUpdatesCS;
    Interface InterfaceManager_cs;
    Mine MineCS;
    Interface InterfaceCS;

    double time;

    [Header("GameObjects")]
    [SerializeField] TextMeshProUGUI MoneyMadeOffline;

    [Header("EnablePlayerPrefs")]
    [SerializeField] bool FirstStartup;
    [SerializeField] bool sysString;
    [SerializeField] bool MoneyPerSecond;
    [SerializeField] bool Money;
    [SerializeField] bool Level_takeOffTime;
    [SerializeField] bool Level_Main_Building;
    [SerializeField] bool RLevelMoney;
    [SerializeField] bool RLevelPeople;
    [SerializeField] bool RLevelComebackTime;
    [SerializeField] bool MineLevel;
    [SerializeField] bool Bought_Mine, Bought_restaurant, Bought_cafe;
    [SerializeField] bool RocketAnzahl;


    [SerializeField] bool Level_Restaurant;

    private void Awake()
    {
        
    }
    void Start()
    {

        MoneyMadeOffline.gameObject.SetActive(true);
        moneyManager_cs = GameObject.FindObjectOfType<MoneyManager>();
        rocketTakeOffTime = GameObject.FindObjectOfType<RocketUpdate>();
        Restaurant_cs = GameObject.FindAnyObjectByType<Restaurant>();
        RocketUpdatesCS = GameObject.FindAnyObjectByType<RocketUpdate>();
        MineCS = GameObject.FindAnyObjectByType<Mine>();
        InterfaceCS = GameObject.FindAnyObjectByType<Interface>();

        if (!sysString)
        {
            PlayerPrefs.DeleteKey("sysString");
        }
        if (!MoneyPerSecond)
        {
            PlayerPrefs.DeleteKey("MoneyPerSecond");
        }
        else
        {
            moneyManager_cs.moneyPerSecond = PlayerPrefs.GetFloat("MoneyPerSecond");
        }
        if (!Money)
        {
            PlayerPrefs.DeleteKey("Money");
        }
        if (!Level_Restaurant)
        {
            PlayerPrefs.DeleteKey("RestaurantLevel");
        }
        if (!FirstStartup)
        {
            PlayerPrefs.SetInt("FirstStartup", 0);
        }
        if (!RLevelComebackTime)
        {
            PlayerPrefs.DeleteKey("RLevelComebackTime");
        }
        if (!MineLevel)
        {
            PlayerPrefs.DeleteKey("MineLevel");
        }
        if (!Bought_cafe)
        {
            PlayerPrefs.DeleteKey("Bought_cafe");
        }
        if (!Bought_Mine)
        {
            PlayerPrefs.DeleteKey("Bought_Mine");
        }
        if (!Bought_restaurant)
        {
            PlayerPrefs.DeleteKey("Bought_restaurant");
        }
        if (!RocketAnzahl)
        {
            PlayerPrefs.DeleteKey("RocketAnzahl");
        }




        if (PlayerPrefs.HasKey("RestaurantLevel") && PlayerPrefs.GetInt("RestaurantLevel") != 0)       
        {
            Restaurant_cs.restaurantLevel = PlayerPrefs.GetInt("RestaurantLevel");
            Restaurant_cs.LevelUpdate();
        }




        if (RLevelMoney)
        {
            if (PlayerPrefs.HasKey("RMoneyLevel") && PlayerPrefs.GetInt("RMoneyLevel") != 0)
            {
                RocketUpdatesCS.moneyLevel = PlayerPrefs.GetInt("RMoneyLevel"); //stellt die Level ein
                RocketUpdatesCS.LevelUpdate();
            }
            
        }
        else
        {
            PlayerPrefs.SetInt("RMoneyLevel", 0);
        }

        if (RLevelPeople)
        {
            if (PlayerPrefs.HasKey("RPeopleLevel") && PlayerPrefs.GetInt("RPeopleLevel") != 0)
            {
                RocketUpdatesCS.peopleLevel = PlayerPrefs.GetInt("RPeopleLevel"); //stellt die Level ein
                RocketUpdatesCS.LevelUpdate();
                Debug.Log("level");
            }

        }
        else
        {
            PlayerPrefs.SetInt("RPeopleLevel", 0);
        }
        if (RLevelComebackTime) 
        {
            if (PlayerPrefs.HasKey("RLevelComeBackTime") && PlayerPrefs.GetInt("RLevelComebackTime") != 0)
            {
                RocketUpdatesCS.peopleLevel = PlayerPrefs.GetInt("RPeopleLevel"); //stellt die Level ein
                RocketUpdatesCS.LevelUpdate();
                Debug.Log("level");
            }
        }

        if (PlayerPrefs.GetInt("Bought_cafe") == 1)
        {
            InterfaceCS.Bought_cafe = true;
        }
        else if (PlayerPrefs.GetInt("Bought_cafe") == 0)
        {
            InterfaceCS.Bought_cafe = false;
        }

        if (PlayerPrefs.GetInt("Bought_restaurant") == 1)
        {
            InterfaceCS.Bought_restaurant = true;
        }
        else if (PlayerPrefs.GetInt("Bought_restaurant") == 0)
        {
            InterfaceCS.Bought_restaurant = false;
        }

        if (PlayerPrefs.GetInt("Bought_Mine") == 1)
        {
            InterfaceCS.Bought_Mine = true;
        }
        else if (PlayerPrefs.GetInt("Bought_Mine") == 0)
        {
            InterfaceCS.Bought_Mine = false;
        }






        if (PlayerPrefs.HasKey("sysString"))
        {
            //Store the current time when it starts
            currentDate = System.DateTime.Now;
            //Grab the old time from the player prefs as a long
            long temp = Convert.ToInt64(PlayerPrefs.GetString("sysString"));
            //Convert the old time from binary to a DataTime variable
            DateTime oldDate = DateTime.FromBinary(temp);
            print("oldDate: " + oldDate);
            //Use the Subtract method and store the result as a timespan variable
            TimeSpan difference = currentDate.Subtract(oldDate);
            print("Difference: " + difference);
            time = difference.TotalSeconds;
        }


        if (PlayerPrefs.HasKey("sysString") && PlayerPrefs.HasKey("MoneyPerSecond") && PlayerPrefs.GetInt("FirstStartup") == 1)
        {
            float MoneyMadeOfflinefloat;
            MoneyMadeOfflinefloat = ((float)time / 10) * PlayerPrefs.GetFloat("MoneyPerSecond");
            MoneyMadeOffline.text = MoneyMadeOfflinefloat.ToString();
            moneyManager_cs.money = moneyManager_cs.money + (((float)time /10) * PlayerPrefs.GetFloat("MoneyPerSecond"));
        }
    }

    void OnApplicationQuit()
    {
        if (sysString)
        {
            //Savee the current system time as a string in the player prefs class
            //Save the current system time as a string in the player prefs class
            PlayerPrefs.SetString("sysString", System.DateTime.Now.ToBinary().ToString());

            print("Saving this date to prefs: " + System.DateTime.Now);
        }
        if (MoneyPerSecond)
        {
            //Save the current Money/sek as a float in the player prefs class
            PlayerPrefs.SetFloat("MoneyPerSecond", moneyManager_cs.moneyPerSecond);
        }
        if (Money)
        {
            //Save the current Money as a float in the player prefs class
            PlayerPrefs.SetFloat("Money", moneyManager_cs.money);
        }
        if (Level_takeOffTime)
        {
            //Save the current Money as a float in the player prefs class
            PlayerPrefs.SetInt("RocketTakeOffTime", rocketTakeOffTime.takeOffLevel);
        }
       
        
        if (Level_Restaurant)
        {
            //Save the current Money as a float in the player prefs class
            PlayerPrefs.SetInt("RestaurantLevel", Restaurant_cs.restaurantLevel);
        }
       
        if (RLevelMoney)
        {
            
            PlayerPrefs.SetInt("RMoneyLevel", RocketUpdatesCS.moneyLevel);
        }
        if (RLevelPeople)
        {
            PlayerPrefs.SetInt("RPeopleLevel", RocketUpdatesCS.peopleLevel);
        }
        if (RLevelComebackTime)
        {
            PlayerPrefs.SetInt("RLevelComebackTime", RocketUpdatesCS.takeOffLevel);
        }
        if (MineLevel)
        {
            PlayerPrefs.SetInt("MineLevel", MineCS.mineLevel);
        }


        if (FirstStartup)
        {
            PlayerPrefs.SetInt("FirstStartup", 1);
        }

        if (Bought_cafe)
        {
            PlayerPrefs.SetInt("Bought_cafe", InterfaceCS.Bought_cafe_int);
        }
        if (Bought_Mine)
        {
            PlayerPrefs.SetInt("Bought_Mine", InterfaceCS.Bought_Mine_int);
        }
        if (Bought_restaurant)
        {
            PlayerPrefs.SetInt("Bought_restaurant", InterfaceCS.Bought_restaurant_int);
        }
        if (RocketAnzahl)
        {
            PlayerPrefs.SetInt("RocketAnzahl", (int)RocketUpdatesCS.anzahl);
        }

    }

} 