using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsManager : MonoBehaviour
{

    [SerializeField] private AudioSource audioSourceEffect;
    [SerializeField] private AudioClip[] audioClipsEffects;
    // Start is called before the first frame update
    public void SetAudioClip(int indice) {
        if (indice < audioClipsEffects.Length) {
            audioSourceEffect.PlayOneShot(audioClipsEffects[indice]);
        }
    }
}
