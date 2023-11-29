using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] GameObject optionsMenu;
    [SerializeField] GameObject menuBeforeOptions;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI currentTaskText;
    [SerializeField] TextMeshProUGUI pointsText;
    [SerializeField] Slider VolSlider;
    [SerializeField] GameObject playButton;
    private void Start()
    {
        //HACER LO DEL ESCAPE.
        //GameObject.Find("--Player--").GetComponent<PlayerInput>().
        Cursor.lockState = CursorLockMode.Locked;
        
    }


    public void startTimer()
    {
        InvokeRepeating(nameof(ReduceTimer), 0f, 1f);
        InvokeRepeating(nameof(CheckTask), 0f, 1f);
    }

    public void CheckTask()
    {
        currentTaskText.text = GameManager.Instance.WhatTaskAmIDoing.ToString();
        //Add points
        pointsText.text = GameManager.Instance.GamePoints.ToString();
    }
    private void ReduceTimer()
    {
        GameManager.Instance.gameTimer--;
        timerText.text = GameManager.Instance.gameTimer.ToString();
    }

    public void ExitButton()
    {
        Application.Quit();
    }
    public void PlayButton()
    {
        SceneManager.LoadScene(3);
    }
    public void OpenOptions()
    {
        menuBeforeOptions.SetActive(false);
        optionsMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(VolSlider.gameObject);
    }
    public void CloseOptions()
    {
        optionsMenu.SetActive(false);
        menuBeforeOptions.SetActive(true);
        EventSystem.current.SetSelectedGameObject(playButton);
    }

    public void ResumeButton()
    {
        menuBeforeOptions.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }
}
