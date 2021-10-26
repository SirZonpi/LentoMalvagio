using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    public int cambia = 0;
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("CIAO A TUTTI DALLO STATE INIZIALE!");

        Animator anim = player.GetComponent<Animator>();
        anim.SetBool("idle", false);
        anim.SetBool("cammina", false);
        anim.SetBool("attacca", true);
    }

    public override void onCollisionEnter(PlayerStateManager player)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (cambia == 1)
        {
            player.SwitchState(player.idleState);

        }
        else { return; }

    }

    public void Cambia(int _cambia)
    {
        cambia = _cambia;
    }

    private void Update()
    {
        Debug.Log("questo cambia " + cambia);
    }

}
