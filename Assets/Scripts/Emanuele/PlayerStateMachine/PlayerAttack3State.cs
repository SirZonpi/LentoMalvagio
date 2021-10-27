using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack3State : PlayerBaseState
{
    public int cambia;

    public override void EnterState(PlayerStateManager player)
    {
        cambia = 1;

        Animator anim = player.GetComponent<Animator>();

        anim.SetBool("attacca3", true);
        //anim.SetBool("attacca2", true);
        anim.SetBool("idle", false);
        anim.SetBool("cammina", false);
        //anim.SetBool("attacca", true);
    }

    public override void onCollisionEnter(PlayerStateManager player)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (cambia == 0)
        {
            player.SwitchState(player.idleState);

        }
    }

    public void Cambia3(int _cambia) //da cambiare con una stringa, è un animaton event
    {
        cambia = _cambia;

    }

}
