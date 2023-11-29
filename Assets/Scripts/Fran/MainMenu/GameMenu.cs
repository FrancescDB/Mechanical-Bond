using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class GameMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject settingsMenu;
    public GameObject playButton;
    public Slider volumeSlider;

    [SerializeField] GameObject resumeButton;
    [SerializeField] private AudioMixer myMixer;

    public void Pause()
    {
        EventSystem.current.SetSelectedGameObject(resumeButton);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Settings()
    {
        settingsMenu.SetActive(true);
        pauseMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(volumeSlider.gameObject);
    }

    void SetVolume()
    {
        float volume = volumeSlider.value;
        myMixer.SetFloat("GeneralVolume", Mathf.Log10(volume) * 20);
    }

    public void BackToPause()
    {
        settingsMenu.SetActive(false);
        pauseMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(playButton.gameObject);
    }

    public void BackToMainMenu()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
