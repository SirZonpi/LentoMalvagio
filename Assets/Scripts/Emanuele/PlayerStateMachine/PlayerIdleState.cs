using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerIdleState : PlayerBaseState
{
    //public CinemachineVirtualCamera vcam;

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
        /*
        if(vcam.m_Lens.OrthographicSize < 12)
            vcam.m_Lens.OrthographicSize = Mathf.MoveTowards(vcam.m_Lens.OrthographicSize, 12, 10 * Time.deltaTime);
        */

         Animator anim = player.GetComponent<Animator>();
        anim.SetBool("idle", true);
        anim.SetBool("cammina", false);
        anim.SetBool("attacca", false);
        anim.SetBool("attacca2", false);
        anim.SetBool("attacca3", false);

        PlayerMove playerMove = GetComponent<PlayerMove>();

        if (playerMove.siMuove == true)
        {
            player.SwitchState(player.walkState);
        }

    }

   

}
