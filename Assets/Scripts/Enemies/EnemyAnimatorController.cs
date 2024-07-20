using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimatorController : MonoBehaviour
{
    [HideInInspector] public bool deathAnimEnded;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        deathAnimEnded = false;
        animator.SetBool("isWalking", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyDeath()
    {
        animator.SetBool("isWalking", false);
        StartCoroutine(DeathCoroutine());
    }

    private IEnumerator DeathCoroutine()
    {
        animator.SetBool("isDead", true);
        yield return new WaitForSeconds(0.3f);
        deathAnimEnded = true;
    }
}
