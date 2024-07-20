using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviorController : MonoBehaviour
{
    private Transform playerTransform;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GlobalParametersManager.instance.playerPos;
        agent = GetComponent<NavMeshAgent>();
        agent.destination = playerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
