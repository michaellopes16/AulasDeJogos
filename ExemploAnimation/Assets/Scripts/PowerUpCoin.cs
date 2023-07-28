using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCoin : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PikupEffect;

    //Velocidade da subida da moeda
    [SerializeField] private float speed = 5f;

    bool moveCoin;

    GameObject target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("CoinTarget");
    }

    private void Update()
    {
        if (moveCoin)
        {
            transform.position = Vector3.Lerp(transform.position,target.transform.position,speed*Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Adicionar um efeito ao tocar na moeda
            GameObject particula =  Instantiate(PikupEffect, transform.position,transform.rotation);

            //Desabilitar o colider para não ter problemas com colisão
            gameObject.GetComponent<Collider2D>().enabled = false;
            moveCoin = true;
            //Incrementar um contador das moedas
            Player player =  collision.GetComponent<Player>();
            player.countCoins += 1;

            //Destroir meu objeto
            float tempoDeVidaParticula = particula.GetComponent<ParticleSystem>().main.duration;
            Destroy(particula, tempoDeVidaParticula);
            Destroy(gameObject, 1.8f);
        }
    }
}
