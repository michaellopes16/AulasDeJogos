using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckColisionEnemy : MonoBehaviour
{
    public float temporaryAnimationDuration = 2f;
    private AnimationClip originalAnimation;
    public float damagePlayer = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Animator animator = collision.gameObject.GetComponent<Animator>();
            originalAnimation = animator.GetCurrentAnimatorClipInfo(0)[0].clip;
            StartCoroutine(PlayTemporaryAnimation(animator));
            collision.gameObject.GetComponent<Player>().countHelth -= damagePlayer;
        }
    }
    IEnumerator PlayTemporaryAnimation(Animator animator)
    {
        // Reproduza a animação temporária
        animator.Play("Death");

        // Espere pela duração da animação temporária
        yield return new WaitForSeconds(temporaryAnimationDuration);

        // Volte para a animação anterior
        animator.Play(originalAnimation.name);
    }
}
