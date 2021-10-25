using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalkState : EnemyBaseState
{
 
    public override void EnterState(EnemyStateManager enemy)
    {
        Animator anim = enemy.GetComponent<Animator>();
        anim.SetBool("idle", false);
        anim.SetBool("cammina", true);
        anim.SetBool("spaventato", false);
    }

    public override void onCollisionEnter(EnemyStateManager enemy)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(EnemyStateManager enemy)
    { 

    }

    
}
