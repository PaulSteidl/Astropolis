using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activate : MonoBehaviour
{
    public GameObject Video;
    private void Awake()
    {
        Video.SetActive(false);
        Invoke("Activating", 0.01f);
    }

    void Activating()
    {
        Video.SetActive(true);
    }
}
