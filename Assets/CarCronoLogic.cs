using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarCronoLogic : MonoBehaviour
{
    [SerializeField] GameObject getCarTime;
    [SerializeField] Image crono;


    float fillAmmount;
    bool substracting;

    private void Update()
    {
        if (substracting)
        {
            fillAmmount -= Time.deltaTime;


            crono.fillAmount = fillAmmount * 100 / getCarTime.GetComponent<CarsLogic>().missionTime/100;
            CheckCrono();
        }

        
    }


    private void CheckCrono()
    {
        if (fillAmmount <= 0) substracting = false;


    }
    public void StartCrono()
    {
        substracting = true;
        fillAmmount = getCarTime.GetComponent<CarsLogic>().missionTime;


    }
}
// 40 = 100% 