using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    
    //public GameObject selectionManager;
    [SerializeField] private float speed;
    [SerializeField] private int requiredNumber;

    private float viewPos;
    private bool moving;
    private Vector2 movementInput;
    private Rigidbody rb;
    private GameObject player1Obj;
    private GameObject player2Obj;

    void Start()
    {
        speed = 3f;
        viewPos = 0f;

        moving = false;

        rb = GetComponent<Rigidbody>();
        player1Obj = GameObject.Find("Player1Selection");
        player2Obj = GameObject.Find("Player2Selection");
    }

    void Update()
    {
        if (GameManager.Instance.hasGameStarted)
        {
            if (player1Obj.GetComponent<CharacterSelection>().selectionPosition == requiredNumber)
            {
                movementInput = player1Obj.GetComponent<CharacterSelection>().inputMovement;
            }

            if (player2Obj.GetComponent<CharacterSelection2>().selectionPosition == requiredNumber)
            {
                movementInput = player2Obj.GetComponent<CharacterSelection2>().inputMovement;
            }

            if (movementInput == new Vector2(0, 0))
            {
                moving = false;
            }
            else
            {
                moving = true;
            }

            if (moving == true)
            {
                viewPos = Mathf.Atan2(movementInput.x, movementInput.y) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0f, viewPos, 0f);
            }
        }
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.hasGameStarted)
        {
            if (moving == true)
            {
                rb.velocity = new Vector3(movementInput.x * speed, 0, movementInput.y * speed);
            }
            else
            {
                rb.velocity = new Vector3(0, 0, 0);
            }
        }
    }
}
