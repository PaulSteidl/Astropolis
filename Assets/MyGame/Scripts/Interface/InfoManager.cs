using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoManager : MonoBehaviour
{
    [SerializeField] GameObject popUpButtons; //Button zum aufmachen
    [SerializeField] Sprite[] popUpInfo; //Infocard
    [SerializeField] GameObject popUp, X;
    
    public int index = 0;
    private Sprite tempGO;
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
        yield return new WaitForSeconds(20);
        StartCoroutine("PopUpInfos");
    }

    public void PopUpInfo()                      //Wenn Button gedrueckt wird
    {
        popUpButtons.SetActive(false);
        popUp.SetActive(true);
        X.SetActive(true);
        
        if (index < popUpInfo.Length -1)
        {
            index++;
        }
        else
        {
            Shuffle();
            index = 0;
        }

        popUp.GetComponent<Image>().sprite = popUpInfo[index];


    }

    public void PopUpOff()
    {
        popUp.SetActive(false);
        X.SetActive(false);
        //popUpButtons.SetActive(true);
    }

    void Shuffle()
    {
        for (int i = 0; i < popUpInfo.Length; i++)
        {
            int rnd = Random.Range(0, popUpInfo.Length);
            tempGO = popUpInfo[rnd];
            popUpInfo[rnd] = popUpInfo[i];
            popUpInfo[i] = tempGO;
        }
    }
}
