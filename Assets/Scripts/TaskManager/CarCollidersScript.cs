using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static GameManager;

public class CarCollidersScript : MonoBehaviour
{


    public Tasks WhatColliderAmIOn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Son"))
        {
            SonToTrue();
        }
        if (other.CompareTag("Father"))
        {
            FatherToTrue();
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Son"))
        {
            SonToFalse(); 
        }
        if (other.CompareTag("Father"))
        {
            FatherToFalse();
        }
    }

    private void SonToFalse()
    {
        switch (WhatColliderAmIOn)
        {
            case Tasks.Car:
                GameManager.Instance.canSonInteractWithCar = false;
                break;

            case Tasks.Wheels:
                GameManager.Instance.canSonInteractWithWeels = false;
                break;



            case Tasks.Windows:
                GameManager.Instance.canSonInteractWithWindows = false;
                break;

            case Tasks.none:
                GameManager.Instance.canSonInteractWithTrash = false;
                break;
        }
    }


    private void SonToTrue()
    {
        switch (WhatColliderAmIOn)
        {
            case Tasks.Car:
                GameManager.Instance.canSonInteractWithCar = true;
                break;

            case Tasks.Wheels:
                GameManager.Instance.canSonInteractWithWeels = true;
                break;
            case Tasks.Windows:
                GameManager.Instance.canSonInteractWithWindows = true;
                break;
            case Tasks.none:
                GameManager.Instance.canSonInteractWithTrash = true;
                break;
        }
    }



    private void FatherToFalse()
    {
        switch (WhatColliderAmIOn)
        {
            case Tasks.Car:
                GameManager.Instance.canFatherInteractWithCar = false;
                break;

            case Tasks.Wheels:
                GameManager.Instance.canFatherInteractWithWeels = false;
                break;
            case Tasks.Windows:
                GameManager.Instance.canFatherInteractWithWindows = false;
                break;
            case Tasks.none:
                GameManager.Instance.canFatherInteractWithTrash = false;
                break;
        }
    }


    private void FatherToTrue()
    {
        switch (WhatColliderAmIOn)
        {
            case Tasks.Car:
                GameManager.Instance.canFatherInteractWithCar = true;
                break;

            case Tasks.Wheels:
                GameManager.Instance.canFatherInteractWithWeels = true;
                break;
            case Tasks.Windows:
                GameManager.Instance.canFatherInteractWithWindows = true;
                break;

            case Tasks.none:
                GameManager.Instance.canFatherInteractWithTrash = true;
                break;
        }
    }
}
