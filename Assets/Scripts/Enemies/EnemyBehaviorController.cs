using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviorController : MonoBehaviour
{
    private Transform playerTransform;
    private NavMeshAgent agent;
    public int health;
    public EnemyColorSphere sphereHandler;
    [SerializeField] private EnemyAnimatorController animatorController;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        playerTransform = GlobalParametersManager.instance.playerPos;
        agent.destination = playerTransform.position;
        if (health == 0 && animatorController.deathAnimEnded)
        {
            SpawnerManager.onEnemySlay.Invoke();
            Destroy(gameObject);
        }
    }

    public void EnemyHit()
    {
        health--;
        if (health == 0)
        {
            agent.speed = 0;
            animatorController.EnemyDeath();
        }
    }
}
