using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Goblin : Enemy
{
    public GameObject playerTransform;

    public float attackRadius = default;

    public Transform[] path;

    int currentPoint;

    public float timer;
    public float nextTime = default;
    public bool inRange;

    public NavMeshAgent _agent;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameManager.instance.player.transform.gameObject;
       
    }

  
    public void MoveToPath()
    {
        if(!inRange && _agent.remainingDistance < 0.5f)
        {
            _agent.destination= path[currentPoint].position;
            UpdateCurrentPoint();
 
        }
    }

    public void UpdateCurrentPoint()
    {
        if(currentPoint == path.Length-1) //siamo nell ultimo nodo della path
        {
            currentPoint = 0;
        }
        else
        {
            currentPoint++;
        }
    }


}
