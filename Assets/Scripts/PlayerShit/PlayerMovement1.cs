using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement1 : MonoBehaviour
{

    //Componentes
    private Rigidbody rb;

    //Players
    private GameObject player1, player2;

    private Vector2 inputs;


    [SerializeField] string WhoAmI;
    public enum Players
    {
        Player1,
        Player2
    }
    public Players whoAmIPlaying;

    //Var Internas
    [SerializeField] int speed;
    private float viewPos;

    private void Start()
    {
        //Find Players
        player1 = GameObject.Find("Player1Manager");
        player2 = GameObject.Find("Player2Manager");
        //Getting Componets
        rb = GetComponent<Rigidbody>();

        //Vars
       // speed = 5;
    }
    private void Update()
    {
        if(GameManager.Instance.hasGameStarted)
        {

            if (WhoAmI == "Son")
            {
                if (!GameManager.Instance.isSonWorking)
                {
                    GetInputs();
                    Rotation();
                    Movement();
                }
                else rb.velocity = Vector3.zero;

            }
      

            if (WhoAmI == "Father" && !GameManager.Instance.isFatherWorking)
            {
                if (!GameManager.Instance.isFatherWorking)
                {
                    GetInputs();
                    Rotation();
                    Movement();
                }
                else rb.velocity = Vector3.zero;

            }
          //  else rb.velocity = Vector3.zero;

            // if(WhoAmI == "Father") Debug.Log(inputs);


            // Debug.Log(inputs.x);
        }

    }
    private void GetInputs()
    {
        switch (whoAmIPlaying)
        {
            case Players.Player1:
                inputs = player1.GetComponent<PlayerSelect>().PlayerInputs();

            break;

            case Players.Player2:

                inputs = player2.GetComponent<PlayerSelect>().PlayerInputs();
            break;
        }
    }
    private void Movement()
    {

        Vector3 movement = new Vector3(inputs.x, 0.0f, inputs.y) * speed;
        rb.velocity = movement;
        this.transform.position = new Vector3(transform.position.x, 0.03f, transform.position.z);

    }

    private void Rotation()
    {

        if ( inputs.x != 0.0f || inputs.y != 0.0f) 
        {
            viewPos = Mathf.Atan2(inputs.x, inputs.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, viewPos, 0f);
        }
    }
}
