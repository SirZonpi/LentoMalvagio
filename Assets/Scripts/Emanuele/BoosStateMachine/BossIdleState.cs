using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdleState : BossBaseState
{
    public Boss bossScript;

    int rand;
    public float nextTimeFire=3;
    public  float coolDownTime = 0;

    float tempoAttesa;

    public override void EnterState(BossStateManager boss)
    {
        tempoAttesa = 3;

        Animator anim = boss.GetComponent<Animator>();
        anim.SetBool("idle", true);
        anim.SetBool("tent_side", false);
        anim.SetBool("tent_front", false);
        anim.SetBool("castaSpell", false);
        anim.SetBool("rotola", false);

        rand = Random.Range(0, boss.allStates.Length);

    }

    public override void onCollisionEnter(BossStateManager boss)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(BossStateManager boss)
    {

        //bossScript.Cooldown();
        //boss.SwitchState(boss.rotolaState);
        //Cooldown(boss);

        if (tempoAttesa > 0)
        {
            tempoAttesa -= Time.deltaTime;
        }
        else
        {
            boss.SwitchState(boss.allStates[rand]);
        }



    }

   
}
