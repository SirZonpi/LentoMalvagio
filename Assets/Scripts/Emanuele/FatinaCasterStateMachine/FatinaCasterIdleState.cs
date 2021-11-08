using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatinaCasterIdleState : FatinaCasterBaseState
{
    public FatinaSpellCaster fatina;

    public override void EnterState(FatinaCasterStateManager fatinaCaster)
    {
        Animator anim = fatinaCaster.GetComponent<Animator>();
        anim.SetBool("idle", true);
        anim.SetBool("cammina", false);
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

        //Debug.Log("distance " + distance);

        if (distance < fatina.enemyDistance)
        {

            Vector3 dirToPlayer = transform.position - fatina.playerTransform.transform.position;
            fatina.newPos = transform.position + dirToPlayer;

            // fatina._agent.SetDestination(fatina.newPos);

            fatinaCaster.SwitchState(fatinaCaster.walkState);

        }

        if (distance >= fatina.enemyDistance && distance <= 10f)
        {
            Vector3 direction = fatina.playerTransform.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 10);

            Ray ray = new Ray(fatina.spellSpawnPoint.transform.position, fatina.spellSpawnPoint.transform.forward);
            RaycastHit hit;
            Physics.Raycast(ray, out hit, 8f);

           // Debug.Log("HIT MIS " + ray.direction);

            if (hit.transform != null && hit.transform.CompareTag("Player"))
            {
                fatinaCaster.SwitchState(fatinaCaster.attackState);

             
            }


        }



    }


}
