using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerMusics : MonoBehaviour
{
    [SerializeField] private AudioSource audioSourceMusic;
    [SerializeField] private AudioClip[] audioClipsMusic;
    [SerializeField] int IndexMusic = 0;
    void Start()
    {
        SetAudioClip(IndexMusic);
    }

    public void SetAudioClip(int indiceAudio)
    {
        if (indiceAudio < audioClipsMusic.Length)
        {
            audioSourceMusic.clip = audioClipsMusic[indiceAudio];
            audioSourceMusic.Play();
        }
        else
        {
            Debug.LogWarning("The value is out of range. It's should be less than: " + audioClipsMusic.Length);
        }
    }
}
