using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollisionCoin2D : MonoBehaviour
{
    private GameObject targetCoin;
    private bool isMoveCoin = false;
    [SerializeField] private EffectsManager effectsManager;
    [SerializeField] private GameObject effectCoin;
    // Start is called before the first frame update
    void Start()
    {
        targetCoin = GameObject.FindGameObjectWithTag("CoinTarget");
        effectsManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<EffectsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoveCoin)
        {
            transform.position = Vector2.Lerp(transform.position, targetCoin.transform.position, 5f * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            GameObject particula =  Instantiate(effectCoin, transform.position, transform.rotation);
            effectsManager.SetAudioClip(0);
            float tempoDeVidaParticula = particula.GetComponent<ParticleSystem>().main.duration;
            gameObject.GetComponent<Collider2D>().enabled = false;
            isMoveCoin = true;
            collision.GetComponent<Player2D>().countCoins += 1;

            Destroy(particula, tempoDeVidaParticula);
            Destroy(gameObject, 2f);


        }
    }
}
