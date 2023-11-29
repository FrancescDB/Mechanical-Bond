using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenuFunctions : MonoBehaviour
{
    public GameObject audioCanvas;
    public GameObject image;

    public void Audio()
    {
        image.SetActive(true);
        audioCanvas.SetActive(true);
    }

    public void Controls()
    {

    }

    public void Back()
    {
        
    }

    public void BackToSettings()
    {
        image.SetActive(false);
        audioCanvas.SetActive(false);
    }
}
