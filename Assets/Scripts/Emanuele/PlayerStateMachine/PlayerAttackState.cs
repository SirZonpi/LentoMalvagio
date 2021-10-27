﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    public int cambia ;
    public override void EnterState(PlayerStateManager player)
    {
        cambia = 1;
        //Debug.Log("init cambia " + cambia);

        Animator anim = player.GetComponent<Animator>();
        anim.SetBool("idle", false);
        anim.SetBool("cammina", false);
        anim.SetBool("attacca2", false);
        anim.SetBool("attacca", true);
    }

    public override void onCollisionEnter(PlayerStateManager player)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(PlayerStateManager player)
    {
     
        Animator anim = player.GetComponent<Animator>();
        if (Input.GetKeyDown(KeyCode.N))
        {
           
            anim.SetBool("attacca2", true);
        }
 
        if (cambia == 0)
        {
            player.SwitchState(player.idleState);

        }
 
        
    }

    public void Cambia(int _cambia) //da cambiare con una stringa, è un animaton event
    {
        cambia = _cambia;

        Debug.Log("attacco cambia " + cambia);
    }
 

}
