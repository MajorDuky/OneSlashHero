using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    Animator animator;
    public bool isCrouched;

    private void Start()
    {
        animator = GetComponent<Animator>();
        isCrouched = false;
    }
    public void Crouch()
    {
        isCrouched = true;
        animator.SetBool("isAiming", true);
    }

    public void StopCrouching()
    {
        isCrouched = false;
        animator.SetBool("isAiming", false);
    }
}
