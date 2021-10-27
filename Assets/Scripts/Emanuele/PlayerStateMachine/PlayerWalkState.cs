using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("CIAO A TUTTI DALLO STATE INIZIALE!");

        Animator anim = player.GetComponent<Animator>();
        anim.SetBool("cammina", true);
        anim.SetBool("idle", false);
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
        PlayerMove playerMove = GetComponent<PlayerMove>();
        //Debug.Log("ANGIOVI"+Input.GetAxis("Horizontal"));
        if (playerMove.siMuove==false)
        {
            player.SwitchState(player.idleState);
        }

    }

    
}
