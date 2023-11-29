using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenuFunctions : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settingsMenu;
    public GameObject playButton;
    public Slider volumeSlider;

    [SerializeField] private AudioMixer myMixer;

    private void Start()
    {
        SetVolume();
    }

    public void Play()
    {
        SceneManager.LoadScene(3);
    }

    public void Settings()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(volumeSlider.gameObject);
    }

    public void Exit()
    {
        Application.Quit();
    }

    void SetVolume()
    {
        float volume = volumeSlider.value;
        myMixer.SetFloat("GeneralVolume", Mathf.Log10(volume) * 20);
    }

    public void Back()
    {



        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(playButton.gameObject);
    }
}
