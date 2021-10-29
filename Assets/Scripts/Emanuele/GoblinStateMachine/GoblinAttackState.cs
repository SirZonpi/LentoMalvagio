using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinAttackState : GoblinBaseState
{
    public Goblin _goblin;

    public override void EnterState(GoblinStateManager goblin)
    {
        Animator anim = goblin.GetComponent<Animator>();
        anim.SetBool("idle", false);
        anim.SetBool("cammina", false);
        anim.SetBool("attacca", true);
        //anim.SetTrigger("resettaAttacca");
    }

    public override void onCollisionEnter(GoblinStateManager goblin)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(GoblinStateManager goblin)
    {
        Debug.Log("GOBLIN ATTACCA ");
        Animator anim = goblin.GetComponent<Animator>();
        float distance = Vector3.Distance(transform.position, _goblin.playerTransform.transform.position);

        if (distance <= _goblin.attackRadius && distance > 1.3)
        { 
            goblin.SwitchState(goblin.walkState);
        }
    }
}
