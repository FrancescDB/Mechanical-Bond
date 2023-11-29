using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TaskManager : MonoBehaviour
{
    //TareaSandPaint
    public bool SandPaintDone, WindowsDone, DoorsDone, GunDone, CleanDone;
    public int sandPaintState;
    [SerializeField] private bool sonSelect, fatherSelect;

    //TareaWhhels
    public bool placedFirstWheelSon, placedFirstWheelFather, placedSecondWheelFather, placedSecondWheelSon;
    public int wheelsState;


    //TareaWindows
    public bool placedWindowFather, placedWindowSon;
    public int windowState;

    //Animatores
    [SerializeField] Animator sonAnimator, fatherAnimator;
    

    private void Start()
    {
        sandPaintState = 1;


    }



    public void ResetTaskManager()
    {
        sandPaintState = 1;
        SandPaintDone = false;
        WindowsDone = false;
        windowState = 0;
        GunDone = false;
        CleanDone = false;
        placedFirstWheelFather = false;
        placedFirstWheelSon = false;
        placedSecondWheelFather = false;
        placedSecondWheelSon = false;
        placedWindowFather = false;
        placedWindowSon = false;
        wheelsState = 0;
        windowState = 0;
        VisualTasks.first = false;
        GameManager.Instance.WhatTaskAmIDoing = GameManager.Tasks.Wheels;


        // StartCoroutine(GetComponent<SpawnNewCar>().Spawn());
        GetComponent<SpawnNewCar>().SpawnNewCarM();
       
    }




    public void SonSelect_Started()
    {
        switch (GameManager.Instance.WhatTaskAmIDoing)
        {
            case GameManager.Tasks.SandPaint:
                SandPaintLogic("Son");
                break;
            case GameManager.Tasks.Wheels:
                WheelsLogic("Son");
                break;
            case GameManager.Tasks.Windows:
                WindowsLogic("Son");
                break;
            case GameManager.Tasks.Doors:
                break;
        }

    }
    public void FatherSelect_Started()
    {
        
        switch (GameManager.Instance.WhatTaskAmIDoing)
        {
            case GameManager.Tasks.SandPaint:
                SandPaintLogic("Father");
                break;
            case GameManager.Tasks.Wheels:
                WheelsLogic("Father");
                break;
            case GameManager.Tasks.Windows:
                WindowsLogic("Father");
                break;
            case GameManager.Tasks.Doors:
                break;
        }
    }



    private void WheelsLogic(string whoAreYou)
    {
        
        if (GameManager.Instance.canSonInteractWithCar && !GameManager.Instance.isSonWorking && whoAreYou == "Son" && (GameManager.Instance.sonMovement == 5 || GameManager.Instance.sonMovement == 4))
        {

            if (!placedSecondWheelSon)
            {
                if (placedFirstWheelSon)
                {
                    GameManager.Instance.sonMovementState = 0;
                    sonAnimator.SetTrigger("PlaceWheel");

                }
                GameManager.Instance.sonMovementState = 0;
                sonAnimator.SetTrigger("PlaceWheel");
                Debug.Log("GOLA");
            }
        }

        if (GameManager.Instance.canFatherInteractWithCar && !GameManager.Instance.isFatherWorking && whoAreYou == "Father" && (GameManager.Instance.fatherMovement == 5 || GameManager.Instance.fatherMovement == 4))
        {

            if (!placedSecondWheelFather)
            {
                if (placedFirstWheelFather)
                {
                    GameManager.Instance.fatherMovementState = 0;
                    fatherAnimator.SetTrigger("PlaceWheel");

                }
                GameManager.Instance.fatherMovementState = 0;
                fatherAnimator.SetTrigger("PlaceWheel");
            }
        }
    }

    public void PlaceFatherWheel()
    {
        if (!placedSecondWheelFather)
        {
            if (placedFirstWheelFather)
            {
                GameObject.FindWithTag("CarSon").transform.Find("RuedaAbuelo2").gameObject.SetActive(true);
                wheelsState++;
                wheelsState++;
                placedSecondWheelFather = true;

            }
            GameObject.FindWithTag("CarSon").transform.Find("RuedaAbuelo1").gameObject.SetActive(true);
            placedFirstWheelFather = true;
        }

    }
    public void PlaceSonWheel()
    {
        if (!placedSecondWheelSon)
        {
            if (placedFirstWheelSon)
            {
                GameObject.FindWithTag("CarSon").transform.Find("RuedaNieto2").gameObject.SetActive(true);
                wheelsState++;
                wheelsState++;
                placedSecondWheelSon = true;
            }
            GameObject.FindWithTag("CarSon").transform.Find("RuedaNieto1").gameObject.SetActive(true);
            placedFirstWheelSon = true;
        }


    }
    private void SandPaintLogic(string whoAreYou)
    {
       // Debug.Log("estoy");
        switch (sandPaintState)
        {
            case 1:
                if (GameManager.Instance.canSonInteractWithCar && !GameManager.Instance.isSonWorking && whoAreYou == "Son" && GameManager.Instance.sonMovementState == 0)
                {
                    SandCarC();
                }
                break;
            case 2:
                if (GameManager.Instance.canFatherInteractWithCar && !GameManager.Instance.isFatherWorking && whoAreYou == "Father" && GameManager.Instance.fatherMovementState == 0)
                {
                    PaintCarC();
                }
                break;
        }
    }


    public void SandCarC()
    {
        //Llamamos a la animacion de pintar y cuando esta termine hara todo lo que tiene q ver con cambios visuales
        sonAnimator.SetTrigger("SandCar");

    }
    public void PaintCarC()
    {
        fatherAnimator.SetTrigger("PaintCar");
        //Llamamos a la animacion de pintar y cuando esta termine hara todo lo que tiene q ver con cambios visuales

    }







    private void WindowsLogic(string whoAreYou)
    {

        if (GameManager.Instance.canSonInteractWithCar && !GameManager.Instance.isSonWorking && whoAreYou == "Son" && (GameManager.Instance.sonMovement == 6 || GameManager.Instance.sonMovement == 7))
        {

            if (!placedWindowSon)
            {

              GameManager.Instance.sonMovementState = 0;
              sonAnimator.SetTrigger("PlaceWindow");

            }
        }

        if (GameManager.Instance.canFatherInteractWithCar && !GameManager.Instance.isFatherWorking && whoAreYou == "Father" && (GameManager.Instance.fatherMovement == 6 || GameManager.Instance.fatherMovement == 7))
        {

            if (!placedWindowFather)
            {

                GameManager.Instance.fatherMovementState = 0;
                fatherAnimator.SetTrigger("PlaceWindow");

            }
        }
    }

    public void PlaceFatherWindow()
    {
        if (!placedWindowFather)
        {
            GameObject.FindWithTag("CarSon").transform.Find("VentanaAbuelo").gameObject.SetActive(true);
            placedWindowFather = true;
            windowState++;

        }
    }

    
    public void PlaceSonWindow()
    {
        if (!placedWindowSon)
        {
            GameObject.FindWithTag("CarSon").transform.Find("VentanaNieto").gameObject.SetActive(true);
            placedWindowSon = true;
            windowState++;

        }
    }





    private void DoorsLogic(string whoAreYou)
    {

        if (GameManager.Instance.canSonInteractWithCar && whoAreYou == "Son" && (GameManager.Instance.sonMovement == 6 || GameManager.Instance.sonMovement == 7))
        {

            if (!placedWindowSon)
            {

                GameManager.Instance.sonMovementState = 0;
                sonAnimator.SetTrigger("PlaceWindow");

            }
        }

        if (GameManager.Instance.canFatherInteractWithCar && whoAreYou == "Father" && (GameManager.Instance.fatherMovement == 6 || GameManager.Instance.fatherMovement == 7))
        {

            if (!placedWindowFather)
            {

                GameManager.Instance.fatherMovementState = 0;
                fatherAnimator.SetTrigger("PlaceWindow");

            }
        }
    }

    public void PlaceDoorSon()
    {
        if (!placedWindowFather)
        {
            GameObject.FindWithTag("CarSon").transform.Find("VentanaAbuelo").gameObject.SetActive(true);
            placedWindowFather = true;
            windowState++;

        }
    }


    public void PlaceDoorFather()
    {
        if (!placedWindowSon)
        {
            GameObject.FindWithTag("CarSon").transform.Find("VentanaNieto").gameObject.SetActive(true);
            placedWindowSon = true;
            windowState++;

        }
    }

}
