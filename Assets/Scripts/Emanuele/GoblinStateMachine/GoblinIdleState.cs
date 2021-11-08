using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinIdleState : GoblinBaseState
{
    public Goblin goblin;

    public Collider pugnoDes;
    public Collider pugnoSin;
    public override void EnterState(GoblinStateManager goblin)
    {
        pugnoDes.enabled = false;
        pugnoSin.enabled = false;

        Goblin goblinScript = GetComponent<Goblin>();
        Animator anim = goblin.GetComponent<Animator>();
        anim.SetBool("idle", true);
        anim.SetBool("cammina", false);
        anim.SetBool("attacca", false);
        anim.SetBool("attacca2", false);
        anim.SetBool("attacca3", false);
        anim.SetBool("damage", false);
    }

    public override void onCollisionEnter(GoblinStateManager goblin)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(GoblinStateManager goblin)
    {
        Animator anim = goblin.GetComponent<Animator>();

        anim.SetBool("idle", true);
        anim.SetBool("cammina", false);

       // Goblin goblinScript = GetComponent<Goblin>();

        goblin.SwitchState(goblin.walkState);
         
    }

}
