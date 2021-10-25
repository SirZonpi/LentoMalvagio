using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Minions : MonoBehaviour
{

    NavMeshAgent _agent;
    public float enemyDistanceRun=default;
    public GameObject playerTransform;

    Rigidbody _rb;
    EnemyStateManager _enemyStateManager;
    Vector3 newPos;

    void Start()
    {
        newPos = transform.position;
        _enemyStateManager = GetComponent<EnemyStateManager>();
        _agent = GetComponent<NavMeshAgent>();
        _rb = GetComponent<Rigidbody>();
    }

  
    void Update()
    {
        Debug.Log("ora " + transform.position + "prossima " + newPos);
        if (Vector3.Distance(transform.position, newPos) > 0.2f)
        {
            //_enemyStateManager.SwitchState(_enemyStateManager.scaredState);
           // _enemyStateManager.SwitchState(_enemyStateManager.walkState);
        }
        else if(Vector3.Distance(transform.position,newPos) <0.2f)
        {
            _enemyStateManager.SwitchState(_enemyStateManager.idleState);
        }

        float distance = Vector3.Distance(transform.position, playerTransform.transform.position);

        if(distance < enemyDistanceRun)
        {
           
            Vector3 dirToPlayer = transform.position - playerTransform.transform.position;
              newPos = transform.position + dirToPlayer;

            _agent.SetDestination(newPos);

        }
        
    }
}
