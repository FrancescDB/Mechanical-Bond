using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersGrab : MonoBehaviour
{
    [SerializeField] private Animator sonAnim, fatherAnim;


    public void SonSelect_Started()
    {

       // Debug.Log("ENTRA");
        if (GameManager.Instance.canSonInteractWithWeels && !GameManager.Instance.isSonWorking)
        {

            //Cambiamos el valor del animator de son para que tenga la rueda cogida
            
            GameManager.Instance.sonMovementState = 2;
            sonAnim.SetTrigger("Grab");
        }

        if (GameManager.Instance.canSonInteractWithTrash && !GameManager.Instance.isSonWorking)
        {

            //Cambiamos el valor del animator de son para que tenga la rueda cogida
            GameManager.Instance.sonMovementState = 0;
            sonAnim.SetTrigger("Grab");
        }
        if(GameManager.Instance.canSonInteractWithWindows && !GameManager.Instance.isSonWorking)
        {
            GameManager.Instance.sonMovementState = 3;
            sonAnim.SetTrigger("Grab");
        }

    }

    public void FatherSelect_Started()
    {
        if (GameManager.Instance.canFatherInteractWithWeels && !GameManager.Instance.isFatherWorking)
        {

            //Cambiamos el valor del animator de father para que tenga la rueda cogida
            GameManager.Instance.fatherMovementState = 2;
            fatherAnim.SetTrigger("Grab");
        }

        if (GameManager.Instance.canFatherInteractWithTrash && !GameManager.Instance.isFatherWorking)
        {

            //Cambiamos el valor del animator de father para que tenga la rueda cogida
            GameManager.Instance.fatherMovementState = 0;
            fatherAnim.SetTrigger("Grab");
        }
        if (GameManager.Instance.canFatherInteractWithWindows && !GameManager.Instance.isFatherWorking)
        {
            GameManager.Instance.fatherMovementState = 3;
            fatherAnim.SetTrigger("Grab");
        }
    }
}
