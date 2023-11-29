using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterSelection : MonoBehaviour
{
    private int activationNumber;

    public Vector2 inputMovement;
    public int selectionNumber;
    public int selectionPosition;
    public bool gameStarts;
    public bool alreadySelected;
    public GameObject otherPlayer;
    public GameObject abueloObj;
    public GameObject nietoObj;
    public GameObject seleccionadorObj;

    void Start()
    {
        selectionPosition = 1;
        selectionNumber = 1;

        gameStarts = false;
        alreadySelected = false;
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        inputMovement = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        if (!GameManager.Instance.hasGameStarted)
        {
            if (otherPlayer.GetComponent<CharacterSelection2>().alreadySelected == false)
            {
                if (alreadySelected == false)
                {
                    if (inputMovement.x >= 0.75f && selectionPosition <= 1)
                    {
                        selectionPosition = selectionPosition + 1;
                    }

                    if (inputMovement.x <= -0.75f && selectionPosition >= 2)
                    {
                        selectionPosition = selectionPosition - 1;
                    }
                }
            }
            else
            {
                if (otherPlayer.GetComponent<CharacterSelection2>().selectionPosition == 1)
                {
                    selectionPosition = 2;
                }
                else
                {
                    selectionPosition = 1;
                }
            }

            switch (selectionNumber)
            {
                case 0: //Vuelve al menú principal 
                    Debug.Log("Menú principal");
                    break;

                case 1:
                    alreadySelected = false;
                    if (activationNumber == 1)
                    {
                        abueloObj.SetActive(true);
                        Debug.Log("ACTIVAR ABUELO");
                        activationNumber = 2;
                    }
                    if (activationNumber == 3)
                    {
                        nietoObj.SetActive(true);
                        Debug.Log("ACTIVAR NIETO");
                        activationNumber = 4;
                    }
                    break;

                case 2:
                    if (otherPlayer.GetComponent<CharacterSelection2>().alreadySelected == false)
                    {
                        if (selectionPosition == 1)
                        {
                            //Llamar prefabs Abuelo
                            abueloObj.SetActive(false);
                            activationNumber = 1;
                        }
                        else
                        {
                            //Llamar prefabs Nieto
                            nietoObj.SetActive(false);
                            activationNumber = 3;
                        }
                    }
                    else
                    {
                        if (selectionPosition == 1)
                        {
                            abueloObj.SetActive(false);
                            activationNumber = 1;
                        }
                        else
                        {
                            nietoObj.SetActive(false);
                            activationNumber = 3;
                        }
                    }

                    alreadySelected = true;
                    break;
            }

            if (selectionPosition == 1)
            {
                seleccionadorObj.transform.position = new Vector3(-5.81f, 15.1f, -1.73f);
            }
            else
            {
                seleccionadorObj.transform.position = new Vector3(2.64f, 15.1f, -1.73f);
            }

            Debug.Log("Selection Number: " + selectionNumber);
            Debug.Log("Selection Position: " + selectionPosition);
        }
        
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.started && selectionNumber <= 1)
        {
            selectionNumber = selectionNumber + 1;
        }
    }

    public void OnCancel(InputAction.CallbackContext context)
    {
        if (context.started && selectionNumber >= 1)
        {
            selectionNumber = selectionNumber - 1;
        }
    }
}
