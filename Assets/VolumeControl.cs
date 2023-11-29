using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GameObject.FindAnyObjectByType<AudioManager>().GetComponent<AudioSource>();
        // Make sure the slider and audio source are properly assigned.
        if (volumeSlider == null || audioSource == null)
        {
            Debug.LogWarning("Volume Slider or Audio Source not assigned.");
            return;
        }

        // Set the slider's initial value to the current volume.
        volumeSlider.value = AudioManager.Instance.volume;

        // Add an event listener to the slider to change the volume when the slider value changes.
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
    }

    public void ChangeVolume(float volume)
    {
       // audioSource.volume = volume;
        AudioManager.Instance.EditVolume(volume);

    }
}
