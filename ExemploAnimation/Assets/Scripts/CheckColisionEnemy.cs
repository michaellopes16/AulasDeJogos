using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckColisionEnemy : MonoBehaviour
{
    public float temporaryAnimationDuration = 2f;
    private AnimationClip originalAnimation;
    public int damagePlayer = 10;
    public GameObject PikupEffect;
    public bool isBullet = false;
    private Manager3DEffects manager3DEffects;
    private Manager2DEffects manager2DEffects;
    [SerializeField] AudioClip audioClipDiethEffect;
    [SerializeField] AudioClip audioClipDemageEffect;
    [SerializeField] private int healthCount = 30;

    public HealthBar healthBar;

    private void Start()
    {
        //healthBar.SetMaxHealth(50);
        manager3DEffects = GameObject.Find("Manager3DEffects").GetComponent<Manager3DEffects>();
        manager2DEffects = GameObject.Find("Manager2DEffects").GetComponent<Manager2DEffects>();
        if (gameObject.CompareTag("Soldier"))
        {
            healthBar.SetMaxHealth(healthCount);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            manager2DEffects.PlayAudioClip(audioClipDemageEffect);
            // Faz a procura de um subobjeto pelo nome
            Transform weaponPlayerTransform = collision.gameObject.transform.Find("WeaponAim");
            // Verifica se o subobjeto foi encontrado
            if (weaponPlayerTransform != null)
            {
                GameObject weaponPlayerObject = weaponPlayerTransform.gameObject;
                if (weaponPlayerObject.activeSelf)
                {
                    weaponPlayerObject.SetActive(false);
                }
            }
            else
            {
                Debug.LogError("Subobjeto com a tag WeaponAim não encontrado no objeto colidido!");
            }
            Animator animator = collision.gameObject.GetComponent<Animator>();           
            StartCoroutine(PlayTemporaryAnimation(animator, "Death"));
            collision.gameObject.GetComponent<Player>().TakeDamage(damagePlayer);
            if (isBullet)
            {
                Destroy(gameObject);
            }
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (gameObject.CompareTag("Soldier"))
            {
                healthCount -= 10;
                healthBar.SetHealth(healthCount);
                Animator animatorSoldier = gameObject.GetComponent<Animator>();
                StartCoroutine(PlayTemporaryAnimation(animatorSoldier, "AnimSoldDeath"));
                //healthBar.SetHealth(healthCount);
                //Add a death effect when the collision ocour
                if (healthCount <= 0)
                {
                    DestroyObject(collision);
                }
            }
            else
            {
                DestroyObject(collision);
            }
        }
    }

    private void DestroyObject(Collider2D collision)
    {
        manager3DEffects.PlayAudioClip(audioClipDiethEffect);
        GameObject particula = Instantiate(PikupEffect, transform.position, transform.rotation);
        //Distroy the enemy and the effect generated with death
        float tempoDeVidaParticula = particula.GetComponent<ParticleSystem>().main.duration;
        Destroy(collision.gameObject);
        gameObject.SetActive(false);
        Destroy(particula, tempoDeVidaParticula);
        Destroy(gameObject, 3f);
    }

    IEnumerator PlayTemporaryAnimation(Animator animator, string animName)
    {
        originalAnimation = animator.GetCurrentAnimatorClipInfo(0)[0].clip;
        // Reproduza a animação temporária
        animator.Play(animName);
        // Espere pela duração da animação temporária
        yield return new WaitForSeconds(temporaryAnimationDuration);

        // Volte para a anima��o anterior
        animator.Play(originalAnimation.name);
    }
}

