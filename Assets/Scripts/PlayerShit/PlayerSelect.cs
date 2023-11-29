using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerSelect : MonoBehaviour
{
    //Intern Vars
    [SerializeField] int player;
    private bool hasSelected;
    private bool selectedGrandSon;
    //PlayerInput
    private PlayerInput playerInputActions;
    //Positions Canvas
    private GameObject grandFather, grandSon;
    private GameObject arrowP1, arrowP2;
    //Players
    private PlayerMovement1 grandFatherPrefab, grandSonPrefab;
    //Car refference
    [SerializeField] private GameObject car;
    [SerializeField] private GameObject GameManagerO;
    //Timer
    private UiManager uiManager;

    //menu
    [SerializeField] GameMenu gameMenu;

    

    void Start()
    {
        //Intern Vars
        hasSelected = false;
        //referencias Player
        grandFatherPrefab = GameObject.Find("Grandfather_prefab").GetComponent<PlayerMovement1>();
        grandSonPrefab = GameObject.Find("Grandson_prefab").GetComponent<PlayerMovement1>();
        //referencias posiciones seleccion
        grandSon = GameObject.Find("GrandSon");
        grandFather = GameObject.Find("GrandFather");
        arrowP1 = GameObject.Find("Player1Selector");
        arrowP2 = GameObject.Find("Player2Selector");

        //Cosas INput
        playerInputActions = GetComponent<PlayerInput>();
        playerInputActions.actions["Select"].started += PlayerSelect_started;
        playerInputActions.actions["UnSelect"].started += PlayerUnSelect_started;
        playerInputActions.actions["Pause"].started += PlayerSelect_started1;

        //
        
        uiManager = GameObject.Find("--UiManager--").GetComponent<UiManager>();

    }

    private void PlayerSelect_started1(InputAction.CallbackContext obj)
    {
        Debug.Log("GOLAaaa");
        gameMenu.Pause();
        
    }

    void Update()
    {
        PlayerInputs();
        ChoosingLogin();
    }
    private void PlayerUnSelect_started(InputAction.CallbackContext obj)
    {
        PlayerMenuUnSelect();



    }
    private void PlayerSelect_started(InputAction.CallbackContext obj)
    {
        PlayerMenuSelect();
        Debug.Log("vAAA");
        SonFatherSelectOnOtherScripts();

    }
    private void CheckStartGame()
    {
        if (GameManager.Instance.isGrandSonSelected && GameManager.Instance.isGrandFatherSelected)
        {

            //Todo lo q pasa al empezar el juego
            GameManager.Instance.hasGameStarted = true;
            if (GameObject.Find("SelectPlayer") != null) GameObject.Find("SelectPlayer").SetActive(false);
            //Start game car
            Instantiate(car);
            GameManager.Instance.gameTimer = 120;
            uiManager.startTimer();

        }
    }

    public Vector2 PlayerInputs()
    {
        Vector2 input;
        input = playerInputActions.actions["Movement"].ReadValue<Vector2>();
        return input;
    }

    private void ChoosingLogin()
    {
        //Si no has seleccionado puedes moverte
        if (!hasSelected) 
        {
            switch (player)
            {
                case 1:


                    if (GameManager.Instance.isGrandFatherSelected && (Vector3.Distance(arrowP1.transform.position, grandFather.transform.position) < 0.01) && !hasSelected) arrowP1.gameObject.transform.position = grandSon.transform.position;
                    if (GameManager.Instance.isGrandSonSelected && (Vector3.Distance(arrowP1.transform.position, grandSon.transform.position) < 0.01) && !hasSelected) arrowP1.gameObject.transform.position = grandFather.transform.position;

                    if (!GameManager.Instance.isGrandSonSelected && !GameManager.Instance.isGrandFatherSelected)
                    {


                        switch (PlayerInputs().y)
                        {
                            case > 0:
                                arrowP1.gameObject.transform.position = grandFather.transform.position;
                            break;

                            case < 0:
                                arrowP1.gameObject.transform.position = grandSon.transform.position;
                            break;
                        }

                    }
                    

                    break;

                case 2:


                    if (GameManager.Instance.isGrandFatherSelected && (Vector3.Distance(arrowP2.transform.position, grandFather.transform.position) < 0.01) && !hasSelected) arrowP2.gameObject.transform.position = grandSon.transform.position;
                    if (GameManager.Instance.isGrandSonSelected && (Vector3.Distance(arrowP2.transform.position, grandSon.transform.position) < 0.01) && !hasSelected) arrowP2.gameObject.transform.position = grandFather.transform.position;

                    if (!GameManager.Instance.isGrandSonSelected && !GameManager.Instance.isGrandFatherSelected)
                    {
                        switch (PlayerInputs().y)
                        {
                            case > 0:
                                arrowP2.gameObject.transform.position = grandFather.transform.position;
                            break;

                            case < 0:
                                arrowP2.gameObject.transform.position = grandSon.transform.position;
                            break;
                        }

                    }

                break;
            }
        }
        
    }

    private void PlayerMenuSelect()
    {

        if (GameManager.Instance.hasGameStarted)
        {

        }
        else
        {
            //SelectionMenuShit
            switch (player)
            {
                case 1:
                    hasSelected = true;
                    if (arrowP1.gameObject.transform.position == grandFather.transform.position)
                    {
                        //Decirle al personaje a qn va a jugar
                        grandFatherPrefab.whoAmIPlaying = PlayerMovement1.Players.Player1;
                        //Poner casilla Abuelo como cogida
                        grandFather.GetComponent<Image>().color = Color.yellow;
                        selectedGrandSon = false;
                        GameManager.Instance.isGrandFatherSelected = true;
                        CheckStartGame();
                    }
                    else
                    {
                        //Decirle al personaje a qn va a jugar
                        grandSonPrefab.whoAmIPlaying = PlayerMovement1.Players.Player1;
                        //Poner casilla Abuelo como cogida
                        grandSon.GetComponent<Image>().color = Color.yellow;
                        selectedGrandSon = true;
                        GameManager.Instance.isGrandSonSelected = true;
                        CheckStartGame();
                    }

                    break;

                case 2:
                    hasSelected = true;
                    if (arrowP2.gameObject.transform.position == grandFather.transform.position)
                    {
                        //Decirle al personaje a qn va a jugar
                        grandFatherPrefab.whoAmIPlaying = PlayerMovement1.Players.Player2;
                        //Poner casilla Abuelo como cogida
                        grandFather.GetComponent<Image>().color = Color.yellow;
                        selectedGrandSon = false;
                        GameManager.Instance.isGrandFatherSelected = true;
                        CheckStartGame();
                    }
                    else
                    {
                        //Decirle al personaje a qn va a jugar
                        grandSonPrefab.whoAmIPlaying = PlayerMovement1.Players.Player2;
                        //Poner casilla Abuelo como cogida
                        grandSon.GetComponent<Image>().color = Color.yellow;
                        selectedGrandSon = true;
                        GameManager.Instance.isGrandSonSelected = true;
                        CheckStartGame();
                    }
                    break;
            }

        }
    }

    private void PlayerMenuUnSelect()
    {
        if (GameManager.Instance.hasGameStarted)
        {

        }
        else
        {
            // SelectionMenuShit
            switch (player)
            {
                case 1:

                   

                    if (GameManager.Instance.isGrandSonSelected && arrowP1.transform.position == grandSon.transform.position)
                    {
                        grandSon.GetComponent<Image>().color = Color.white;
                        GameManager.Instance.isGrandSonSelected = false;
                        hasSelected = false;
                    }

                    if(GameManager.Instance.isGrandFatherSelected  && arrowP1.transform.position == grandFather.transform.position)
                    {
                            grandFather.GetComponent<Image>().color = Color.white;
                            GameManager.Instance.isGrandFatherSelected = false;
                            hasSelected = false;
                    }



                    break;

                case 2:

                    if (GameManager.Instance.isGrandSonSelected && arrowP2.gameObject.transform.position == grandSon.transform.position)
                    {
                        grandSon.GetComponent<Image>().color = Color.white;
                        GameManager.Instance.isGrandSonSelected = false;
                        hasSelected = false;
                    }

                    if (GameManager.Instance.isGrandFatherSelected && arrowP2.gameObject.transform.position == grandFather.transform.position)
                    {
                        grandFather.GetComponent<Image>().color = Color.white;
                        GameManager.Instance.isGrandFatherSelected = false;
                        hasSelected = false;
                    }
                                     

                    break;
            }
        }
    }









    private void SonFatherSelectOnOtherScripts()
    {
        if (GameManager.Instance.hasGameStarted)
        {
            if (grandFatherPrefab.whoAmIPlaying == PlayerMovement1.Players.Player1 && player == 1)
            {
                GameManagerO.GetComponent<TaskManager>().FatherSelect_Started();
                GameManagerO.GetComponent<PlayersGrab>().FatherSelect_Started();
            }
            if (grandSonPrefab.whoAmIPlaying == PlayerMovement1.Players.Player1 && player == 1)
            {
                GameManagerO.GetComponent<TaskManager>().SonSelect_Started();
                GameManagerO.GetComponent<PlayersGrab>().SonSelect_Started();
            }

            if (grandFatherPrefab.whoAmIPlaying == PlayerMovement1.Players.Player2 && player == 2)
            {
                GameManagerO.GetComponent<TaskManager>().FatherSelect_Started();
                GameManagerO.GetComponent<PlayersGrab>().FatherSelect_Started();
            }
            if (grandSonPrefab.whoAmIPlaying == PlayerMovement1.Players.Player2 && player == 2)
            {
                GameManagerO.GetComponent<TaskManager>().SonSelect_Started();
                GameManagerO.GetComponent<PlayersGrab>().SonSelect_Started();
            }
        }
    }







}
