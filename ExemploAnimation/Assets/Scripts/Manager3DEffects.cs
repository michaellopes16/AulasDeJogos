using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager3DEffects : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioSource audioSource2DEffect;
    public void PlayAudioClip(AudioClip audioClip)
    {
        audioSource2DEffect.PlayOneShot(audioClip);
    }
}
