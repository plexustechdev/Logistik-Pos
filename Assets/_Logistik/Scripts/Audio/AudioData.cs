using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;

public class AudioData : MonoBehaviour
{
    public AudioClip bgmAudio;
    public SerializedDictionary<string, AudioClip> sfxList = new();
}
