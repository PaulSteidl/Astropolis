using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoManager : MonoBehaviour
{
    [SerializeField] GameObject popUpButtons;
    [SerializeField] GameObject[] popUpInfo;
    void Start()
    {
        
        StartCoroutine("PopUpInfos");
    }

    public IEnumerator PopUpInfos()
    {
        popUpButtons.SetActive(true);
        yield return new WaitForSeconds(10);
        popUpButtons.SetActive(false);
        StartCoroutine("PopUpInfosTimer");
    }
    public IEnumerator PopUpInfosTimer()
    {
        yield return new WaitForSeconds(30);
        StartCoroutine("PopUpInfos");
    }

    public void PopUpInfo()
    {
        int index = Random.Range(0, popUpInfo.Length);
        popUpInfo[index].SetActive(true);

    }
}
