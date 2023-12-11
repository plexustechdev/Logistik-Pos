using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioView : MonoBehaviour
{
    [SerializeField] private Slider _bgmSlider;
    [SerializeField] private Slider _sfxSlider;

    public void LoadVolume()
    {
        _bgmSlider.value = AudioGlobalController.instance.LoadVolume().bgmVolume;
        _sfxSlider.value = AudioGlobalController.instance.LoadVolume().sfxVolume;
    }

    public void SaveVolume()
    {
        AudioGlobalController.instance.SaveVolume(_bgmSlider.value, _sfxSlider.value);
    }
}
