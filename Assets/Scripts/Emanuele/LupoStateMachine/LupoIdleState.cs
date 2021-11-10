using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LupoIdleState : LupoBaseState
{
    public Lupo lupoScript;

    public override void EnterState(LupoStateManager lupo)
    {
        Animator anim = lupo.GetComponent<Animator>();
        anim.SetBool("idle", true);
        anim.SetBool("salta", false);
        anim.SetBool("damage", false);
        anim.SetBool("attacca", false);
    }

    public override void onCollisionEnter(LupoStateManager lupo)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(LupoStateManager lupo)
    {
        float distance = Vector3.Distance(transform.position, lupoScript.playerTransform.transform.position);

        if (distance < 5)
        {

            Vector3 dirToPlayer = transform.position - lupoScript.playerTransform.transform.position;
            lupoScript.newPos = transform.position + dirToPlayer;


            Debug.Log("MINORE");
            lupo.SwitchState(lupo.jumpState);

        }

        if (distance <= 8 && distance >= 5)
        {
            lupoScript.loadSpell = true;

            Vector3 direction = lupoScript.playerTransform.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 10);

            lupo.SwitchState(lupo.attackState);

        }
        /*
        else { lupoScript.loadSpell = false; }

        if (lupoScript.loadSpell)
        {

            if (lupoScript.time <= 4f)
            {
                lupoScript.time += Time.deltaTime;
                if (lupoScript.time >= 4f)
                {
                    lupoScript.CastSpell();
                    lupoScript.time = 0f;
                }

            }
        }
        */

    }


}
