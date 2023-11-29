using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
   // private PlayerInputActions playerAct;
    private float viewPos;
    private float speed;
    private bool moving;
    private Vector2 inputMovement;
    private Rigidbody rb;

    void Start()
    {
        speed = 5f;
        viewPos = 0f;

        moving = false;

        rb = GetComponent<Rigidbody>();

        //playerAct = new PlayerInputActions();
        //playerAct.Player.Movement.Enable();
        //playerAct.Player.Coger.Enable();
        //playerAct.Player.Coger.started += Coger_started;
    }

    private void Coger_started(InputAction.CallbackContext obj)
    {
        Debug.Log("A");
    }

    void Update()
    {
       // inputMovement = playerAct.Player.Movement.ReadValue<Vector2>();

        if (inputMovement == new Vector2(0, 0))
        {
            moving = false;
        }
        else
        {
            moving = true;
        }

        if (moving == true)
        {
            viewPos = Mathf.Atan2(inputMovement.x, inputMovement.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, viewPos, 0f);
        }
    }

    void FixedUpdate()
    {
        if (moving == true)
        {
            rb.velocity = new Vector3(inputMovement.x * speed, 0, inputMovement.y * speed);
        }
        else
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
    }
}
