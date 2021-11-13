using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatinaCasterAttackState : FatinaCasterBaseState
{
    public FatinaSpellCaster fatina;

    public int cambia;

    public override void EnterState(FatinaCasterStateManager fatinaCaster)
    {
        cambia = 0;

        Animator anim = fatinaCaster.GetComponent<Animator>();
        anim.SetBool("idle", false);
        anim.SetBool("cammina", false);
        anim.SetBool("damage", false);
        anim.SetBool("attacca", true);
    }

    public override void onCollisionEnter(FatinaCasterStateManager fatinaCaster)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(FatinaCasterStateManager fatinaCaster)
    {
        float distance = Vector3.Distance(transform.position, fatina.playerTransform.transform.position);


        Vector3 direction = fatina.playerTransform.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 10);

        Ray ray = new Ray(fatina.spellSpawnPoint.transform.position, fatina.spellSpawnPoint.transform.forward);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, 8f);

       // Debug.Log("FATINA SPARA");
        fatina.timeRate += Time.deltaTime;

        if (hit.transform != null && hit.transform.CompareTag("Player"))
        {
            if (fatina.timeRate >= 1)
            {
                if (cambia == 1)
                {
                    fatina.CastSpell();
                    fatina.timeRate = 0;
                }
            }
        }
        else if (distance < fatina.enemyDistance)
        {
            
            fatinaCaster.SwitchState(fatinaCaster.walkState);

        }
        else
        {
            fatinaCaster.SwitchState(fatinaCaster.idleState);

        }



    }

    public void Cambia(int _cambia)
    {
        cambia = _cambia;
    }

}
