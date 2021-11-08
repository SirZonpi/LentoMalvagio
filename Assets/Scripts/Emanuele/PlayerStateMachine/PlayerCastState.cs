using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCastState : PlayerBaseState
{
    public Player playerScript;
    public PlayerMove playerMove;

    public override void EnterState(PlayerStateManager player)
    {
        Animator anim = player.GetComponent<Animator>();

        anim.SetBool("castaspell", true);
        anim.SetBool("idle", false);
        anim.SetBool("cammina", false);
        anim.SetBool("attacca2", false); 
        anim.SetBool("attacca3", false);
        anim.SetBool("attacca", false);

    }

    public override void onCollisionEnter(PlayerStateManager player)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(PlayerStateManager player)
    {
        
        playerScript.CastSpell();
        player.SwitchState(player.idleState);

        if (playerMove.siMuove)
        {
            player.SwitchState(player.walkState);
        }

    }

   
}
