using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;
    public AudioSource audioSource;
    public AudioSource as_WinLose;
    public AudioSource backsound;
    public AudioClip audioPecah;
    public AudioClip audioWin;
    public AudioClip audioLost;


    void Start()
    {
        instance = this;
    }

    private void OnEnable()
    {
        AddTempo(backsound, 1.5f);
    }

    public void AddTempo(AudioSource audioSource, float multiplier)
    {
        audioSource.pitch = multiplier;
        audioSource.outputAudioMixerGroup.audioMixer.SetFloat("Pitch", 1f / multiplier);
    }

    public void PlayPecah()
    {
        audioSource.clip = audioPecah;
        audioSource.Play();
    }

    public void PlayWin(bool val)
    {
        backsound.Stop();
        AudioClip clip = audioWin;
        if (val)
        {
            as_WinLose.clip = clip;
        }
        else
        {
            as_WinLose.clip = audioLost;
        }

        as_WinLose.Play();
    }



}
