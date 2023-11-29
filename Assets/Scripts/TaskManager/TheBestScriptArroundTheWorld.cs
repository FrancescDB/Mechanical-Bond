using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheBestScriptArroundTheWorld : MonoBehaviour
{
    //private Variables
    [SerializeField] int missionTime;
    private int stops;
    //Reference to components
    private Animator animator;


    private int currentTask, whenCompleted;
    float timer;


    private bool firstStopCompleted, secondStopCompleted, thirdStopCompleted;
    [SerializeField] private TaskManager taskManager;
    private void Start()
    {
        stops = 0;
        animator = GetComponent<Animator>();

        
    }

    private void Update()
    {

        switch (stops)
        {
            //q pasa
            case 1:
                CheckFirstStop(currentTask);
                break;
            case 2:
                CheckSecondStop(currentTask);
                break;
            case 3:
                
                break;
        }

        
    }

    //FirstStopShit
    public void FirstStop()
    {
        
        stops = 1;
        FirstStopC();
        //InvokeRepeating(nameof(CheckCarExit), 1f, 1f);

    }


    private void FirstStopC()
    {
        currentTask = Random.Range(0, 2);
        currentTask = 1;
        GameManager.Instance.WhatTaskAmIDoing = (GameManager.Tasks)currentTask;
        timer = missionTime;
        //animator.Play("SecondMove");
    }

    private void CheckFirstStop(int task)
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            animator.Play("SecondMove");
            timer = 10f;
        }
        switch (task)
        {
            case 1:
                if (taskManager.DoorsDone && !firstStopCompleted)
                {
                    animator.Play("SecondMove");
                    GameManager.Instance.GamePoints += Mathf.RoundToInt(timer);
                    firstStopCompleted = true;

                }
                break;


            case 2:
                if (taskManager.wheelsState == 4 && !firstStopCompleted)
                {
                    animator.Play("SecondMove");
                    GameManager.Instance.GamePoints += Mathf.RoundToInt(timer);
                    firstStopCompleted = true;

                }
                break;
        }
    }
    //SecondStopShit

    public void SecondStop()
    {
        stops = 2;
        SecondStopC();
    }


    private void SecondStopC()
    {
        currentTask = Random.Range(2, 4);
        currentTask = 2;
        GameManager.Instance.WhatTaskAmIDoing = (GameManager.Tasks)currentTask;
        timer = missionTime;
    }

    public void CheckSecondStop(int currentTask)
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            animator.Play("ThirdMove");
            timer = 10f;
        }
        switch (currentTask)
        {
            case 2:

                if (taskManager.SandPaintDone && !secondStopCompleted)
                {
                    animator.Play("ThirdMove");
                    GameManager.Instance.GamePoints += Mathf.RoundToInt(timer);
                    secondStopCompleted = true;
                }

                break;


            case 3:
                if (taskManager.GunDone && !secondStopCompleted)
                {
                    animator.Play("ThirdMove");
                    GameManager.Instance.GamePoints += Mathf.RoundToInt(timer);
                    secondStopCompleted = true;
                }
                break;
        }
    }






    //ThirdStopShit
    public void ThirdStop()
    {
        stops = 3;
        StartCoroutine(ThirdStopC());
    }


    private IEnumerator ThirdStopC()
    {
        int task;
        task = Random.Range(4, 6);
        GameManager.Instance.WhatTaskAmIDoing = (GameManager.Tasks)task;
        yield return new WaitForSeconds(missionTime);
        animator.Play("LastMove");
    }

    
}
