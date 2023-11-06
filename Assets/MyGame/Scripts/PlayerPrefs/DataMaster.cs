using UnityEngine;
using System.Collections;
using System;

public class DataMaster : MonoBehaviour
{
    DateTime currentDate;
    DateTime oldDate;
    [SerializeField] bool sysString;
    void Start()
    {

        if (!sysString)
        {
            PlayerPrefs.DeleteKey("sysString");
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

            double time = difference.TotalSeconds;
            Debug.Log(time);
        }
    }

    void OnApplicationQuit()
    {
        if (sysString)
        {
            //Savee the current system time as a string in the player prefs class
            PlayerPrefs.SetString("sysString", System.DateTime.Now.ToBinary().ToString());

            print("Saving this date to prefs: " + System.DateTime.Now);
        }
    }

}
