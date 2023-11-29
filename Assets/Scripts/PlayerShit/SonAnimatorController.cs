using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonAnimatorController : MonoBehaviour
{
    //Component references
    private Rigidbody rb;
    private Animator anim;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();


        // MOVEMENT STATE: 0,1 0 idle 1 correr, 2,3 2 idle con puerta 3 correr con puerta 45 rueda 67 ventana
        //movement state lo cambiaremos al entrar en el estado de correr con puerta(Por ejemplo)
        GameManager.Instance.sonMovementState = 0;
        
    }

    void Update()
    {
        CheckAnimations();
       // Debug.Log(GameManager.Instance.sonMovementState);

    }



    private void CheckAnimations()
    {
        switch (GameManager.Instance.sonMovementState)
        {
            case 0:
                //Correr normal
                if (rb.velocity.magnitude > 0)
                {
                    anim.SetInteger("MovementState", 1);
                    GameManager.Instance.sonMovement = 1;
                }
                else
                {
                    anim.SetInteger("MovementState", 0);
                    GameManager.Instance.sonMovement = 0;
                }
            break;

            case 1:
                //Correr con puerta
                if (rb.velocity.magnitude > 0)
                {
                    anim.SetInteger("MovementState", 3);
                    GameManager.Instance.sonMovement = 3;
                }
                else
                {
                    anim.SetInteger("MovementState", 2);
                    GameManager.Instance.sonMovement = 2;
                }
                    
            break;

            case 2:
                //Correr con rueda
                if (rb.velocity.magnitude > 0)
                {
                    anim.SetInteger("MovementState", 5);
                    GameManager.Instance.sonMovement = 5;
                }
                else
                {
                    anim.SetInteger("MovementState", 4);
                    GameManager.Instance.sonMovement = 4;
                }
            break;

            case 3:
                //Correr con Ventana
                if (rb.velocity.magnitude > 0)
                {
                    anim.SetInteger("MovementState", 7);
                    GameManager.Instance.sonMovement = 7;
                }
                else
                {

                    anim.SetInteger("MovementState", 6);
                    GameManager.Instance.sonMovement = 6;
                }
                break;
        }
    }
}
