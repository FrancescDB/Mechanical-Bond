using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNewCar : MonoBehaviour
{
    [SerializeField] GameObject[] cars;
    
    public void SpawnNewCarM()
    {
        Debug.Log("2");
        StartCoroutine(Spawn());
    }
    

     public IEnumerator Spawn()
     {
        Debug.Log("3");
        yield return new WaitForSeconds(1);
        Instantiate(cars[Random.Range(0, cars.Length)]);
        

     }

}
