using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalkState : EnemyBaseState
{
    public Minions minions;

    public override void EnterState(EnemyStateManager enemy)
    {
        Animator anim = enemy.GetComponent<Animator>();
       anim.SetBool("cammina", true);
       anim.SetBool("idle", false);   
       // anim.SetBool("spaventato", false);
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
            Vector3 dirToPlayer = minions.transform.position - minions.playerTransform.transform.position;
            minions.newPos = minions.transform.position + dirToPlayer;

            minions._agent.SetDestination(minions.newPos);
        }

        if (Vector3.Distance(minions.transform.position, minions.newPos) < 0.2f)
        {
            
                enemy.SwitchState(enemy.idleState);
            
        }

    }

    
}
