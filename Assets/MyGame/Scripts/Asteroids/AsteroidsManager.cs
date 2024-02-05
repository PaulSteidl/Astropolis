using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsManager : MonoBehaviour
{
    [SerializeField] GameObject asteroid, asteroidManager;
    void Start()
    {
        StartCoroutine("Asteroid");
    }

    public IEnumerator Asteroid()
    {
        GameObject g = Instantiate(asteroid, new Vector3(0, 0, 0), Quaternion.identity);
        //g.transform.position = new Vector3(0, 0, 0);
        g.transform.SetParent(asteroidManager.transform);
        g.transform.localPosition = new Vector3(0, 0, 0);
        g.transform.localRotation = new Quaternion(0, 0, 0, 0);
        yield return new WaitForSeconds(1);
        
        StartCoroutine("AsteroidTimer");
    }
    public IEnumerator AsteroidTimer()
    {
        yield return new WaitForSeconds(20);
        StartCoroutine("Asteroid");
    }
    
}
