using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioSource audioSourceMusic;
    [SerializeField] private AudioClip[] audioClipMusic;
    [SerializeField] int IndexMusic = 0;

    private void Start()
    {
        SetAudioClip(IndexMusic);
    }
    public void SetAudioClip(int indiceAudio) {
        if(indiceAudio < audioClipMusic.Length)
        {
            audioSourceMusic.clip = audioClipMusic[indiceAudio];
            audioSourceMusic.Play();
        }
    }
}
