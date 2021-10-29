using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
 

public class Lupo : Enemy
{
    public GameObject playerTransform;

    public float attackRadius = default;

    public float timer;
    public float nextTime = default;
    public bool inRange;

    public NavMeshAgent _agent;

    public bool loadSpell;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector3.Distance(transform.position, playerTransform.transform.position);
        Debug.Log("distance " + distance);


        if (distance <= attackRadius)
        {
            loadSpell = true;
        }




    }
}
