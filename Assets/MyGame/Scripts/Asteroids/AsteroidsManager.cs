using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsManager : MonoBehaviour
{
    [SerializeField] GameObject asteroid, asteroidManager;
    [SerializeField] GameObject camera1;
    void Start()
    {
        StartCoroutine("Asteroid");
    }

    public IEnumerator Asteroid()
    {
        GameObject g = Instantiate(asteroid, new Vector3(0, 0, 0), Quaternion.identity);
        //g.transform.position = new Vector3(0, 0, 0);
        g.transform.SetParent(asteroidManager.transform);
        float a = camera1.transform.position.x + 500;
        gameObject.transform.Find("Image").position = new Vector3(a, 0, 0);
        
        g.transform.localPosition = new Vector3(0, 0, 0);
        g.transform.localRotation = new Quaternion(0, 0, 0, 0);
        g.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        yield return new WaitForSeconds(1);
        
        StartCoroutine("AsteroidTimer");
    }
    public IEnumerator AsteroidTimer()
    {
        yield return new WaitForSeconds(5);
        StartCoroutine("Asteroid");
    }
    
}
