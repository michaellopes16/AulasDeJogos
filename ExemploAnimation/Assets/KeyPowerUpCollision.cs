using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPowerUpCollision : MonoBehaviour
{
    [SerializeField]
    private AudioClip effectGet;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private SpriteRenderer spriteRendererDor;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            spriteRendererDor.enabled = false;
            collision.GetComponent<Player>().GetKey();
            audioSource.PlayOneShot(effectGet);
            Destroy(gameObject);
        }
    }
}
