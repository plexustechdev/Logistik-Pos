using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDeliveryMap : MonoBehaviour
{
    [SerializeField] private AudioSource _bgmAudio;

    private void OnEnable()
    {
        _bgmAudio.volume = PlayerPrefs.GetFloat(Volume.BGM_VOLUME.ToString());
    }
}
