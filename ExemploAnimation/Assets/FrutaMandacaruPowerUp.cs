using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrutaMandacaruPowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private AudioClip effectGet;
    [SerializeField]
    private Manager2DEffects manager2DEffects;
    void Start()
    {
        manager2DEffects = GameObject.Find("Manager2DEffects").GetComponent<Manager2DEffects>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            collision.GetComponent<Player>().UpFlorMandacaru();
            manager2DEffects.PlayAudioClip(effectGet);
            Destroy(gameObject);
        }
    }
}
