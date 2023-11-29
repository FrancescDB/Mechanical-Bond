using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualTasks : MonoBehaviour
{

    [SerializeField] TaskManager taskManger;

    [SerializeField] private Image son1, son2, father1, father2;
    [SerializeField] private Animator son1G, son2G, father1G, father2G;


    [SerializeField] private Sprite wheelsF, wheelsS, sand, canpaint, cannotpaint, doorsF, doorsS;
    [SerializeField] GameObject hudInterface;

    // private Animator animator;
    public static bool first;


    private void Start()
    {
        //SON1
        Son1ToTransparent();
        Son2ToTransparent();
        
        Father1ToTransparent();
       Father2ToTransparent();

        InvokeRepeating(nameof(UpdateTasks), 0, 0.1f);
    }


    private void UpdateTasks()
    {
        
        if(GameManager.Instance.hasGameStarted) hudInterface.SetActive(true);
        switch (GameManager.Instance.WhatTaskAmIDoing)
        {
            case GameManager.Tasks.Wheels:

                if(!first)
                {
                    Son1ToOpaque();
                    Son2ToOpaque();
                    Father1ToOpaque();
                    Father2ToOpaque();
                    son1.sprite = wheelsS;
                    son2.sprite = wheelsS;
                    father1.sprite = wheelsF;
                    father2.sprite = wheelsF;
                    first = true;
                }

                 if (taskManger.placedFirstWheelSon) Son2ToTransparent();
                 if (taskManger.placedSecondWheelSon) Son1ToTransparent();
                if (taskManger.placedFirstWheelFather) Father2ToTransparent();
                if (taskManger.placedSecondWheelFather) Father1ToTransparent();

                break;


            case GameManager.Tasks.SandPaint:

                switch (taskManger.sandPaintState)
                {
                    case 1:
                        //activamos
                        son1.sprite = sand;
                        Son1ToOpaque();
                        //dejamos Son2Inactivo
                        //activamos
                        father1.sprite = cannotpaint;
                        Father1ToOpaque();
                        //dejamosInactivo
                        

                        break;
                    case 2:
                        father1.sprite = canpaint;
                        Son1ToTransparent();
                        break;
                    case 3:
                        Father1ToTransparent();
                        break;
                }

                break;

            case GameManager.Tasks.Windows:

                if(taskManger.windowState == 0)
                {
                    //activamos
                    son1.sprite = doorsS;
                    Son1ToOpaque();
                    //dejamos Son2Inactivo
                    son2.sprite = null;
                   

                    //activamos
                    father1.sprite = doorsF;
                    Father1ToOpaque();
                    //dejamosInactivo
                    father2.sprite = null;
                   

                }
                if(taskManger.placedWindowFather) Father1ToTransparent();
                if (taskManger.placedWindowSon) Son1ToTransparent();

                break;
        }
    }


    private void Son1ToTransparent()
    {
        //son1G.SetBool("InLoopB", false);
        //son1G.SetTrigger("TopExit");
        son1.gameObject.SetActive(false);
    }
    private void Son1ToOpaque()
    {
        // son1G.SetBool("InLoopA", false);
        //son1G.SetTrigger("TopEntry");
        son1.gameObject.SetActive(true);
    }
    private void Son2ToTransparent()
    {
        // son2G.SetBool("InLoopB", false);
        //   son2G.SetTrigger("TopExit");
        son2.gameObject.SetActive(false);
    }
    private void Son2ToOpaque()
    {
        // son2G.SetBool("InLoopA", false);
        //   son2G.SetTrigger("TopEntry");
        son2.gameObject.SetActive(true);

    }
    private void Father1ToTransparent()
    {
        //   father1G.SetBool("InLoopB", false);
        //  father1G.SetTrigger("TopExit");
        father1.gameObject.SetActive(false);

    }
    private void Father1ToOpaque()
    {
        //    father1G.SetBool("InLoopA", false);
        //   father1G.SetTrigger("TopEntry");
        father1.gameObject.SetActive(true);

    }
    private void Father2ToTransparent()
    {
        //  father2G.SetBool("InLoopB", false);
        //  father2G.SetTrigger("TopExit");
        father2.gameObject.SetActive(false);

    }
    private void Father2ToOpaque()
    {
        //father2G.SetBool("InLoopA", false);
        //father2G.SetTrigger("TopEntry");
        father2.gameObject.SetActive(true);
    }
}
