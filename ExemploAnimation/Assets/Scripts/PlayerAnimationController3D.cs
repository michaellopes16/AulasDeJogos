using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController3D : MonoBehaviour
{
    [SerializeField] public Animator playerAnimator;
    public void PlayAnimation(string animationName) {
        playerAnimator.Play(animationName);
    }
}
