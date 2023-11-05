using UnityEngine;
using System.Collections;
using System;

public class PlayerPrefs_remove : MonoBehaviour
{

    [SerializeField] bool sysString;

    void Start()
    {
        if (!sysString)
        {
            PlayerPrefs.DeleteKey("sysString");
        }
    }
}
