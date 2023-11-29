using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("GameManager is null");
            }
            return instance;
        }
    }
    //GAMEFLOW
    public bool hasGameStarted;
    public bool isGrandSonSelected, isGrandFatherSelected;
    public float gameTimer;
    public int GamePoints;


    //Player Animationes
    public int sonMovementState, fatherMovementState;
    public int sonMovement, fatherMovement;

    public bool isSonWorking, isFatherWorking;
    //PLAYER INTERACTIONS
    public bool canFatherInteractWithCar, canSonInteractWithCar;
    public bool canFatherInteractWithTrash, canSonInteractWithTrash;
    public bool canFatherInteractWithWindows, canSonInteractWithWindows;
    public bool canFatherInteractWithWeels, canSonInteractWithWeels;


    public enum Tasks
    {
        Doors,
        Wheels,
        

        SandPaint,
        Gun,

        Windows,
        Clean,
        //Esta la pongo para asi poder usar esta lista tmb para la colision del personaje
        Car,
        none
    }
    public Tasks WhatTaskAmIDoing;
   










    private void Awake()
    {
        WhatTaskAmIDoing = Tasks.none;
        hasGameStarted = false;

        instance = this;
    }


}