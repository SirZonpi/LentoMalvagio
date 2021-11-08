using System.Collections;
using System.Collections.Generic;
using UnityEngine;
  
public class MinionIdleState : MinionBaseState
{
    public Minions minions;

    public override void EnterState(MinionStateManager minion)
    {
        Debug.Log("CIAO A TUTTI DALLO STATE INIZIALE!");

        Animator anim = minion.GetComponent<Animator>();
        anim.SetBool("cammina", false);
        anim.SetBool("idle", true);
        

    }

    public override void onCollisionEnter(MinionStateManager minion)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(MinionStateManager minion)
    {
        float distance = Vector3.Distance(transform.position, minions.playerTransform.transform.position);

        if (distance < minions.enemyDistanceRun)
        {
            minion.SwitchState(minion.walkState);
            /*
            Vector3 dirToPlayer = transform.position - minions.playerTransform.transform.position;
            minions.newPos = transform.position + dirToPlayer;

            minions._agent.SetDestination(minions.newPos);
            */
        }

    }


}
