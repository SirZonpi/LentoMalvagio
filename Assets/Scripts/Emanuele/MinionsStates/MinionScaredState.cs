using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionScaredState : MinionBaseState
{
    public int cambia=0;
    public override void EnterState(MinionStateManager minion)
    {
        Debug.Log("CIAO A TUTTI DALLO STATE INIZIALE!");

        Animator anim = minion.GetComponent<Animator>();
        anim.SetBool("idle", false);
        anim.SetBool("cammina", false);
        anim.SetBool("spaventato",true);
    }

    public override void onCollisionEnter(MinionStateManager minion)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(MinionStateManager minion)
    {
        if (cambia==1)
        {
            minion.SwitchState(minion.walkState);

        }
        else { return; }
    }

    public void Cambia(int _cambia)
    {
        cambia = _cambia ;
    }
   

}
