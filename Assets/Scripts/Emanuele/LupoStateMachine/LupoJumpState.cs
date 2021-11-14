using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LupoJumpState : LupoBaseState
{
    public Lupo lupoScript;

    public override void EnterState(LupoStateManager lupo)
    {
        Animator anim = lupo.GetComponent<Animator>();
        anim.SetBool("idle", false);
        anim.SetBool("salta", true);
        anim.SetBool("damage", false);
        anim.SetBool("attacca", false);

        lupoScript.isAttacking = false;

    }

    public override void onCollisionEnter(LupoStateManager lupo)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(LupoStateManager lupo)
    {
        float distance = Vector3.Distance(transform.position, lupoScript.playerTransform.transform.position);


        //lupoScript._agent.SetDestination(lupoScript.newPos);
       // lupoScript.MoveToPath();

        if (distance > 5)
        {

            Vector3 dirToPlayer = transform.position - lupoScript.playerTransform.transform.position;
            lupoScript.newPos = transform.position + dirToPlayer;


            lupo.SwitchState(lupo.idleState);
        }
         
        else
        {
            // lupo.SwitchState(lupo.jumpState);
            lupoScript.MoveToPath();


        }


    }
}
