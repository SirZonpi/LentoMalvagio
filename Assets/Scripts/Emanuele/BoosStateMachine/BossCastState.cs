using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCastState : BossBaseState
{
    public Boss bossScript;

    public int casta;

    public override void EnterState(BossStateManager boss)
    {
        Animator anim = boss.GetComponent<Animator>();
        anim.SetBool("idle", false);
        anim.SetBool("tent_side", false);
        anim.SetBool("tent_front", false);
        anim.SetBool("castaSpell", true);
        anim.SetBool("rotola", false);

        casta = 0;

    }

    public override void onCollisionEnter(BossStateManager boss)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(BossStateManager boss)
    {
        if (casta == 1)
        {
            bossScript.BossCastSpell();
            //bossScript.Cooldown();
            boss.SwitchState(boss.idleState);

        }

        

    }

    public void Casta(int _casta)
    {
        casta = _casta;
    }


}
