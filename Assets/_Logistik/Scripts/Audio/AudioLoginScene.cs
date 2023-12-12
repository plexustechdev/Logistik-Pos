using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioLoginScene : MonoBehaviour
{
    [SerializeField] private Slider _bgmSlider;
    [SerializeField] private Slider _sfxSlider;

    [Header("Audio Source")]
    [SerializeField] private AudioSource _bgmAudioSource;
    [SerializeField] private AudioSource _sfxAudioSource;

    private void Start()
    {
        LoadVolume();
    }

    public void LoadVolume()
    {
        _bgmSlider.value = AudioGlobalController.LoadVolume().bgmVolume;
        _sfxSlider.value = AudioGlobalController.LoadVolume().sfxVolume;

        ChangeVolume();
    }

    public void ChangeVolume()
    {
        _bgmAudioSource.volume = _bgmSlider.value;
        _sfxAudioSource.volume = _sfxSlider.value;
    }

    public void SaveVolume()
    {
        AudioGlobalController.SaveVolume(_bgmSlider.value, _sfxSlider.value);

        ChangeVolume();
    }
}
