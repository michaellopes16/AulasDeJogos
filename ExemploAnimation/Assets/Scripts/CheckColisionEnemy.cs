using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckColisionEnemy : MonoBehaviour
{
    public float temporaryAnimationDuration = 2f;
    private AnimationClip originalAnimation;
    public int damagePlayer = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Animator animator = collision.gameObject.GetComponent<Animator>();
            originalAnimation = animator.GetCurrentAnimatorClipInfo(0)[0].clip;
            StartCoroutine(PlayTemporaryAnimation(animator));
            collision.gameObject.GetComponent<Player>().TakeDamage(damagePlayer);
        }
    }
    IEnumerator PlayTemporaryAnimation(Animator animator)
    {
        // Reproduza a anima��o tempor�ria
        animator.Play("Death");

        // Espere pela dura��o da anima��o tempor�ria
        yield return new WaitForSeconds(temporaryAnimationDuration);

        // Volte para a anima��o anterior
        animator.Play(originalAnimation.name);
    }
}
