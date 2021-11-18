using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTentacoliFrontState : BossBaseState
{
    public Boss bossScript;

    public int cambia;

    public override void EnterState(BossStateManager boss)
    {
        cambia = 0;

        Animator anim = boss.GetComponent<Animator>();
        anim.SetBool("idle", false);
        anim.SetBool("tent_side", false);
        anim.SetBool("tent_front", true);
        anim.SetBool("castaSpell", false);
        anim.SetBool("rotola", false);
    }

    public override void onCollisionEnter(BossStateManager boss)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(BossStateManager boss)
    {
        bossScript.BossGira();

        if (cambia == 1)
        {
            boss.SwitchState(boss.idleState);
        }
    }

 
    public void Cambia2(int _cambia)
    {
        cambia = _cambia;
    }

}
