using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCheckCollision : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject weapon;
    [SerializeField] private AudioClip audioClip3Deffect;
    private Manager2DEffects manager2DEffects;
    private void Start()
    {
        manager2DEffects = GameObject.Find("Manager2DEffects").GetComponent<Manager2DEffects>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            manager2DEffects.PlayAudioClip(audioClip3Deffect);
            weapon.SetActive(true);
            Destroy(gameObject);
        }
    }
}
