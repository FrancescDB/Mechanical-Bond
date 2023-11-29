using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    public static int HighScoreI;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Invoke("SetHighScore", 120);
    }
    private void SetHighScore()
    {
        HighScoreI = GameManager.Instance.GamePoints;
    }
    
}
