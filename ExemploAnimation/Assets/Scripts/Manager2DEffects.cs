using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager2DEffects : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource2DEffect;
    public void PlayAudioClip(AudioClip audioClip)
    {
        audioSource2DEffect.PlayOneShot(audioClip);  
    }
}