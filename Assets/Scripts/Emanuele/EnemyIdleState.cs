using System.Collections;
using System.Collections.Generic;
using UnityEngine;
  
public class EnemyIdleState : EnemyBaseState
{
    public Minions minions;

    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("CIAO A TUTTI DALLO STATE INIZIALE!");

        Animator anim = enemy.GetComponent<Animator>();
        anim.SetBool("cammina", false);
        anim.SetBool("idle", true);
        

    }

    public override void onCollisionEnter(EnemyStateManager enemy)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        float distance = Vector3.Distance(transform.position, minions.playerTransform.transform.position);

        if (distance < minions.enemyDistanceRun)
        {
            enemy.SwitchState(enemy.walkState);
            /*
            Vector3 dirToPlayer = transform.position - minions.playerTransform.transform.position;
            minions.newPos = transform.position + dirToPlayer;

            minions._agent.SetDestination(minions.newPos);
            */
        }

    }


}
