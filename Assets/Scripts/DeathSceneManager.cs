using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathSceneManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highScore;

    void Start()
    {
        highScore.text = HighScore.HighScoreI.ToString();
    }

    public void Replay()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
