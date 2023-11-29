using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;
using UnityEngine.SceneManagement;

public class CarsLogic : MonoBehaviour
{
    //private Variables
    public int missionTime;
    private int stops;
    float timer;
    private bool firstStopCompleted, secondStopCompleted, thirdStopCompleted;

    [SerializeField] GameObject crono;
    //Whees
    

    //Carshit

    [SerializeField] int CarType;
    AnimationEvents AnimationManager1, AnimationManager2;
    //Reference to components
    private Animator animator;








    private Tasks firstStop, secondStop, thirdStop;
    private TaskManager taskManager;



    private void CheckCarExit()
    {
        if (GameManager.Instance.gameTimer <= 0)
        {
            GameManager.Instance.hasGameStarted = false;
            switch (stops)
            {
                //q pasa
                case 1:
                    animator.Play("Exit1");
                    SceneManager.LoadScene(2);
                    break;
                case 2:
                    animator.Play("Exit2");
                    SceneManager.LoadScene(2);
                    break;
                case 3:
                    animator.Play("Exit3");
                    SceneManager.LoadScene(2);
                    break;
            }
        }

    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        taskManager = GameObject.Find("GameManager").GetComponent<TaskManager>();
        animator.Play("FirstMove");


        AnimationManager1 = GameObject.Find("Grandson_prefab").GetComponent<AnimationEvents>();
        AnimationManager2 = GameObject.Find("Grandfather_prefab").GetComponent<AnimationEvents>();
      //  Debug.Log("HOLAAAAA");
        AnimationManager1.FindNewCarParticles();
        AnimationManager2.FindNewCarParticles();
        SetTasks();
        InvokeRepeating("CheckCarExit", 0, 1);
    }

    private void SetTasks()
    {
        switch (CarType)
        {
            case 1:

                firstStop = GameManager.Tasks.Wheels;
                secondStop = GameManager.Tasks.SandPaint;
                thirdStop = GameManager.Tasks.Windows;
                break;

            case 2:

                firstStop = GameManager.Tasks.Doors;
                secondStop = GameManager.Tasks.SandPaint;
                thirdStop = GameManager.Tasks.Windows;
                break;
            case 3:
                firstStop = GameManager.Tasks.Wheels;
                secondStop = GameManager.Tasks.Gun;
                thirdStop = GameManager.Tasks.Clean;
                break;
            case 4:
                firstStop = GameManager.Tasks.Doors;
                secondStop = GameManager.Tasks.Gun;
                thirdStop = GameManager.Tasks.Clean;
                break;
        }
    }

    private void Update()
    {

        switch (stops)
        {
            //q pasa
            case 1:
                CheckFirstStop();
                break;
            case 2:
                CheckSecondStop();
                break;
            case 3:
                CheckThirdStop();
                break;
        }


    }

    public void FirstStop()
    {
        //Saber en q parada estroy
        stops = 1;
        //Definir tarea
        GameManager.Instance.WhatTaskAmIDoing = firstStop;
        crono.GetComponent<CarCronoLogic>().StartCrono();
        timer = missionTime;

        //InvokeRepeating(nameof(CheckCarExit), 1f, 1f);

    }


    private void CheckFirstStop()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            animator.Play("SecondMove");

            //AQUI CANCELARIAMOS TODAS LAS ANIMACIONES DEL MOMETO(Para q no pueda terminar la tarea)
            //no añadir pintos
            timer = 10f;
        }

         if (taskManager.DoorsDone && !firstStopCompleted)
         {
            if( timer -10 >= 0)
            {
                GameManager.Instance.GamePoints += 100;
                //Añades mas puntos
            }else GameManager.Instance.GamePoints += 50;

            animator.Play("SecondMove");
            firstStopCompleted = true;
         }



                if (taskManager.wheelsState == 4 && !firstStopCompleted)
                {
                    if (timer - 10 >= 0)
                    {
                        GameManager.Instance.GamePoints += 100;
                        //Añades mas puntos
                    }
                    else GameManager.Instance.GamePoints += 50;

                    animator.Play("SecondMove");
                    firstStopCompleted = true;

                }

        
    }


    public void SecondStop()
    {
        stops = 2;
        GameManager.Instance.WhatTaskAmIDoing = secondStop;
        crono.GetComponent<CarCronoLogic>().StartCrono();
        timer = missionTime;
    }



    public void CheckSecondStop()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            animator.Play("ThirdMove");
            timer = 10f;
        }

 

                if (taskManager.SandPaintDone && !secondStopCompleted)
                {
                    if (timer - 10 >= 0)
                    {
                        GameManager.Instance.GamePoints += 100;
                        //Añades mas puntos
                    }
                    else GameManager.Instance.GamePoints += 50;

                    animator.Play("ThirdMove");
                    secondStopCompleted = true;
                }

           


 
                if (taskManager.GunDone && !secondStopCompleted)
                {
                   
                    if (timer - 10 >= 0)
                    {
                        GameManager.Instance.GamePoints += 100;
                        //Añades mas puntos
                    }
                    else GameManager.Instance.GamePoints += 50;
                    animator.Play("ThirdMove");
                    secondStopCompleted = true;
                }
             
      
    }






    public void ThirdStop()
    {
        stops = 3;
        GameManager.Instance.WhatTaskAmIDoing = thirdStop;
        crono.GetComponent<CarCronoLogic>().StartCrono();
        timer = missionTime;
    }

    public void CheckThirdStop()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            animator.Play("LastMove");
            timer = 10f;
        }



        if (taskManager.windowState == 2 && !thirdStopCompleted)
        {
            if (timer - 10 >= 0)
            {
                GameManager.Instance.GamePoints += 100;
                //Añades mas puntos
            }
            else GameManager.Instance.GamePoints += 50;

            animator.Play("LastMove");
            thirdStopCompleted = true;
        }





        if (taskManager.CleanDone && !thirdStopCompleted)
        {

            if (timer - 10 >= 0)
            {
                GameManager.Instance.GamePoints += 100;
                //Añades mas puntos
            }
            else GameManager.Instance.GamePoints += 50;
            animator.Play("LastMove");
            thirdStopCompleted = true;
        }


    }




    public void FinalMove()
    {

        taskManager.ResetTaskManager();
        Destroy(gameObject);
    }

}

/*
 * 
 * Spawnea un coche aleatorio:

segun el coche hay unas tareas especificas.
tienes x tiemepo para cada tarea, si la haces en poco tiempo te da mas puntos. sino la haces en timepo no te da puntos.
si se acaba el timepo gloval el coche se va

A TENER EN CUENTA(FALATAN REFERENCIAS A EFECTOS PARTICULAS COCHE Y TASKMANAGER)

opciones

coche sin ruedas-- sin pintar y sin ventanas:

poner ruedas, pintar, poner ventanas delanteras
Activar ventanas delanterasw
cambiar textura
activar ruedas

coche sin puertas -- sin pintar y sin ventanas

Poner puertas, pintar, poner ventanas traseras.
activar puertas(ventanas de puerta incluida)
cambiar textura
activar ventanas

coche sin ruedas-- pintado y sucio

poner ruedas, pistola de clavos y lavar

activar ruedas
cambiar textura a limpia

coche sin puertas -- pintado y sucio


poner puertas, pistola de clavos y lavar

activar puertas
cambiar textura a limpia


*/
