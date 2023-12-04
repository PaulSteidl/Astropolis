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
    double time;

    [Header("GameObjects")]
    [SerializeField] TextMeshProUGUI MoneyMadeOffline;

    [Header("DeletePlayerPrefs")]
    [SerializeField] bool sysString;
    [SerializeField] bool MoneyPerSecond;
    [SerializeField] bool Money;
    [SerializeField] bool Level_takeOffTime;
    [SerializeField] bool Level_Main_Building;
    [SerializeField] bool Level_Rocketstation;

    private void Awake()
    {
        
    }
    void Start()
    {
        MoneyMadeOffline.gameObject.SetActive(true);
        moneyManager_cs = GameObject.FindObjectOfType<MoneyManager>();
        rocketTakeOffTime = GameObject.FindObjectOfType<RocketUpdate>();

        if (!sysString)
        {
            PlayerPrefs.DeleteKey("sysString");
        }
        if (!MoneyPerSecond)
        {
            PlayerPrefs.DeleteKey("MoneyPerSecond");
        }
        if (!Money)
        {
            PlayerPrefs.DeleteKey("Money");
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
            Debug.Log(time);
        }

        if (PlayerPrefs.HasKey("sysString") && PlayerPrefs.HasKey("MoneyPerSecond"))
        {
            float MoneyMadeOfflinefloat;
            MoneyMadeOfflinefloat = ((float)time * PlayerPrefs.GetFloat("MoneyPerSecond")) / 10;
            MoneyMadeOffline.text = MoneyMadeOfflinefloat.ToString();
            moneyManager_cs.money = moneyManager_cs.money + (((float)time * PlayerPrefs.GetFloat("MoneyPerSecond")) / 10);
            Debug.Log(moneyManager_cs.money);
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
    }

} 