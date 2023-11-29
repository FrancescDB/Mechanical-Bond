using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider generalVolumeSlider;
    [SerializeField] private Slider sfxSlider;

    private void Start()
    {
        SetMusicVolume();
        SetGeneralVolume();
        SetSfxVolume();
    }

    public void SetMusicVolume()
    {
        float volume1 = musicSlider.value;
        myMixer.SetFloat("Music", Mathf.Log10(volume1) * 20);
    }

    public void SetGeneralVolume()
    {
        float volume2 = generalVolumeSlider.value;
        myMixer.SetFloat("GeneralVolume", Mathf.Log10(volume2) * 20);
    }

    public void SetSfxVolume()
    {
        float volume3 = sfxSlider.value;
        myMixer.SetFloat("Sfx", Mathf.Log10(volume3) * 20);
    }
}
