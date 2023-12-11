using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioGlobalController : MonoBehaviour
{
    public static AudioGlobalController instance;

    [SerializeField] private AudioSource _audioBGM;
    [SerializeField] private AudioSource _audioSFX;

    private void Start()
    {
        if (instance != null && instance != this) Destroy(this);
        else instance = this;
    }

    public void SaveVolume(float bgmAudio, float sfxAudio)
    {
        PlayerPrefs.SetFloat(Volume.BGM_VOLUME.ToString(), bgmAudio);
        PlayerPrefs.SetFloat(Volume.SFX_VOLUME.ToString(), sfxAudio);
    }

    public (float bgmVolume, float sfxVolume) LoadVolume()
    {
        float bgm = PlayerPrefs.GetFloat(Volume.BGM_VOLUME.ToString());
        float sfx = PlayerPrefs.GetFloat(Volume.SFX_VOLUME.ToString());

        return (bgmVolume: bgm, sfxVolume: sfx);
    }
}

public enum Volume
{
    BGM_VOLUME,
    SFX_VOLUME
}
