using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public GameObject player1Select;
    public GameObject player2Select;
    public GameObject player1Selection;
    public GameObject player2Selection;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            GameManager.Instance.hasGameStarted = true;
            player1Selection.SetActive(false);
            player2Selection.SetActive(false);
        }
    }
}