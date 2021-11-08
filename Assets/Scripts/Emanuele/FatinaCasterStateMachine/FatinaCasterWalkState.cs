using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatinaCasterWalkState : FatinaCasterBaseState
{
    public FatinaSpellCaster fatina;

    public override void EnterState(FatinaCasterStateManager fatinaCaster)
    {
        Animator anim = fatinaCaster.GetComponent<Animator>();
        anim.SetBool("idle", false);
        anim.SetBool("cammina", true);
        anim.SetBool("damage", false);
        anim.SetBool("attacca", false);
    }

    public override void onCollisionEnter(FatinaCasterStateManager fatinaCaster)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(FatinaCasterStateManager fatinaCaster)
    {
        float distance = Vector3.Distance(transform.position, fatina.playerTransform.transform.position);

        Ray ray = new Ray(fatina.spellSpawnPoint.transform.position, fatina.spellSpawnPoint.transform.forward);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, 8f);

       // float distance = Vector3.Distance(transform.position, fatina.playerTransform.transform.position);

        //Debug.Log("distance " + distance);

        if (distance < fatina.enemyDistance)
        {

            Vector3 dirToPlayer = transform.position - fatina.playerTransform.transform.position;
            fatina.newPos = transform.position + dirToPlayer;

             fatina._agent.SetDestination(fatina.newPos);

           // fatinaCaster.SwitchState(fatinaCaster.walkState);

        }
        else if (distance > fatina.enemyDistance /*&& hit.transform == null*/)
        {
            fatinaCaster.SwitchState(fatinaCaster.idleState);
        }

        if (hit.transform != null && hit.transform.CompareTag("Player"))
        {
            Debug.Log("la fatina sta attaccando ");

            fatinaCaster.SwitchState(fatinaCaster.attackState);


            /*
            Debug.Log("FATINA SPARA");
            fatina.timeRate += Time.deltaTime;

            if (fatina.timeRate >= 1)
            {
                fatina.CastSpell();
                fatina.timeRate = 0;
            }
            */

        }
        
         
    }

}
