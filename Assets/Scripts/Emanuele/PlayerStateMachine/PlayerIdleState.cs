using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("CIAO A TUTTI DALLO STATE INIZIALE!");

        Animator anim = player.GetComponent<Animator>();
        anim.SetBool("idle", true);
        anim.SetBool("cammina", false);
        anim.SetBool("attacca", false); 
        anim.SetBool("attacca2", false);
        anim.SetBool("attacca3", false);
        anim.SetBool("damage", false);
    }

    public override void onCollisionEnter(PlayerStateManager player)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(PlayerStateManager player)
    {
        Animator anim = player.GetComponent<Animator>();
        anim.SetBool("idle", true);
        anim.SetBool("cammina", false);

        PlayerMove playerMove = GetComponent<PlayerMove>();

        if (playerMove.siMuove == true)
        {
            player.SwitchState(player.walkState);
        }

    }

   

}
