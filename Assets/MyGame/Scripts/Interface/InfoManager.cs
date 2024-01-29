using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoManager : MonoBehaviour
{
    [SerializeField] GameObject popUpButtons; //Button zum aufmachen
    [SerializeField] Sprite[] popUpInfo; //Infocard
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

    public void PopUpInfo()                      //Wenn Button gedrueckt wird
    {
        int index = Random.Range(0, popUpInfo.Length);
        //popUpInfo[index].

    }
}
