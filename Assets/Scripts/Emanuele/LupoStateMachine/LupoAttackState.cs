using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LupoAttackState : LupoBaseState
{
    public Lupo lupoScript;

    public override void EnterState(LupoStateManager lupo)
    {
        Animator anim = lupo.GetComponent<Animator>();
        anim.SetBool("idle", false);
        anim.SetBool("salta", false);
        anim.SetBool("damage", false);
        anim.SetBool("attacca", true);
    }

    public override void onCollisionEnter(LupoStateManager lupo)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(LupoStateManager lupo)
    {
        float distance = Vector3.Distance(transform.position, lupoScript.playerTransform.transform.position);

        Vector3 direction = lupoScript.playerTransform.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 10);

        if (distance < 5)
        {

            Vector3 dirToPlayer = transform.position - lupoScript.playerTransform.transform.position;
            lupoScript.newPos = transform.position + dirToPlayer;
            transform.rotation = Quaternion.Euler( direction);///

            lupo.SwitchState(lupo.jumpState);

        }

        else if (lupoScript.time <= 3f)
        {
            lupoScript.time += Time.deltaTime;
            if (lupoScript.time >= 3f)
            {
                lupoScript.CastSpell();
                lupoScript.time = 0f;
            }

        }

    }
}
