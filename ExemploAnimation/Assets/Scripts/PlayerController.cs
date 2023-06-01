using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;

    public void PlayAnimation(string nomeAnimation) {
        animator.Play(nomeAnimation);
    }
}
